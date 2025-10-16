using System.ComponentModel.DataAnnotations;

namespace LogInAuthService.ModelView
{
    public class RegistrationMV
    {

        //User Details
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }

        //User Credentials
        public string Username { get; set; }
        public string Password { get; set; }

     // Account Details
        public string accountNumber { get; set; }
        public string bankName { get; set; }
        public string bankCode { get; set; }
        public string branch { get; set; }
        public string ifscCode { get; set; }
        public string upiId { get; set; }
        public string dateOfExpiry { get; set; }
        public List<string> accountType { get; set; }
        public string nominee { get; set; }
        public string relationWithNominee { get; set; }
        public Boolean isActive { get; set; }
        public int balance { get; set; }

        // Address
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public List<string> roles { get; set; }

    }
}
