using System.ComponentModel.DataAnnotations;

namespace Redoak.Backoffice.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
