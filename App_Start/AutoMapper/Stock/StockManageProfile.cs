using System;
using AutoMapper;
using Redoak.Backoffice.Areas.Stock.Models.StockManage;
using Redoak.Backoffice.Areas.System.Models.PersonalProfile;
using Redoak.Domain.Model.Models;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.AutoMapper.System
{
    public class StockManageProfile : Profile
    {
        public StockManageProfile()
        {
            CreateMap<CreateModel, Goods>()
                .ForMember(d => d.GoodsCategoryId, s => s.MapFrom(src => src.CategoryId))
                .ForMember(d => d.Name, s => s.MapFrom(src => src.Name))
                .ForMember(d => d.CreateDate, s => s.MapFrom(src => DateTime.Now))
                //.ForMember(d => d.UpdateDate, s => s.MapFrom(src => src.Email))
                /*.ForMember(d => d.UpdateUser, s => s.MapFrom(src => src.PhoneNumber))*/;
        }
    }
}
