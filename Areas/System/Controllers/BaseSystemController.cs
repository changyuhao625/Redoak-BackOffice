using Redoak.Domain.Cache;

namespace Redoak.Backoffice.Areas.System.Controllers
{
    public abstract class BaseSystemController : BaseController
    {
        public BaseSystemController(ICacheService cache) : base(cache)
        {
        }
    }
}