using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(1000000000, 9999999999, ErrorMessage = "Emergency contact number must be exactly 10 digits.")]
        public long PhoneNumber { get; set; }
        public string CustomerAddressLine1 { get; set; }
        public string CustomerAddressLine2 { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public long Income { get; set; }
        public DateTime PurchaseHistory { get; set; }
        public string Feedback { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferralSource { get; set; }
        public string CompanyName { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public string SocialMediaHandle { get; set; }
        public long CreditScore { get; set; }

    }
}
