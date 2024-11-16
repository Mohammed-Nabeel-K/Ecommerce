using Ecommerce.Data;
using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IAdminServices
    {
        public Summary summaryAllProducts();
        public Summary summaryByCategory(string category_name);
        public Summary summaryByProduct(Guid product_id);
    }
    public class AdminServices : IAdminServices
    {
        private readonly UserDBContext _dbContext;

        public AdminServices(UserDBContext context)
        {
            _dbContext = context;
        }
        public Summary summaryAllProducts()
        {
            var summary = new Summary()
            {
                product_purchased = _dbContext.Orders.Where(o => o.order_status == "delivered").Count(),
                revenue = _dbContext.Orders.Where(o => o.order_status == "delivered").Sum(n => n.product.price*n.quantity)
            };
            return summary;
        }
        public Summary summaryByCategory(string category_name)
        {
            var summary = new Summary()
            {
                product_purchased = _dbContext.Orders.Where(o => o.order_status == "delivered" && o.product.category.category_name == category_name).Count(),
                revenue = _dbContext.Orders.Where(o => o.order_status == "delivered").Sum(n => n.product.price * n.quantity)
            };
            return summary;
        }
        public Summary summaryByProduct(Guid product_id)
        {
            var summary = new Summary()
            {
                product_purchased = _dbContext.Orders.Where(o => o.order_status == "delivered" && o.product_id == product_id).Count(),
                revenue = _dbContext.Orders.Where(o => o.order_status == "delivered").Sum(n => n.product.price * n.quantity)
            };
            return summary;
        }
    }
}
