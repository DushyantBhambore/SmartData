using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.Dto
{
    public class PateintDto
    {
        public int PateintId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        //[Range(minimum: 0, maximum: 10)]
       
        public long PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PostalCode { get; set; }
        public double Salary { get; set; }
        public string EmergencyContactName { get; set; }
  
        public long EmergencyContactNumber { get; set; }
        public bool MaritalStatus { get; set; }
        public string InsuranceProvider { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public string PrimaryPhysician { get; set; }
        public string Allergies { get; set; }
        public decimal Height { get; set; }
        public int Weight { get; set; }
        public int BloodPressure { get; set; }
        public string BloodGroup { get; set; }
        public DateTime LastVisitDate { get; set; }
        public DateTime NextAppointmentDate { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
    }
}
