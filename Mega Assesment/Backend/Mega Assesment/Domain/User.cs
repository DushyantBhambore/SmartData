using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [Required, MaxLength(15)]
        public string Mobile { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Zipcode { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int CountryId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

    }
}
