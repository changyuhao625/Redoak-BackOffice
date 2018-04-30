using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Report.Controllers
{
    [Authorize]
    [Area("Stock")]
    [Route("[controller]/[action]")]
    public class OrderReportController : BaseReportController
    {
        public OrderReportController(ICacheService cache) : base(cache)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}