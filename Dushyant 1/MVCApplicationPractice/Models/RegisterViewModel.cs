using System.ComponentModel.DataAnnotations;

namespace MVCApplicationPractice.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="The Password is does not match ")]
        public string? ConfirmPassowrd { get; set; }
    }
}
