using System.ComponentModel.DataAnnotations;

namespace Portal.Models.ViewModel
{
    public class ChangePasswordViewModel
    {
      
        [Required(ErrorMessage = "Please Enter New Password")]
        [RegularExpression(@"(?=[A-Za-z0-9@#$%^&+!=]+$)^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$%^&+!=])(?=.{8,}).*", ErrorMessage = "Password must contain one digit from 1 to 9, one lowercase letter, one uppercase letter, one special character, no space, and it must be 8-16 characters long.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please Re-Enter New Password")]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = ("Confirm Password should be same as New Password"))]
        public string ConfirmNewPassword { get; set; }
    }
}
