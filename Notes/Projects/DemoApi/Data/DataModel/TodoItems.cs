using System.ComponentModel.DataAnnotations;

namespace DemoApi.Data.DataModel
{
    public class TodoItems
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
