using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="* Name can't be blank")]
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }


        public string? Phone { get; set; }
        public string? Facebook { get; set; }
        public string? LinkedIn { get; set; }
        public string? Github { get; set; }
        public string? Twitter { get; set; }
        




    }
}
