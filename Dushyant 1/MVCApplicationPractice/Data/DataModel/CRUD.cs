using System.ComponentModel.DataAnnotations;

namespace MVCApplicationPractice.Data.DataModel
{
    public class CRUD
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [MaxLength(10)]
        public string Number { get; set; }
    }
}
