using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required, MaxLength(50)]
        public string CountryName { get; set; }

        [Required, MaxLength(50)]
        public string sortname { get; set; }
        [Required, MaxLength(50)]
        public int phonecode { get; set; }
    }
}
