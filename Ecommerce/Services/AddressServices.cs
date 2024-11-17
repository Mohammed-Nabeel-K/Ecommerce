using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IAddressServices
    {
        public Result addAddress(Guid user_id, AddressDTO address);
        public Result removeAddress(Guid address_id);
        public Result updateAddress(Guid address_id , AddressDTO addressdto);
        public ICollection<Address> getAllAddress(Guid user_id);

    }
    public class AddressServices : IAddressServices
    {
        private readonly UserDBContext _dbContext;
        private readonly IMapper _mapper;
        public AddressServices(UserDBContext context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;   
        }
        public Result addAddress(Guid user_id,AddressDTO addressdto)
        {
            if (addressdto == null)
            {
                return new Result() { statuscode = 400, message = "not a valid address" };
            }
            try
            {
                var address = _mapper.Map<Address>(addressdto);
                address.user_id = user_id;
                _dbContext.Addresses.Add(address);
                _dbContext.SaveChanges();
                return new Result() { statuscode = 200, message = "address added" };
            }
            catch
            {
                return new Result() { statuscode = 500, message = " server error" };
            }
            
        }
        public Result removeAddress(Guid address_id)
        {
            if (address_id == null)
            {
                return new Result() { statuscode = 400, message = "not a valid address" };
            }
            try
            {
                var address = _dbContext.Addresses.FirstOrDefault(n => n.address_id == address_id);
                _dbContext.Addresses.Remove(address);
                _dbContext.SaveChanges();
                
            }
            catch(Exception ex)
            {   if (ex.InnerException != null)
                {
                    return new Result() { statuscode = 500, message = ex.InnerException.Message };
                }
                return new Result() { statuscode = 500, message = ex.Message };
            }
                return new Result() { statuscode = 200, message = "address removed" };
        }
        public Result updateAddress(Guid address_id, AddressDTO addressToUpdate)
        {
            if (addressToUpdate == null)
            {
                return new Result() { statuscode = 400, message = "not a valid address" };
            }
            try
            {
                var address = _dbContext.Addresses.FirstOrDefault(n => n.address_id.Equals(address_id));
                address.address = addressToUpdate.address;
                address.pincode = addressToUpdate.pincode;
                address.type = addressToUpdate.type;
                _dbContext.Addresses.Update(address);
                _dbContext.SaveChanges();
                return new Result() { statuscode = 200, message = "address added" };
            }
            catch
            {
                return new Result() { statuscode = 500, message = " server error" };
            }
        }
        public ICollection<Address> getAllAddress(Guid user_id)
        {
            
            var addresses = _dbContext.Addresses.Where(n => n.user_id == user_id).ToList();

            return addresses;

            
            
        }
    }
}
