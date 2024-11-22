using System.ComponentModel.DataAnnotations;

namespace Assesment2DotNet.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public int Salary  { get; set; }
    }
}
