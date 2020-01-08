using Microsoft.EntityFrameworkCore;

namespace Likes_MS.Data
{
    public class LikeContext : DbContext
    {
        public DbSet<Like> Likes { get; private set; }
        
        public LikeContext(DbContextOptions<LikeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>().HasKey(l => l.Id);
            modelBuilder.Entity<Like>()
                .Property(l => l.Id)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Like>()
                .Property(l => l.PersonId)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Like>()
               .Property(l => l.PetId)
               .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Like>()
               .Property(l => l.PersonLike)
               .IsRequired().HasMaxLength(2);

            modelBuilder.Entity<Like>()
               .Property(l => l.PetLike)
               .IsRequired().HasMaxLength(2);



        }

    }
}
