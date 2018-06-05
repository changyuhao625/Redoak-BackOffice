using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redoak.Backoffice.Areas.System.Models.PersonalProfile;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.System.Controllers
{
    [Authorize]
    [Area("System")]
    [Route("[controller]/[action]")]
    public class PersonalProfileController : BaseSystemController
    {
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public PersonalProfileController(ICacheService cache,
            UserManager<ApplicationUser> userManager,
            ILogger<PersonalProfileController> logger) : base(cache,userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return PartialView("_ChangePassword", new ChangePasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Model State Is Not Valid!");

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            var changePasswordResult =
                await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                return BadRequest(changePasswordResult.Errors.First().Description);
            }

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> PersonalProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            return PartialView("_PersonalProfile", Mapper.Map<PensonalProfileViewModel>(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePersonalProfile(PensonalProfileViewModel model)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                await TryUpdateModelAsync(user);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var identityError in result.Errors)
                    {
                        sb.AppendLine($"{nameof(identityError.Code)}:{identityError.Code},{nameof(identityError.Description)}:{identityError.Description}");
                    }
                    return BadRequest(sb.ToString());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}