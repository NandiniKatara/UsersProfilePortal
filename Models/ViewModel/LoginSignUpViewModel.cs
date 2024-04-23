using System.ComponentModel.DataAnnotations;

namespace Portal.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        [Required]
        public string Username { get; set; }
       
        [Required]
        public string Password { get; set; }
        
        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }

    }
}
