using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Order.Controllers
{
    public class OrderManageController : BaseOrderController
    {
        public IActionResult Index()
        {
            return View();
        }

        public OrderManageController(ICacheService cache) : base(cache)
        {
        }
    }
}