using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ecommerce.Services
{
    public interface IUserAuthServices
    {
        public void Register(UserDTO user);
        public User Login(LoginDTO user);
            
    }
    public class UserAuthServices : IUserAuthServices
    {
        public readonly UserDBContext _context;
        public readonly IMapper _mapper;
        public UserAuthServices(UserDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Register(UserDTO userdto)
        {
            var user = _mapper.Map<User>(userdto);
            _context.Users.Add(user);
            
            
            _context.SaveChanges();
            
        }
        public User Login(LoginDTO user) { 
            var result = _context.Users.Where(n => n.Name == user.username && n.Password == user.Password).FirstOrDefault();
            
            return (result);
        }

        
    }
}
