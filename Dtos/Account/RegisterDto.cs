using System.ComponentModel.DataAnnotations;

namespace resturant.api.Dtos.Account
{
    public class RegisterDto
    {
        public string? UserName {get; set;}
        [EmailAddress]
        public string Email {get; set;}
        public string Password {get; set;}
        [Compare(nameof(Password))]
        public string ConfirmPassword {get; set;}
    }
}