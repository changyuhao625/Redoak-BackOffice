using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Controllers
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