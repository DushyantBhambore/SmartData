using System.ComponentModel.DataAnnotations;

namespace Doamin
{
    public class User : AuditableEnity
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string   LastName     { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
