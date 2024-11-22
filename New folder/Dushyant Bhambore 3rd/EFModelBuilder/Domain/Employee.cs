using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain
{
    // Child Tables
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public int Salary  { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }




    }
}
