﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class States
    {
        [Key]
        public int StateId { get; set; }
        public string  StateName { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Countries Country { get; set; }

    }
}
