using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Model.Dto
{
    public class Villadto
    {
        public int Id { get; set; }
        [Required]

        public string Names { get; set; }

        public int  sqft  { get; set; }
        public int  Occupancy   { get; set; }

    }
}
