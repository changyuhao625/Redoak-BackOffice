using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Report.Controllers
{
    public class OrderReportController : BaseReportController
    {
        public IActionResult Index()
        {
            return View();
        }

        public OrderReportController(ICacheService cache) : base(cache)
        {
        }
    }
}