using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface ICartServices
    {
        public Task<Result> addProducttoCart(Guid productId, Guid userid, int quantity);
        public Task<Result> removeFromCart(Guid cartitem_id, Guid userid);
        public Task<Result> checkoutFromCart(Guid user_id, Guid address_id);
        public Task<ICollection<CartItemDTO>> getAllFromCart(Guid user_id);
    }
    public class CartServices : ICartServices
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IOrderServices _orderservices;
       
        public CartServices(UserDBContext context, IMapper mapper,IOrderServices orderServices)
        {
            _dbContext = context;
            _mapper = mapper;
            _orderservices = orderServices;
            
        }
        public async Task<Result> addProducttoCart(Guid productId, Guid userid,int quantity)
        {
            
            var cart = await _dbContext.Carts.Where(u => u.user_id == userid).FirstOrDefaultAsync();
            if (cart == null)
            {
                return new Result() { statuscode = 404, message = "cart not found" };
            }
            else
            {
                try
                {
                    var cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(u => u.product_id == productId && u.cart_id == cart.cart_id);
                    if ( cartItem != null)
                    {
                        cartItem.quantity += quantity;
                        _dbContext.CartItems.Update(cartItem);
                        await _dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var prod = new CartItem()
                        {
                            cart_id = cart.cart_id,
                            quantity = quantity,
                            product_id = productId
                        };
                        _dbContext.CartItems.Add(prod);
                        await _dbContext.SaveChangesAsync();
                    }
                    
                    cart.total_amount = _dbContext.CartItems.Where(n => n.cart_id ==cart.cart_id).Sum(n => n.product.price*n.product.quantity);
                    cart.cartItemsCount = _dbContext.CartItems.Where(n => n.cart_id == cart.cart_id).Count();
                    await _dbContext.SaveChangesAsync();
                    return new Result() { statuscode = 200, message = " successfully added" };
                }
                catch (Exception ex) {
                    return new Result() { statuscode =500 , message = ex.Message };
                }
            }
        }
        public async Task<Result> removeFromCart(Guid cartitem_id, Guid userid)
        {
            try
            {
                var cartItem = await _dbContext.CartItems.Where(n => n.cartItem_id == cartitem_id).FirstOrDefaultAsync();
                _dbContext.CartItems.Remove(cartItem);
                await _dbContext.SaveChangesAsync();
                var cart = await _dbContext.Carts.Where(u => u.user_id == userid).FirstOrDefaultAsync();
                cart.total_amount = _dbContext.CartItems.Where(n => n.cart_id == cart.cart_id).Sum(n => n.product.price * n.product.quantity);
                cart.cartItemsCount = _dbContext.CartItems.Where(n => n.cart_id == cart.cart_id).Count();
                await _dbContext.SaveChangesAsync();
                return new Result() { statuscode = 200, message = "successfully removed" };
            }
            catch(Exception ex)
            {
                return new Result() { statuscode = 500, message = ex.Message };
            }
        }
        public async Task<Result> checkoutFromCart(Guid user_id,Guid address_id)
        {
            try
            {
                var cart = await _dbContext.Carts.FirstOrDefaultAsync(n => n.user_id == user_id);
                var cartItems = await _dbContext.CartItems.Where(n => n.cart_id == cart.cart_id).ToListAsync();
                foreach (var item in cartItems)
                {
                    var result = _orderservices.placeOrder(item.product_id, user_id, item.quantity,address_id);
                    _dbContext.CartItems.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
                return new Result() { statuscode = 200, message = "order placed successfully" };
            }
            catch(Exception ex)
            {
                return new Result() { statuscode = 500, message = ex.Message };
            }
            
        }

        public async Task<ICollection<CartItemDTO>> getAllFromCart(Guid user_id)
        {
            try
            {
                var cart = await _dbContext.Carts.FirstOrDefaultAsync(n => n.user_id == user_id);
                var cartItems = await _dbContext.CartItems.Where(u => u.cart_id == cart.cart_id).Include(u => u.product).ToListAsync();
                var cartit = _mapper.Map<ICollection<CartItemDTO>>(cartItems);
                return cartit;
            }
            catch
            {
                return null;
            }
            
        }
        
    }
}
