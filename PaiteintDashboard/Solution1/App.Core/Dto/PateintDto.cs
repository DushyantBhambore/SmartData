using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dto
{
    public class PateintDto
    {
        public int PId { get; set; }
        public int AId { get; set; }
        public string AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int Countries { get; set; }
        public int States { get; set; }
        public string City { get; set; }
        public DateTime AppoinmentDate { get; set; }
        public string BloodGroup { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;

    }
}
