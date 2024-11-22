using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Agent
    {
        [Key]
        [Required]
        public int AId { get; set; }
        [Required]
        public string? AgentId { get; set; }
        [Required]
        public string? FirstName  { get; set; }
        [Required]
        public string? LastName  { get; set; }
        [Required]
        public string? Email  { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public ICollection<Pateint> Patients { get; set; }
    }
}
