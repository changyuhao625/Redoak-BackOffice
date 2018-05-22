using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Redoak.Backoffice.Areas.Stock.Models.StockManage
{
    public class QueryModel
    {
        public QueryModel()
        {
            CategoryList = new SelectList(new List<SelectListItem>());
        }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        [Display(Name = "商品名稱")]
        public string Name { get; set; }

        [Display(Name = "商品類別")]
        public int CategoryId { get; set; }

        [Display(Name = "商品編號")]
        public int Id { get; set; }

        public SelectList CategoryList { get; set; }
    }
}