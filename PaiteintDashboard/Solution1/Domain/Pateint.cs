using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pateint
    {
        [Key]
        [Required]
        public int PId { get; set; }
        [Required]
        public string PateintId { get; set; }
        [ForeignKey("Agent")]
        public int AId { get; set; }
        public string AgentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email  { get; set; }

        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "contact number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Gender  { get; set; }
        [Required]
        public string AddressLine1   { get; set; }
        [Required]
        public string AddressLine2  { get; set; }
        [Required]
        public int Countries { get; set; }
        [Required]
        public int States { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppoinmentDate { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        public Agent Agent { get; set; }





    }
}
