using AutoMapper;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<Product, ProductDTO>().ForMember(n => n.category_name, e => e.MapFrom(s => s.category.category_name));
        }
    }
}
