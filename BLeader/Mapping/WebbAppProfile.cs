using AutoMapper;
using BLL.ModelsDTO;
using DAL.Data.Entities;
using System.Linq;
using WebApp.ViewModels;

namespace BLeader.Mapping
{
    public class WebbAppProfile : Profile
    {
        public WebbAppProfile()
        {
            CreateMap<UserViewModel, UserDto>()
            .ForMember(x => x.Username, o => o.MapFrom(u => u.Username))
            .ForMember(x => x.PasswordHash, o => o.Ignore())
            .ForMember(x => x.PasswordSalt, o => o.Ignore());

            CreateMap<UserDto, UserViewModel>()
           .ForMember(x => x.Username, o => o.MapFrom(u => u.Username))
           .ForMember(x => x.Token, o => o.Ignore());

            CreateMap<User, UserViewModel>()
                .ForMember(x => x.Username, o => o.MapFrom(u => u.Name))
                .ForMember(x => x.Token, o => o.Ignore());

            CreateMap<Photo, PhotoViewModel>();

            CreateMap<User, MemberViewModel>()
                .ForMember(x => x.Username, o => o.MapFrom(u => u.Name))
                .ForMember(x => x.PhotoUrl, o => o.MapFrom(u => u.Photos.FirstOrDefault(f => f.IsMain).Url));

            CreateMap<MemberUpdateViewModel, User>().ReverseMap();
            //CreateMap<RegisterViewModel, User>().ReverseMap();
            CreateMap<RegisterViewModel, UserDto>().ReverseMap();
        }
    }
}
