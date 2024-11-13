using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface IUserActionServices
    {
        public ICollection<ProductDTO> getProductsByCategory(string category);
        public ProductDTO getProductById(int id);
        public void addProducttoCart(int productId, int userid);
        public void addCart(int userid);
    }
    public class UserActionServices : IUserActionServices
    {
        public readonly UserDBContext _context;
        public readonly IMapper _mapper;
        public UserActionServices(UserDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<ProductDTO> getProductsByCategory(string category) {

            var products = _context.Categories.Include(n => n.products).Where( n => n.category_name == category);
            var productdtos = _mapper.Map<ICollection<ProductDTO>>(products);
            return productdtos;
        }

        public ProductDTO getProductById(int id) {
            var product = _context.Products.Where(n => n.product_id == id).FirstOrDefault();
            var productdto = _mapper.Map<ProductDTO>(product);
            return productdto;
        }

        public void addProducttoCart(int productId,int userid)
        {
            var cart = _context.Carts.Where(u => u.user_id == userid).FirstOrDefault();
            var prod = new CartItem()
            {
                cart_id = cart.cart_id,
                product_id = productId
            };
            _context.CartItems.Add(prod);
            _context.SaveChanges();

            
        }
        public void addCart(int userid)
        {
            var cart = new Cart()
            {
                user_id = userid
            };
            _context.Carts.Add(cart);
            _context.SaveChanges();

        }
    }
}
