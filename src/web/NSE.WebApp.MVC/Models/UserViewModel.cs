using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Social Number")]
        public string SocialNumber { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "Invalid format of field {0}")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} should be between {2} and {1} chars", MinimumLength = 6)]
        public string Password { get; set; }

        [DisplayName("Confirm your password")]
        [Compare("Password", ErrorMessage = "The password must match.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserLogin
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "Invalid format of field {0}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} should be between {2} and {1} chars", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class UserLoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }

    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}