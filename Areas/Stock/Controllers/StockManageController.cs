using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Redoak.Backoffice.Areas.Stock.Models.StockManage;
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

            return View(new QueryModel()
            {
                CategoryList = new SelectList(new List<SelectListItem>()
                {
                   new SelectListItem()
                   {
                       Value="0",
                       Text="All"
                   }
                }, "Value", "Text")
            });
        }
    }
}