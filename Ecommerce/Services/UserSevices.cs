using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface IUserServices
    {
        public ICollection<UserDTO> getAllUsers();
        public ICollection<UserDTO> getUsersWithName(string name);
        public Result unblockUser(string username);
        public Result blockUser(string username);
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
        public ICollection<UserDTO> getAllUsers()
        {
            var userresult = _dbContext.Users.Select(n => n).ToList();
            var result = _mapper.Map<ICollection<UserDTO>>(userresult);
            return (result);
        }
        public ICollection<UserDTO> getUsersWithName(string name)
        {
            var userresult = _dbContext.Users.Where(n => n.Name == name).ToList();
            var result = _mapper.Map<ICollection<UserDTO>>(userresult).ToList();
            return result;
        }

        public Result blockUser(string username)
        {
            var user = _dbContext.Users.Find(username);
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

        public Result unblockUser(string username)
        {
            var user = _dbContext.Users.Find(username);
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
