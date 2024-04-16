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

        public static implicit operator Microsoft.VisualStudio.Services.Account.AccountUser?(AccountUser? v)
        {
            throw new NotImplementedException();
        }
    }
}
