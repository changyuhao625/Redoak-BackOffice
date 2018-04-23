using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.Order.Controllers
{
    public abstract  class BaseOrderController : BaseController
    {
        protected BaseOrderController(ICacheService cache) : base(cache)
        {
        }
    }
}