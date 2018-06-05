using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.Report.Controllers
{
    [Authorize]
    [Area("Stock")]
    [Route("[controller]/[action]")]
    public class OrderReportController : BaseReportController
    {
        public OrderReportController(ICacheService cache, UserManager<ApplicationUser> userManager) : base(cache,userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}