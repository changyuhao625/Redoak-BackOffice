using System;
using AutoMapper;
using KendoGridBinder.ModelBinder.Mvc;
using Redoak.Backoffice.Areas.Customer.Models.CustomerManage;
using Redoak.Domain.Model.Dto;

namespace Redoak.Backoffice.AutoMapper.Customer
{
    public class CustomerManageProfile : Profile
    {
        public CustomerManageProfile()
        {
            CreateMap<CreateModel, Domain.Model.Models.Customer>();
            CreateMap<KendoGridMvcRequest, CustomerQueryDto>();
            CreateMap<QueryModel, CustomerQueryDto>();
            CreateMap<Domain.Model.Models.Customer, CreateModel>();
        }
    }
}
