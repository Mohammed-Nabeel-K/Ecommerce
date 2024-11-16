using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface IProductServices
    {
        public ICollection<ProductGetDTO> getProductsBYCategory(string category);
        public ProductGetDTO getProductById(Guid id);
        public Result AddProduct(ProductDTO productdto);
        public Result UpdateProduct(ProductGetDTO productdto);
        public Result DeleteProduct(Guid id);
    }
    public class ProductServices : IProductServices
    {

        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        public ProductServices(UserDBContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public ICollection<ProductGetDTO> getProductsBYCategory(string category)
        {
            var result = _dbContext.Products.Where(n => n.category.category_name == category).Include(u => u.category).ToList();
            var prodto = _mapper.Map<ICollection<ProductGetDTO>>(result);
            return prodto;
        }
        public ProductGetDTO getProductById(Guid id)
        {
            var result = _dbContext.Products.Where(n => n.product_id == id).FirstOrDefault();
            var proddto = _mapper.Map<ProductGetDTO>(result);
            return proddto;
        }
        public Result AddProduct(ProductDTO productdto)
        {
            var res = _dbContext.Categories.Where(n => n.category_name == productdto.category_name).FirstOrDefault();
            if (res == null)
            {
                return new Result() { statuscode = 404, message = "category not found" };
            }
            var product = _mapper.Map<Product>(productdto);
            product.category_id = res.category_id;
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return new Result() { statuscode = 201, message = "product added" };
        }
        public Result UpdateProduct(ProductGetDTO productdto)
        {
            
            var prod = _dbContext.Products.Where(n => n.product_id == productdto.product_id).FirstOrDefault();
            if (prod != null)
            {
                prod.product_name = productdto.product_name;
                prod.price = productdto.price;
                prod.quantity = productdto.quantity;
                _dbContext.SaveChanges();
                return new Result() { statuscode = 201, message = "updated successfully" };

            }
            return new Result() { statuscode = 400, message = "this product not on list" };

        }
        public Result DeleteProduct(Guid id)
        {
            var prod = _dbContext.Products.Where(p => p.product_id == id).FirstOrDefault();
            if (prod == null)
            {
                return new Result() { statuscode = 404, message = "product not found" };
            }
            _dbContext.Remove(prod);
            _dbContext.SaveChanges();
            return new Result() { statuscode = 200, message = "deleted succefully" };
        }

    }
}
