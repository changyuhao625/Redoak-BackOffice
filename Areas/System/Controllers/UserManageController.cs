using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.System.Controllers
{
    [Authorize]
    [Area("System")]
    [Route("[controller]/[action]")]
    public class UserManageController : BaseSystemController
    {
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManageController(ICacheService cache,
            UserManager<ApplicationUser> userManager,
            ILogger<UserManageController> logger) : base(cache,userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}