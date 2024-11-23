using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface IProductServices
    {
        public Task<ICollection<ProductGetDTO>> GetProducts();  
        public Task<ICollection<ProductGetDTO>> getProductsBYCategory(string category);
        public Task<ProductGetDTO> getProductById(Guid id);
        public Task<Result> AddProduct(ProductDTO productdto);
        public Task<Result> UpdateProduct(ProductGetDTO productdto);
        public Task<Result> DeleteProduct(Guid id);
        public Task<ICollection<ProductGetDTO>> paginatedProducts(int pageNum, int pageSize);
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

        public async Task<ICollection<ProductGetDTO>> GetProducts()
        {
            var products = await _dbContext.Products.Include(n => n.category).ToListAsync();
            var productgetdto = _mapper.Map<ICollection<ProductGetDTO>>(products);
            return productgetdto;
        }

        public async Task<ICollection<ProductGetDTO>> getProductsBYCategory(string category)
        {
            var result = await _dbContext.Products.Where(n => n.category.category_name == category).Include(u => u.category).ToListAsync();
            var prodto = _mapper.Map<ICollection<ProductGetDTO>>(result);
            return prodto;
        }
        public async Task<ProductGetDTO> getProductById(Guid id)
        {
            var result = await _dbContext.Products.Where(n => n.product_id == id).FirstOrDefaultAsync();
            var proddto = _mapper.Map<ProductGetDTO>(result);
            return proddto;
        }
        public async Task<Result> AddProduct(ProductDTO productdto)
        {
            var res = await _dbContext.Categories.Where(n => n.category_name == productdto.category_name).FirstOrDefaultAsync();
            if (res == null)
            {
                return new Result() { statuscode = 404, message = "category not found" };
            }
            var product = _mapper.Map<Product>(productdto);
            product.category_id = res.category_id;
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return new Result() { statuscode = 201, message = "product added" };
        }
        public async Task<Result> UpdateProduct(ProductGetDTO productdto)
        {
            
            var prod = await _dbContext.Products.Where(n => n.product_id == productdto.product_id).FirstOrDefaultAsync();
            if (prod != null)
            {
                prod.product_name = productdto.product_name;
                prod.price = productdto.price;
                prod.quantity = productdto.quantity;
                await _dbContext.SaveChangesAsync();
                return new Result() { statuscode = 201, message = "updated successfully" };

            }
            return new Result() { statuscode = 400, message = "this product not on list" };

        }
        public async Task<Result> DeleteProduct(Guid id)
        {
            var prod = await _dbContext.Products.Where(p => p.product_id == id).FirstOrDefaultAsync();
            if (prod == null)
            {
                return new Result() { statuscode = 404, message = "product not found" };
            }
            _dbContext.Remove(prod);
            await _dbContext.SaveChangesAsync();
            return new Result() { statuscode = 200, message = "deleted succefully" };
        }

        public async Task<ICollection<ProductGetDTO>> paginatedProducts(int pageNum,int pageSize)
        {
            int total = _dbContext.Products.Count();
            var products = await _dbContext.Products.Skip((pageNum - 1) * pageSize).Take(pageSize).Include(p => p.category).ToListAsync();
            var prod = _mapper.Map<ICollection<ProductGetDTO>>(products);
            return prod;
        }
    }
}
