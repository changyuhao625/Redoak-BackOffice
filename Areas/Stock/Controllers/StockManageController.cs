using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Redoak.Backoffice.Areas.Stock.Models.StockManage;
using Redoak.Domain.Cache;
using Redoak.Domain.Interface;
using Redoak.Domain.Model.Models;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.Stock.Controllers
{
    [Authorize]
    [Area("Stock")]
    [Route("[controller]/[action]")]
    public class StockManageController : BaseStockController
    {
        private readonly IStockManageService _service;

        public StockManageController(ICacheService cache, IStockManageService service, UserManager<ApplicationUser> userManager) : base(cache, userManager)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(new QueryModel
            {
                CategoryList = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "9",
                        Text = "All"
                    }
                }, "Value", "Text")
            });
        }

        public IActionResult Query()
        {
            return PartialView("_QueryPartial");
        }

        public async Task<IActionResult> QueryData(QueryModel model)
        {
            var result = await _service.Query();
            return Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial", new CreateModel
            {
                CategoryList = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "9",
                        Text = "All"
                    }
                }, "Value", "Text")
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            try
            {
                var entity = Mapper.Map<Goods>(model);
                entity.UpdateUser = UserId;
                entity.UpdateDate = DateTime.Now;
                await _service.Create(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}