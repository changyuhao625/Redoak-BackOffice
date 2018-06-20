using System;
using AutoMapper;
using KendoGridBinder.ModelBinder.Mvc;
using Redoak.Backoffice.Areas.Stock.Models.StockManage;
using Redoak.Backoffice.Areas.System.Models.PersonalProfile;
using Redoak.Domain.Model.Dto;
using Redoak.Domain.Model.Models;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.AutoMapper.System
{
    public class StockManageProfile : Profile
    {
        public StockManageProfile()
        {
            CreateMap<EditModel, Goods>()
                .ForMember(d => d.GoodsCategoryId, s => s.MapFrom(src => src.CategoryId))
                .ForMember(d => d.Name, s => s.MapFrom(src => src.Name))
                .ForMember(d => d.CreateDate, s => s.MapFrom(src => DateTime.Now));
            CreateMap<Goods, EditModel>()
                .ForMember(d => d.CategoryId, s => s.MapFrom(src => src.GoodsCategoryId));

            CreateMap<QueryModel, StockQueryDto>();
            CreateMap<KendoGridMvcRequest, StockQueryDto>();

        }
    }
}
