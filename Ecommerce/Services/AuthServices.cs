using AutoMapper;
using BCrypt.Net;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Services
{
    public interface IAuthServices
    {
        public Task<Result> Register(UserDTO user);
        public Task<Result> Login(LoginDTO user);
    }
    public class AuthServices : IAuthServices
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthServices(UserDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<Result> Register(UserDTO userdto)
        {
            var user = _mapper.Map<User>(userdto);
            try
            {
                var getuse = await _dbContext.Users.Where(u => u.username == user.username).FirstOrDefaultAsync();
                if (getuse != null) {
                return new Result() { statuscode = 409, message = "username already exist" };
                }

                user.Password = HashPassword(userdto.Password);
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
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
                await _dbContext.SaveChangesAsync();
                return new Result() { statuscode = 201, message = "successfully registered" };
            }
            catch (Exception ex) {
                return new Result() { statuscode = 500, message = ex.Message };
            }
        }
        public async Task<Result> Login(LoginDTO user)
        {
            
            var userData = await _dbContext.Users.Where(n => n.username == user.username ).FirstOrDefaultAsync();
            bool resPass = VerifyHashed(user.Password, userData.Password);
            
            try
            {
                
                if (userData == null)
                {
                    return new Result() { statuscode = 400, message = "no credentials" };
                }
                if (!resPass) 
                { 
                    return new Result() {statuscode = 401 , message = "incorrect password" }; 
                }
                if (userData.IsBlocked)
                {
                    return new Result() { statuscode = 401, message = "you are blocked" };
                }
                var token = CreateToken(userData);
                return new Result(){statuscode = 200, message = token };
            }
            catch (Exception ex)
            {
                return new Result() { statuscode = 500, message = ex.Message };
            }
        }

        private string CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim (ClaimTypes.NameIdentifier,user.user_id.ToString()),
                new Claim (ClaimTypes.Name,user.username),
                new Claim (ClaimTypes.Email,user.Email),
                new Claim (ClaimTypes.Role,user.Roles)
            };

            var token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddDays(1)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string HashPassword(string password)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(password);
            return hashed;
        }
        private bool VerifyHashed(string password,string hashed)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashed);
            }
            catch(Exception ex)
            {
                return false;
            }
            
        } 
    }
}
