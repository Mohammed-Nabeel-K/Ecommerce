using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface ICartServices
    {
        public Result addProducttoCart(Guid productId, Guid userid, int quantity);
        public Result removeFromCart(Guid cartitem_id);
        public Result checkoutFromCart(Guid user_id);
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
        public Result addProducttoCart(Guid productId, Guid userid,int quantity)
        {
            
            var cart = _dbContext.Carts.Where(u => u.user_id == userid).FirstOrDefault();
            if (cart == null)
            {
                return new Result() { statuscode = 404, message = "cart not found" };
            }
            else
            {
                try
                {
                    var prod = new CartItem()
                    {
                        cart_id = cart.cart_id,
                        quantity = quantity,
                        product_id = productId
                    };
                    _dbContext.CartItems.Add(prod);
                    _dbContext.SaveChanges();
                    cart.total_amount = _dbContext.CartItems.Where(n => n.cart_id ==cart.cart_id).Sum(n => n.product.price*n.product.quantity);
                    cart.cartItemsCount = _dbContext.CartItems.Where(n => n.cart_id == cart.cart_id).Count();
                    _dbContext.SaveChanges();
                    return new Result() { statuscode = 200, message = " successfully added" };
                }
                catch (Exception ex) {
                    return new Result() { statuscode =500 , message = ex.Message };
                }
            }
        }
        public Result removeFromCart(Guid cartitem_id)
        {
            var cartItem = _dbContext.CartItems.Where(n => n.cartItem_id == cartitem_id).FirstOrDefault();
            _dbContext.CartItems.Remove(cartItem);
            _dbContext.SaveChanges();
            return new Result() { statuscode = 200, message = "successfully removed" };
        }
        public Result checkoutFromCart(Guid user_id)
        {
            try
            {
                var cart = _dbContext.Carts.FirstOrDefault(n => n.user_id == user_id);
                var cartItems = _dbContext.CartItems.Where(n => n.cart_id == cart.cart_id);
                foreach (var item in cartItems)
                {
                    var result = _orderservices.placeOrder(item.product_id, user_id, item.quantity);
                }
                return new Result() { statuscode = 200, message = "order placed successfully" };
            }
            catch(Exception ex)
            {
                return new Result() { statuscode = 500, message = ex.Message };
            }
            
        }
        
    }
}
