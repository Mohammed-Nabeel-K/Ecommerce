using AutoMapper;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<User, CartDTO>();
            CreateMap<Product, ProductGetDTO>().ForMember(n => n.category_name, e => e.MapFrom(s => s.category.category_name));
            CreateMap<ProductDTO, Product>().ForPath(n => n.category.category_name, e => e.Ignore());
            CreateMap<WishlistDTO, WishList>();
            CreateMap<Order,OrderUserDTO>().ForMember(n => n.product_name, e => e.MapFrom(s=> s.product.product_name));
            CreateMap<Order,OrderAdminDTO>().ForMember(n => n.product_name, e => e.MapFrom(a => a.product.product_name))
                .ForMember(n => n.username,e => e.MapFrom(a => a.user.username));
            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressGetDTO>();
            CreateMap<CartItem, CartItemDTO>().ForMember(n => n.product_name, e => e.MapFrom(s => s.product.product_name))
                .ForMember(n => n.price, e => e.MapFrom(s => s.product.price));
        }
    }
}
