using AutoMapper;
using Ecommerce.Data;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public interface IAddressServices
    {
        public Task<Result> addAddress(Guid user_id, AddressDTO address);
        public Task<Result> removeAddress(Guid address_id);
        public Task<Result> updateAddress(Guid address_id , AddressDTO addressdto);
        public Task<ICollection<AddressGetDTO>> getAllAddress(Guid user_id);

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
        public async Task<Result> addAddress(Guid user_id,AddressDTO addressdto)
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
                await _dbContext.SaveChangesAsync();
                return new Result() { statuscode = 200, message = "address added" };
            }
            catch
            {
                return new Result() { statuscode = 500, message = " server error" };
            }
            
        }
        public async Task<Result> removeAddress(Guid address_id)
        {
            if (address_id == null)
            {
                return new Result() { statuscode = 400, message = "not a valid address" };
            }
            try
            {
                var address = await _dbContext.Addresses.FirstOrDefaultAsync(n => n.address_id == address_id);
                _dbContext.Addresses.Remove(address);
                await _dbContext.SaveChangesAsync();
                
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
        public async Task<Result> updateAddress(Guid address_id, AddressDTO addressToUpdate)
        {
            if (addressToUpdate == null)
            {
                return new Result() { statuscode = 400, message = "not a valid address" };
            }
            try
            {
                var address = await _dbContext.Addresses.FirstOrDefaultAsync(n => n.address_id.Equals(address_id));
                address.address = addressToUpdate.address;
                address.pincode = addressToUpdate.pincode;
                address.type = addressToUpdate.type;
                _dbContext.Addresses.Update(address);
                await _dbContext.SaveChangesAsync();
                return new Result() { statuscode = 200, message = "address added" };
            }
            catch
            {
                return new Result() { statuscode = 500, message = " server error" };
            }
        }
        public async Task<ICollection<AddressGetDTO>> getAllAddress(Guid user_id)
        {
            
            var addresses = await _dbContext.Addresses.Where(n => n.user_id == user_id).ToListAsync();
            var addressdto = _mapper.Map< ICollection<AddressGetDTO>>(addresses);

            return addressdto;

            
            
        }
    }
}
