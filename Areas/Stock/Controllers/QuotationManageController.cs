using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Stock.Controllers
{
    public class QuotationManageController : BaseStockController
    {
        public QuotationManageController(ICacheService cache) : base(cache)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}