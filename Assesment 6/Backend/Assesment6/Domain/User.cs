using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
