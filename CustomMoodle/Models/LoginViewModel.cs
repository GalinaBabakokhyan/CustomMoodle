using System.ComponentModel.DataAnnotations;

namespace CustomMoodle.Models
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}