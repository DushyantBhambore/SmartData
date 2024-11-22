using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Data.DataModel
{
    public class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }
        [Required]
        [Display(Name ="Enter Name =",Prompt ="Jhone Doe")]
        public string StudentName { get; set; }
        [EmailAddress]
        [Display(Name ="Enter Email",Prompt ="abc@gmail.com")]
        public string StudentEmail { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="Select Date Of BIrth ")]
        public DateTime DateOfBirth { get; set; }
    }
}
