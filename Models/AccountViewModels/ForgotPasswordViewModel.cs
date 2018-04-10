using System.ComponentModel.DataAnnotations;

namespace Redoak.Backoffice.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
