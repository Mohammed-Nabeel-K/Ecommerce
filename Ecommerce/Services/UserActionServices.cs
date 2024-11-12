using Ecommerce.Data;

namespace Ecommerce.Services
{
    public interface IUserActionServices
    {

    }
    public class UserActionServices : IUserActionServices
    {
        public readonly UserDBContext _context;
        public UserActionServices(UserDBContext context)
        {
            _context = context;
        }



    }
}
