using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KendoGridBinder.ModelBinder.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Backoffice.Areas.Customer.Models.CustomerManage;
using Redoak.Domain.Cache;
using Redoak.Domain.Interface;
using Redoak.Domain.Model.Dto;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    [Route("[controller]/[action]")]
    public class CustomerManageController : CustomerBaseController
    {
        public CustomerManageController(ICacheService cache, UserManager<ApplicationUser> userManager, ICustomerManageService customerManageService) : base(cache,
            userManager)
        {
            CustomerManageService = customerManageService;
        }

        public ICustomerManageService CustomerManageService { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResultPartial()
        {
            return PartialView("_ResultPartial");
        }

        public async Task<IActionResult> QueryData(KendoGridMvcRequest request, QueryModel model)
        {
            var dto = Mapper.Map<KendoGridMvcRequest, CustomerQueryDto>(request);
            Mapper.Map(model, dto);
            var result = await CustomerManageService.Query(dto);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial",new CreateModel());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await CustomerManageService.Edit(id);
            var model = Mapper.Map<Domain.Model.Models.Customer, CreateModel>(customer);
            return PartialView("_CreatePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<Domain.Model.Models.Customer>(model);

                await CustomerManageService.CreateOrEdit(customer);
                return Ok();
            }


            return BadRequest(GetModelStateMsg());
        }
    }
}