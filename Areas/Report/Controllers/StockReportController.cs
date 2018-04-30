using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Report.Controllers
{
    [Authorize]
    [Area("Stock")]
    [Route("[controller]/[action]")]
    public class StockReportController : BaseReportController
    {
        public StockReportController(ICacheService cache) : base(cache)
        {
        }

        // GET
        public IActionResult Index()
        {
            return
                View();
        }
    }
}