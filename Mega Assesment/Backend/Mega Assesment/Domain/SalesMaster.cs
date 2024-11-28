using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SalesMaster
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string InvoiceId { get; set; }
        [Required]
        public int UserId { get; set; }

        public DateTime InvoiceDate { get; set; }

        [Required]
        public float Subtotal { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public int DeliveryZipcode { get; set; }

        [Required]
        public int DeliveryState { get; set; }

        [Required]
        public int DeliveryCountry { get; set; }

    }
}
