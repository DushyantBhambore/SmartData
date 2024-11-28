﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(16)]
        public string CardNumber { get; set; }

        [Required, MaxLength(5)]
        public string ExpiryDate { get; set; }

        [Required, MaxLength(3)]
        public string CVV { get; set; }
    }
}
