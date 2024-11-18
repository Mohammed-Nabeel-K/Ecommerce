using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface ICategoryServices
    {
        public Task<Result> addCategory(string categorydto);
        public Task<Result> removeCategory(string categorydto);
    }
    public class CategorySevices : ICategoryServices
    {
        public readonly UserDBContext _dbContext;
        public CategorySevices(UserDBContext userDBContext)
        {
            _dbContext = userDBContext;   
        }
        public async Task<Result> addCategory(string category_name)
        {
            var category = await _dbContext.Categories.FindAsync(category_name);
            if (category != null )
            {
                return new Result() { statuscode = 409, message = "category already exist" };
            }
            var cat = new Category() { category_name = category_name};
            await _dbContext.Categories.AddAsync(cat);  
            await _dbContext.SaveChangesAsync();
            return new Result() { statuscode = 201, message = "category added" };
        }
        public async Task<Result> removeCategory(string category_name)
        {
            var category = await _dbContext.Categories.FindAsync(category_name);
            if (category == null)
            {
                return new Result() { statuscode = 400, message = "category not exist" };
            }
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return new Result() { statuscode = 200, message = "category removed" };
        }
    }
}
