using Microsoft.VisualStudio.Services.Account;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string? ProfileSocialMedia1 { get; set; } 
        public string? ProfileUrl1 { get; set; } 
        public string? ProfileSocialMedia2 { get; set; } 
        public string? ProfileUrl2 { get; set; }

        public string? ProfileSocialMedia3 { get; set; } 
        public string? ProfileUrl3 { get; set; }

        public string? ProfileSocialMedia4 { get; set; } 
        public string? ProfileUrl4 { get; set; }
        public int? UserId { get; set; }

    }
}