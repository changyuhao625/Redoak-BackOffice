using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas
{
    public abstract class BaseController : Controller
    {
        public BaseController(ICacheService cache)
        {
            Cache = cache;
        }

        public ICacheService Cache { get; set; }

    }
}