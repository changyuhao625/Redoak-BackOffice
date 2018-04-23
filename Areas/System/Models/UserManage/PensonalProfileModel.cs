using System.ComponentModel.DataAnnotations;

namespace Redoak.Backoffice.Areas.System.Models.UserManage
{
    public class PensonalProfileModel
    {
        [Required] [Display(Name = "使用者名稱")] public string Username { get; set; }

        [Required] [Display(Name = "帳號")] public string UserId { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Phone] [Display(Name = "電話號碼")] public string PhoneNumber { get; set; }
    }
}