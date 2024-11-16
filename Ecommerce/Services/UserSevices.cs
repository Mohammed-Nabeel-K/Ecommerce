using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface IUserServices
    {
        public ICollection<UserDTO> getAllUsers();
        public ICollection<UserDTO> getUsersWithName(string name);
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
    }
}
