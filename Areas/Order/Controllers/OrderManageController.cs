using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Order.Controllers
{
    [Authorize]
    [Area("Oder")]
    [Route("[controller]/[action]")]
    public class OrderManageController : BaseOrderController
    {
        public OrderManageController(ICacheService cache) : base(cache)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}