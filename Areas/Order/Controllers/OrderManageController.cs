using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.Order.Controllers
{
    [Authorize]
    [Area("Oder")]
    [Route("[controller]/[action]")]
    public class OrderManageController : BaseOrderController
    {
        public OrderManageController(ICacheService cache, UserManager<ApplicationUser> userManager) : base(cache,userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}