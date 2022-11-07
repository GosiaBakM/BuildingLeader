using AutoMapper;
using BLL.ModelsDTO;
using DAL.Data.Entities;

namespace BLL.Mapping
{
    public class BllProfile : Profile
    {
        public BllProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Name, o => o.MapFrom(u => u.Username))
                //remove below??
                .ForMember(x => x.PasswordHash, o => o.MapFrom(u => u.PasswordHash))
                .ForMember(x => x.PasswordSalt, o => o.MapFrom(u => u.PasswordSalt));

            CreateMap<User,UserDto>()
               .ForMember(x => x.Username, o => o.MapFrom(u => u.Name))
               //remove below??
               .ForMember(x => x.PasswordHash, o => o.MapFrom(u => u.PasswordHash))
               .ForMember(x => x.PasswordSalt, o => o.MapFrom(u => u.PasswordSalt));

            CreateMap<PhotoDto, Photo>().ReverseMap();
        }
    }
}
