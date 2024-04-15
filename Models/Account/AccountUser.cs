using System.ComponentModel.DataAnnotations;

namespace Portal.Models.Account
{
    public class AccountUser
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }        
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemember { get; set; }
        public long? ContactNumber { get; set; }
        public string? Facebook {  get; set; }
        public string? LinkedIn { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? Hobbies { get; set;}
        public DateOnly? DateOfBirth { get; set; }
    }
}
