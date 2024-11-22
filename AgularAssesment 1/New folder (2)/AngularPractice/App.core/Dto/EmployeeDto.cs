using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace App.core.Dto
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string PositionTitle { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        //[Range(minimum: 0, maximum: 10)]
     
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateofHire { get; set; }
        public double Salary { get; set; }
        public string EmergencyContactName { get; set; }
      
        //[MinLength(0),MaxLength(10)]
        public long EmergencyContactNumber { get; set; }
        public bool MaritalStatus { get; set; }
        public string EducationLevel { get; set; }
        public string PreviousEmployer { get; set; }
        public bool IsExpericed { get; set; }
        public string Skills { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public bool IsDelete { get; set; } = true;
        public bool IsActive { get; set; } = false;
    }
}
