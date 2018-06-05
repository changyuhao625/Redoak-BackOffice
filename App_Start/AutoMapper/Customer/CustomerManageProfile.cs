using System;
using AutoMapper;
using Redoak.Backoffice.Areas.Customer.Models.CustomerManage;

namespace Redoak.Backoffice.AutoMapper.Customer
{
    public class CustomerManageProfile:Profile
    {
        public CustomerManageProfile()
        {
            CreateMap<CreateModel, Domain.Model.Models.Customer>();
        }
    }
}
