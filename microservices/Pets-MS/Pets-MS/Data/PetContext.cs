using Microsoft.EntityFrameworkCore;

namespace Pets_MS.Data
{
    public class PetContext : DbContext
    {
        public DbSet<Pet> Pets { get; private set; }
        public DbSet<Location> Locations { get; private set; }
        public PetContext(DbContextOptions<PetContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;  Database=Pets;  Trusted_Connection=True;");
            }
*/        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasKey(p => p.Id);

            modelBuilder.Entity<Pet>()
                .Property(p => p.Id)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Pet>()
                .Property(p => p.Description)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Pet>()
               .Property(p => p.Genre)
               .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Pet>()
               .Property(p => p.Username)
               .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Pet>()
               .Property(p => p.Name)
               .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Pet>()
               .Property(p => p.Species)
               .IsRequired().HasMaxLength(36);
            modelBuilder.Entity<Pet>()
               .Property(p => p.BirthDate)
               .IsRequired();

            modelBuilder.Entity<Pet>()
                 .HasOne<Location>(p => p.Location)
                 .WithMany(l => l.Pets);

            modelBuilder.Entity<Location>().HasKey(l => l.Id);

            modelBuilder.Entity<Location>()
               .Property(l => l.Id)
               .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Location>()
               .Property(l => l.Latitude)
               .IsRequired();

            modelBuilder.Entity<Location>()
               .Property(l => l.Longitude)
               .IsRequired();

            modelBuilder.Entity<Location>()
                .HasMany<Pet>(l => l.Pets)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            modelBuilder.Entity<Location>()
               .HasAlternateKey(l => new {l.Latitude, l.Longitude })
               .HasName("AlternateKey_Latitude_Longitude");


        }

    }
}
