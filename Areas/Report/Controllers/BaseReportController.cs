using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Report.Controllers
{
    public class BaseReportController : BaseController
    {
        public BaseReportController(ICacheService cache) : base(cache)
        {
        }
    }
}