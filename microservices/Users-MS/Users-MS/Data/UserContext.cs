using Microsoft.EntityFrameworkCore;

namespace Users_Ms.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; private set; }
        public UserContext(DbContextOptions<UserContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;  Database=Users;  Trusted_Connection=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired().HasMaxLength(20);


            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired().HasMaxLength(20);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.UserName)
                .HasName("AlternateKey_UserName");

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Email)
                .HasName("AlternateKey_Email");

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired().HasMaxLength(50);

        }


    }
}
