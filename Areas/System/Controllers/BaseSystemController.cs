using Microsoft.AspNetCore.Identity;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.System.Controllers
{
    public abstract class BaseSystemController : BaseController
    {
        public BaseSystemController(ICacheService cache, UserManager<ApplicationUser> userManager) : base(cache,userManager)
        {
        }
    }
}