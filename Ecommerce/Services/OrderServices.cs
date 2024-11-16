using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface IOrderServices
    {
        public Result placeOrder(Guid product_id, Guid user_id, int quantity);
        public Result updateOrder(Guid order_id, string order_status);
        public Result deleteOrder(Guid order_id);
        public ICollection<OrderAdminDTO> getOrders();
        public ICollection<OrderUserDTO> getOrdersByUser(Guid user_id);
    }

    public class OrderServices : IOrderServices
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        public OrderServices(UserDBContext userDBContext,IMapper mapper) {
            _dbContext = userDBContext;
            _mapper = mapper;
        }

        public Result placeOrder(Guid product_id, Guid user_id,int quantity) {
            var product = _dbContext.Products.Where(n=> n.product_id == product_id).FirstOrDefault();
            if (product != null) {
                try
                {
                    var order = new Order()
                    {
                        product_id = product_id,
                        user_id = user_id,
                        quantity = quantity,
                        orderplaced = DateTime.Now,
                        order_status = "order placed"
                    };
                    _dbContext.Orders.Add(order);
                    _dbContext.SaveChanges();
                    return new Result() { statuscode = 200, message = "order placed" };
                }
                catch (Exception ex) {
                    return new Result() { statuscode = 500, message = ex.Message };
                }
                
            }
            
            return new Result() { statuscode = 404, message = "product not found" };
            
        }

       
        public Result updateOrder(Guid order_id, string order_status)
        {
            var ord = _dbContext.Orders.FirstOrDefault(n => n.order_id == order_id);
            if (ord != null) {
                try
                {
                    ord.order_status = order_status;
                    _dbContext.SaveChanges();
                    return new Result() { statuscode = 200, message = "sucessfully edited" };
                }
                catch(Exception ex) 
                {
                    return new Result() { statuscode = 500, message = ex.Message };
                }
                
            }
            return new Result() { statuscode = 404, message = "it is not a valid order" };
        }


        public Result deleteOrder(Guid order_id)
        {
            var ord = _dbContext.Orders.FirstOrDefault(n => n.order_id == order_id);
            if (ord != null)
            {
                try
                {
                    _dbContext.Orders.Remove(ord);
                    _dbContext.SaveChanges();
                    return new Result() { statuscode = 200, message = "sucessfully deleted" };
                }
                catch (Exception ex)
                {
                    return new Result() { statuscode = 500, message = ex.Message };
                }

            }
            return new Result() { statuscode = 404, message = "it is not a valid order" };
        }

        public ICollection<OrderUserDTO> getOrdersByUser(Guid user_id) {
            var orders = _dbContext.Orders.Where(u => u.user_id == user_id).Include(n => n.product);
            var orderdto = _mapper.Map<ICollection<OrderUserDTO>>(orders);
            return orderdto;
        }

        public ICollection<OrderAdminDTO> getOrders()
        {
            var orders = _dbContext.Orders.Include(n => n.product).Include(n => n.user);
            var orderdto = _mapper.Map<ICollection<OrderAdminDTO>>(orders);
            return orderdto;

        }

    }
}
