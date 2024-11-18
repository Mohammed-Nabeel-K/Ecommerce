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
        public Task<Result> placeOrder(Guid product_id, Guid user_id, int quantity, Guid address_id);
        public Task<Result> updateOrder(Guid order_id, string order_status);
        public Task<Result> deleteOrder(Guid order_id);
        public Task<ICollection<OrderAdminDTO>> getOrders();
        public Task<ICollection<OrderUserDTO>> getOrdersByUser(Guid user_id);
    }

    public class OrderServices : IOrderServices
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        public OrderServices(UserDBContext userDBContext,IMapper mapper) {
            _dbContext = userDBContext;
            _mapper = mapper;
        }

        public async Task<Result> placeOrder(Guid product_id, Guid user_id,int quantity,Guid address_id) {
            var product = await _dbContext.Products.Where(n=> n.product_id == product_id).FirstOrDefaultAsync();
            if (product != null) {
                try
                {
                    var order = new Order()
                    {
                        product_id = product_id,
                        user_id = user_id,
                        quantity = quantity,
                        address_id = address_id,
                        orderplaced = DateTime.Now,
                        order_status = "order placed"
                    };
                    _dbContext.Orders.Add(order);
                    await _dbContext.SaveChangesAsync();
                    return new Result() { statuscode = 200, message = "order placed" };
                }
                catch (Exception ex) {
                    return new Result() { statuscode = 500, message = ex.Message };
                }
                
            }
            
            return new Result() { statuscode = 404, message = "product not found" };
            
        }

       
        public async Task<Result> updateOrder(Guid order_id, string order_status)
        {
            var ord = await _dbContext.Orders.FirstOrDefaultAsync(n => n.order_id == order_id);
            if (ord != null) {
                try
                {
                    ord.order_status = order_status;
                    await _dbContext.SaveChangesAsync();
                    return new Result() { statuscode = 200, message = "sucessfully edited" };
                }
                catch(Exception ex) 
                {
                    return new Result() { statuscode = 500, message = ex.Message };
                }
                
            }
            return new Result() { statuscode = 404, message = "it is not a valid order" };
        }


        public async Task<Result> deleteOrder(Guid order_id)
        {
            var ord = await _dbContext.Orders.FirstOrDefaultAsync(n => n.order_id == order_id);
            if (ord != null)
            {
                try
                {
                    _dbContext.Orders.Remove(ord);
                    await _dbContext.SaveChangesAsync();
                    return new Result() { statuscode = 200, message = "sucessfully deleted" };
                }
                catch (Exception ex)
                {
                    return new Result() { statuscode = 500, message = ex.Message };
                }

            }
            return new Result() { statuscode = 404, message = "it is not a valid order" };
        }

        public async Task<ICollection<OrderUserDTO>> getOrdersByUser(Guid user_id) {
            var orders = await _dbContext.Orders.Where(u => u.user_id == user_id).Include(n => n.product).ToListAsync();
            var orderdto = _mapper.Map<ICollection<OrderUserDTO>>(orders);
            return orderdto;
        }

        public async Task<ICollection<OrderAdminDTO>> getOrders()
        {
            var orders = await _dbContext.Orders.Include(n => n.product).Include(n => n.user).ToListAsync();
            var orderdto = _mapper.Map<ICollection<OrderAdminDTO>>(orders);
            return orderdto;

        }

    }
}
