using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redoak.Backoffice.Areas.System.Models.UserManage;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.System.Controllers
{
    [Authorize]
    //[Route("[controller]/[action]")]
    public class UserManageController : BaseSystemController
    {
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManageController(ICacheService cache,
            UserManager<ApplicationUser> userManager,
            ILogger<UserManageController> logger) : base(cache)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PersonalProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(Mapper.Map<PensonalProfileModel>(user));
        }
    }
}