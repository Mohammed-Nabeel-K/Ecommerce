using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface IUserServices
    {
        public Task<ICollection<UserDTO>> getAllUsers();
        public Task<ICollection<UserDTO>> getUsersWithName(string name);
        public Task<Result> unblockUser(string username);
        public Task<Result> blockUser(string username);
    }
    public class UserSevices : IUserServices
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        public UserSevices(UserDBContext context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<ICollection<UserDTO>> getAllUsers()
        {
            var userresult = await _dbContext.Users.Select(n => n).ToListAsync();
            var result = _mapper.Map<ICollection<UserDTO>>(userresult);
            return (result);
        }
        public async Task<ICollection<UserDTO>> getUsersWithName(string name)
        {
            var userresult = await _dbContext.Users.Where(n => n.Name == name).ToListAsync();
            var result = _mapper.Map<ICollection<UserDTO>>(userresult).ToList();
            return result;
        }

        public async Task<Result> blockUser(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(n => n.username == username);
            if (user == null)
            {
                return new Result() { statuscode = 404, message = "user not found" };
            }

            if (user.IsBlocked)
            {
                return new Result() { statuscode = 409, message = "user already blocked" };
            }

            user.IsBlocked = true;
            return new Result() { statuscode = 200, message = "user blocked" };
        }

        public async Task<Result> unblockUser(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(n => n.username == username);
            if (user == null)
            {
                return new Result() { statuscode = 404, message = "user not found" };
            }

            if (!user.IsBlocked)
            {
                return new Result() { statuscode = 409, message = "user already unblocked" };
            }

            user.IsBlocked = false;
            return new Result() { statuscode = 200, message = "user unblocked" };
        }

    }
}
