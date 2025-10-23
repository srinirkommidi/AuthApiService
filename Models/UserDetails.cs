using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LogInAuthService.Models
{
   
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public UserDetails? UserDetails { get; set; }
        public AccountDetails? AccountDetails { get; set; }
        public Address? Address { get; set; }
       
    }

    public class Credentials
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public List<string> roles { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string country { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class AccountDetails{
        [Key]
        public int Id { get; set; }
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
        public int UserId { get; set; }
        public User User { get; set; }
    }

    
    public enum AccountType
    {
        Saving,
        Checking,
        Loan,
        Business
    }

    public enum NomineeRelation
    {
        Father,
        Mother,
        Brother,
        Sister,
        Spouse,
        Child,
        Husband,
    }

    public enum Roles
    {
        User,
        Admin,
        Merchant
    }

}
