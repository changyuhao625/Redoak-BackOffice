using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redoak.Backoffice.Models.AccountViewModels;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.Enum;
using Redoak.Domain.Model.ViewModel;
using Redoak.Domain.Service;

namespace Redoak.Backoffice.Areas.System.Controllers
{
    [Area("System")]
    [Route("[controller]/[action]")]
    [Authorize(Roles = nameof(RedoakEnum.RoleEnum.Administrator))]
    public class AccountController : BaseSystemController
    {
        private readonly ILogger _logger;
        private readonly RedoakSignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(RedoakSignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ICacheService cache,
            ILogger<AccountController> logger) : base(cache,userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Id = model.UserId,
                    UserName = model.UserName,
                    Email = model.Email
                };
                var findById = await _userManager.FindByIdAsync(model.UserId);
                if (findById != null) return BadRequest("Duplicate User Id!");

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    return Ok();
                }

                return BadRequest(result.Errors);
            }

            return BadRequest(ModelState.Values.Select(x => x.Errors));
        }
    }
}