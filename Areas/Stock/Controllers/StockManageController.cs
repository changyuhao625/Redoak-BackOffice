using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KendoGridBinder.ModelBinder.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Redoak.Backoffice.Areas.Stock.Models.StockManage;
using Redoak.Domain.Cache;
using Redoak.Domain.Interface;
using Redoak.Domain.Model.Dto;
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

        public IActionResult ResultPartial()
        {
            return PartialView("_ResultPartial");
        }

        public async Task<IActionResult> QueryData(KendoGridMvcRequest request, QueryModel model)
        {
            var dto = Mapper.Map<KendoGridMvcRequest, StockQueryDto>(request);
            Mapper.Map(model, dto);
            var result = await _service.Query(dto);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial", new EditModel
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
        public async Task<IActionResult> Create(EditModel model)
        {
            try
            {
                var entity = Mapper.Map<Goods>(model);
                entity.UpdateUser = UserId;
                await _service.CreateOrEdit(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(EditModel model)
        {
            try
            {
                var goods = await _service.Edit(model.Id);
                var editModel = Mapper.Map<EditModel>(goods);
                //todo: get from cache
                editModel.CategoryList = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "9",
                        Text = "All"
                    }
                }, "Value", "Text");
                return PartialView("_CreatePartial", editModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}