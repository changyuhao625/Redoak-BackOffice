using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Redoak.Backoffice.Areas.Stock.Models.StockManage;
using Redoak.Domain.Cache;
using Redoak.Domain.Interface;

namespace Redoak.Backoffice.Areas.Stock.Controllers
{
    [Authorize]
    [Area("Stock")]
    [Route("[controller]/[action]")]
    public class StockManageController : BaseStockController
    {
        private readonly IStockManageService _service;

        public StockManageController(ICacheService cache, IStockManageService service) : base(cache)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(new QueryModel
            {
                CategoryList = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "0",
                        Text = "All"
                    }
                }, "Value", "Text")
            });
        }

        public IActionResult Query()
        {
            return PartialView("_QueryPartial");
        }

        public async Task<IActionResult> QueryData(QueryModel model)
        {
            var result = await _service.Query();
            return Json(result);
        }
    }
}