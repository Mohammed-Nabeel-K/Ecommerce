using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Services
{
    public interface IWishListServices
    {
        public Result addWishList(Guid product_id, Guid user_id);
        public Result deleteWishList(Guid product_id, Guid user_id);
    }
    public class WishListServices : IWishListServices
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        public WishListServices(UserDBContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public Result addWishList(Guid product_id,Guid user_id)
        {
            var prod = _dbContext.Products.FirstOrDefault(n => n.product_id == product_id);
            if (prod == null) 
            {
                return new Result() { statuscode = 404, message = "product not found" };
            }
            var produ = _dbContext.WishLists.Where(n => n.product_id == product_id && n.user_id == user_id).FirstOrDefault();
            if (produ != null)
            {
                return new Result() { statuscode = 400, message = "already added" };
            }
            var wish = new WishList()
            {
                wishlist_id = Guid.NewGuid(),
                product_id = product_id,
                user_id = user_id
            };
            _dbContext.WishLists.Add(wish);
            _dbContext.SaveChanges();
            return new Result() { statuscode = 200, message = "added to wishlist" };
        }

        public Result deleteWishList(Guid product_id,Guid user_id)
        {
            var prod = _dbContext.WishLists.Where(n => n.product_id == product_id && n.user_id == user_id).FirstOrDefault();
            if (prod != null)
            {
                _dbContext.WishLists.Remove(prod);
                _dbContext.SaveChanges();
                return new Result() { statuscode = 200, message = "removed from wishlist" };
                
            }
            return new Result() { statuscode = 404, message = "product not found" };

        }
    }
}
