using System.ComponentModel.DataAnnotations;

namespace StudentProject.Model
{
    public class PateintsModel
    {
        [Key]
        public int Pateint_id { get; set; }
        public string PateintName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int Insurance_id { get; set; }
    }
}
