using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Stock.Controllers
{
    public class StockManageController : BaseStockController
    {
        public IActionResult Index()
        {
            return View();
        }

        public StockManageController(ICacheService cache) : base(cache)
        {
        }
    }
}