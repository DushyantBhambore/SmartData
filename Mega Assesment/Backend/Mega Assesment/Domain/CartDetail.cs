﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CartDetail
    {
        [Key]
        public int Id { get; set; }

        // Master Cart Table PK 
        [Required]
        public int CartId { get; set; }

        [ForeignKey("CartId")]
        public CartMaster CartMaster { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Qty { get; set; }
    }
}
