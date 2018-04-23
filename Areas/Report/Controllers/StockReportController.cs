using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Report.Controllers
{
    public class StockReportController : BaseReportController
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }

        public StockReportController(ICacheService cache) : base(cache)
        {
        }
    }
}