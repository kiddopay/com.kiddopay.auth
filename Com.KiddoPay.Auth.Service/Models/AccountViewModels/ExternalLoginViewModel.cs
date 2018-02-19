using System.ComponentModel.DataAnnotations;

namespace Com.KiddoPay.Auth.Service.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
