using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Backoffice.Areas.Customer.Models.CustomerManage;
using Redoak.Domain.Cache;
using Redoak.Domain.Interface;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    [Route("[controller]/[action]")]
    public class CustomerManageController : CustomerBaseController
    {
        public CustomerManageController(ICacheService cache, UserManager<ApplicationUser> userManager) : base(cache,
            userManager)
        {
        }

        public ICustomerManageService CustomerManageService { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Query(QueryModel model)
        {
            return PartialView("_QueryPartial");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<Domain.Model.Models.Customer>(model);

                await CustomerManageService.Create(customer);
                return Ok();
            }

            return BadRequest();
        }
    }
}