using System.ComponentModel.DataAnnotations;

namespace AccountManager.Web.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(256)]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
    }
}
