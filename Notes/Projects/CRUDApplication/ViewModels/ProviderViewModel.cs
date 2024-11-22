
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApplication.ViewModels
{
    public class ProviderViewModel
    {
        [Key]
        public int ProviderId { get; set; }

        public string DoctorName { get; set; }
        public string Treatment { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate {  get; set; }

        
    }
}
