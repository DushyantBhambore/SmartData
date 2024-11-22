using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match"), Display(Name = "Password")]
        public string ConfirmPassword { get; set; }
        public List<Patient> Patients { get; set; }

    }
}
