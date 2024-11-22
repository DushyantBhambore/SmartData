using System.ComponentModel.DataAnnotations;

namespace CRUDApplication.Data.DataModels
{
    public class Pateint
    {
        [Key]
        public int PateintId { get; set; }
        public string PateintfirstName { get; set; }

        public string PateintlastName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
