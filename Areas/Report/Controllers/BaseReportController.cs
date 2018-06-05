using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.Report.Controllers
{
    public class BaseReportController : BaseController
    {
        public BaseReportController(ICacheService cache, UserManager<ApplicationUser> userManager) : base(cache,userManager)
        {
        }
    }
}