using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Redoak.Backoffice.Models;
using Microsoft.Extensions.Localization;
using Redoak.Backoffice.Middlewares;

namespace Redoak.Backoffice.Controllers
{
    [Authorize]
    [MiddlewareFilter(typeof(CultureMiddleware))]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public HomeController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var xx = _localizer["SystemTitle"];
            return View();
        }
    }
}
