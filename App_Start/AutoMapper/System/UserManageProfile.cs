using AutoMapper;
using Redoak.Backoffice.Areas.System.Models.UserManage;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.AutoMapper.System
{
    public class UserManageProfile : Profile
    {
        public UserManageProfile()
        {
            CreateMap<ApplicationUser, PensonalProfileModel>()
                .ForMember(d => d.UserId, s => s.MapFrom(src => src.Id))
                .ForMember(d => d.Username, s => s.MapFrom(src => src.UserName))
                .ForMember(d => d.Email, s => s.MapFrom(src => src.Email))
                .ForMember(d => d.PhoneNumber, s => s.MapFrom(src => src.PhoneNumber));
        }
    }
}
