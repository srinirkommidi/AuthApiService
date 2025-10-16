using LogInAuthService.Models;
using LogInAuthService.ModelView;
using Microsoft.EntityFrameworkCore;

namespace LogInAuthService.Data
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }  
        public DbSet<Address> Address { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserDetails)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserDetails>(ud => ud.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AccountDetails)
                .WithOne(ad => ad.User)
                .HasForeignKey<AccountDetails>(ad => ad.UserId);



        }
       
        
    }
}
