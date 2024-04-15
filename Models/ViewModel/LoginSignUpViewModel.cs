using System.ComponentModel.DataAnnotations;

namespace Portal.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        [Required]
        public string Username { get; set; }
        //  public string Email { get; set; }
        //public long ContactNumber { get; set; }

        [Required]
        public string Password { get; set; }
        //  public string ConfirmPassword { get; set; }
        //  public bool IsActive { get; set; }

        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }

    }
}
