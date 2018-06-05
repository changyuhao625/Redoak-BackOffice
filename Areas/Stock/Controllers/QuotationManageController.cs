using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.Stock.Controllers
{
    public class QuotationManageController : BaseStockController
    {
        public QuotationManageController(ICacheService cache, UserManager<ApplicationUser> userManager) : base(cache,userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}