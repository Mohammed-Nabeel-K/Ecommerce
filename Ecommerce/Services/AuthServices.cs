using AutoMapper;
using BCrypt.Net;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IAuthServices
    {
        public Result Register(UserDTO user);
        public User Login(LoginDTO user);
    }
    public class AuthServices : IAuthServices
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        public AuthServices(UserDBContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public Result Register(UserDTO userdto)
        {
            var user = _mapper.Map<User>(userdto);
            try
            {
                user.Password = HashPassword(userdto.Password);
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                var getuser = _dbContext.Users.Where(u => u.username == user.username).FirstOrDefault();

                int total = 0;
                int count = 0;

                var cart = new Cart()
                {
                    user_id = getuser.user_id,
                    total_amount = total,
                    cartItemsCount = count
                };
                _dbContext.Carts.Add(cart);
                _dbContext.SaveChanges();
                return new Result() { statuscode = 200, message = "successfully registered" };
            }
            catch (Exception ex) {
                return new Result() { statuscode = 200, message = ex.Message };
            }
        }
        public User Login(LoginDTO user)
        {
            
            var result = _dbContext.Users.Where(n => n.username == user.username ).FirstOrDefault();
            bool resPass = VerifyHashed(user.Password,result.Password);
            return (result);
        }


        private string HashPassword(string password)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(password);
            return hashed;
        }
        private bool VerifyHashed(string password,string hashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashed);
        } 
    }
}
