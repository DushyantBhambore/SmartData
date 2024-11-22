using CRUDApplication.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApplication.Data.DataModels
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }
        public string DoctorName { get; set; }
        public string Treatment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
