using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.Customer.Controllers
{
    public abstract class CustomerBaseController : BaseController
    {
        public CustomerBaseController(ICacheService cache, UserManager<ApplicationUser> userManager) : base(cache, userManager)
        {
        }
    }
}