using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Redoak.Backoffice.Areas.Customer.Models.CustomerManage
{
    public class QueryModel
    {
        [Display(Name = "客戶名稱")] public string Name { get; set; }
        [Display(Name = "盤口")] public int RegionId { get; set; }
        public SelectList RegionSelectList { get; set; }
    }
}