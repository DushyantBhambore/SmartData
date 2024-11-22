using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match"), Display(Name = "Password")]
        public string ConfirmPassword { get; set; }
    }
}
