using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User : AuditableEntity
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
