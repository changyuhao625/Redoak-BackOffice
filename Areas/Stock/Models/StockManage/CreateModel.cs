using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Redoak.Backoffice.Areas.Stock.Models.StockManage
{
    public class CreateModel
    {
        [Display(Name = "商品名稱")] public string Name { get; set; }

        public SelectList CategoryList { get; set; }
        [Display(Name = "商品類別")] public int CategoryId { get; set; }
        public IList<string> GoodSpecs { get; set; }
    }
}