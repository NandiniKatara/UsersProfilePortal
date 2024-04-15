using Microsoft.EntityFrameworkCore;
using Portal.Models;
using Portal.Models.Account;

namespace Portal.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<AccountUser> AccountUsers { get; set; }


    }
}
