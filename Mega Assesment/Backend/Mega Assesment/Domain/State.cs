using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class State
    {
            [Key]
            public int Id { get; set; }

            [Required, MaxLength(50)]
            public string StateName { get; set; }

            [Required]
            public int CountryId { get; set; }

            [ForeignKey("CountryId")]
            public Country Country { get; set; }
    }
}
