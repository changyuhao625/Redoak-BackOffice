using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Stock.Controllers
{
    public class BaseStockController : BaseController
    {
        public BaseStockController(ICacheService cache) : base(cache)
        {
        }
    }
}