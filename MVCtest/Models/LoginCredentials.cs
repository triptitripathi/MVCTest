using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Xunit;

namespace MVCtest.Models
{
    public class LoginCredentials
    {
        
        [Required(ErrorMessage = "Please enter Email Id")]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set;}

      
        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set;}

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set;}
    }
}
