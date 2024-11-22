using System.ComponentModel.DataAnnotations;

namespace CRUDApplication.ViewModels
{
    public class PateintViewModel
    {
        [Key]
        public int PateintId { get; set; }
        public string PateintfirstName { get; set; }

        public string PateintlastName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
