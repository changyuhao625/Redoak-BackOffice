using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Stock.Controllers
{
    [Authorize]
    [Area("Stock")]
    [Route("[controller]/[action]")]
    public class StockManageController : BaseStockController
    {
        public StockManageController(ICacheService cache) : base(cache)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}