using System.ComponentModel.DataAnnotations;

namespace Domain
{
  public class Employee
  {
    [Key]
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; }
    public string PositionTitle { get; set; }
    public DateTime DateofBirth { get; set; }
    public string Gender { get; set; }
    public string EmailAddress { get; set; }
    //[Range(minimum: 0, maximum: 10)]
    [Range(1000000000, 9999999999, ErrorMessage = "Emergency contact number must be exactly 10 digits.")]
    public long PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime DateofHire { get; set; }
    public double Salary { get; set; }
    public string EmergencyContactName { get; set; }
    [Range(1000000000, 9999999999, ErrorMessage = "Emergency contact number must be exactly 10 digits.")]
    //[MinLength(0),MaxLength(10)]
    public long EmergencyContactNumber { get; set; }
    public bool MaritalStatus { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string EducationLevel { get; set; }
    public string PreviousEmployer { get; set; }
    public bool IsExpericed { get; set; }
    public string Skills { get; set; }

  }
}
