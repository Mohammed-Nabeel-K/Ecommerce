using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ecommerce.Services
{
    public interface IAdminActionServices
    {
        public ICollection<UserDTO> getAllUsers();
        public ICollection<UserDTO> getUsersWithName(string name);
        public ICollection<Product> getProductsBYCategory(string category);
        public Product getProductById(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);

    }

    public class AdminActionServices : IAdminActionServices
    {
        public readonly UserDBContext _context;
        public readonly IMapper _mapper;
        public AdminActionServices(UserDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        public ICollection<UserDTO> getAllUsers()
        {
            var userresult = _context.Users.Select(n => n).ToList();
            var result = _mapper.Map<ICollection<UserDTO>>(userresult);
            return (result);
        }
        public ICollection<UserDTO> getUsersWithName(string name)
        {
            var userresult = _context.Users.Where(n => n.Name == name).ToList();
            var result = _mapper.Map<ICollection<UserDTO>>(userresult).ToList();
            return result;
        }
        public ICollection<Product> getProductsBYCategory(string category) 
        {
            var result = _context.Products.Where(n => n.category.category_name == category).ToList();
            return result;
        }
        public Product getProductById(int id) {
            var result = _context.Products.Where(n => n.product_id == id).FirstOrDefault();
            return result;
        }
        public void AddProduct(Product product) {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product) {
            var prod = _context.Products.Where(n => n.product_id  == product.product_id).FirstOrDefault();
            if (prod != null)
            {
                prod.product_name = product.product_name;
                prod.price = product.price;
                prod.quantity = product.quantity;
                _context.SaveChanges();

            }
            
            
        }
        public void DeleteProduct(int id) {
            var prod = _context.Products.Where(p => p.product_id == id).FirstOrDefault();
            _context.Remove(prod);
        }
    }
}
