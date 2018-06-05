using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Backoffice.Areas.System.Models.UserRole;
using Redoak.Domain.Cache;
using Redoak.Domain.Interface;
using Redoak.Domain.Model.Enum;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.System.Controllers
{
    [Area("System")]
    [Route("[controller]/[action]")]
    [Authorize(Roles = nameof(RedoakEnum.RoleEnum.Administrator))]
    public class UserRoleController : BaseSystemController
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IUserService _userService;

        public UserRoleController(ICacheService cache,
            IUserRoleService userRoleService,
            IUserService userService, UserManager<ApplicationUser> userManager) : base(cache,userManager)
        {
            _userRoleService = userRoleService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new UserRoleModel
            {
                Users = await _userService.GetUser()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = nameof(RedoakEnum.RoleEnum.Administrator))]
        public async Task<IActionResult> EditUserRole(string userId)
        {
            var data = await _userRoleService.GetEditUserAsync(userId);
            var model = new EditUserRoleViewModel
            {
                UserInfo = data.userInfo,
                RoleList = await Cache.Roles(),
                UserName = data.userInfo.UserName,
                UserId = data.userInfo.Id,
                UserRoles = data.Roles
            };

            return PartialView(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUser(EditUserRoleViewModel model)
        {
            try
            {
                var result = await this._userRoleService.SaveUser(model.UserId, model.UserRoleValue);
                if (result.Succeeded) return Json("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json("Fail");
            }

            return Json("Fail");
        }

    }
}