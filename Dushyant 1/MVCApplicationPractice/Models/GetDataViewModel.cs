using System.ComponentModel.DataAnnotations;

namespace MVCApplicationPractice.Models
{
    public class GetDataViewModel
    {
        [Display(Name ="Full Name",Prompt ="Enter Full Name")]
        public string? Name { get; set; }
        [Range(maximum:100,minimum:10,ErrorMessage ="Invalid Age")]
        public int Age { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [MaxLength(10,ErrorMessage ="Invalid Mobile Number ")]
        public string? PhoneNumber { get; set; }
    }
}
