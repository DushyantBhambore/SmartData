using Domain;

namespace App.Core.Model
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }

    }
}
