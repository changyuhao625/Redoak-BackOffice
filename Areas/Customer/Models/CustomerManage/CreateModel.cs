using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Redoak.Backoffice.Areas.Customer.Models.CustomerManage
{
    public class CreateModel
    {
        [Display(Name = "客戶名稱")] public string Name { get; set; }

        [Display(Name = "聯繫人員")] public string ContactPerson { get; set; }

        [Display(Name = "地址")] public string Address { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Display(Name = "聯繫電話")] [Phone] public string ContactPhone { get; set; }

        [Display(Name = "盤口")] public int RegionId { get; set; }
        public SelectList RegionSelectList { get; set; }
    }
}