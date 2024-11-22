using System.ComponentModel.DataAnnotations;

namespace MVCApplicationPractice.Models
{
    public class CRUDViewModel
    {
#pragma warning disable
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [MaxLength(10)]
        public string Number { get; set; }
    }
}
