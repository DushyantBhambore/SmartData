using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dtos
{
    public class PatientDto
    {
        public int PId { get; set; }
        public int UserId { get; set; }
        public string AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int Country { get; set; }
        public string Gender { get; set; }

        public int State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime AppoinentmentDate { get; set; }
        public bool IsACtive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
