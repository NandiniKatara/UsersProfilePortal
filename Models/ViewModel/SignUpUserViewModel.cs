using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace Portal.Models.ViewModel
{
    public class SignUpUserViewModel
    {
        //[Key]
        //public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter Valid Email")]



        public string Email { get; set; }

        public int ContactNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"(?=[A-Za-z0-9@#$%^&+!=]+$)^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$%^&+!=])(?=.{8,}).*", ErrorMessage = "Password must contain one digit from 1 to 9, one lowercase letter, one uppercase letter, one special character, no space, and it must be 8-16 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Re-Enter Password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = ("Confirm Password should be same as Password"))]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
