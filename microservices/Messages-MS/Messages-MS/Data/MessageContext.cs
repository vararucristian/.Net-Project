using Microsoft.EntityFrameworkCore;

namespace Messages_MS.Data
{
    public class MessageContext : DbContext
    {
        public DbSet<Message> Messages { get; private set; }

        public MessageContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=Messages; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().HasKey(m => m.Id);

            modelBuilder.Entity<Message>()
                .Property(m => m.Id)
                .IsRequired()
                .HasMaxLength(36);

            modelBuilder.Entity<Message>()
                .Property(m => m.SenderId)
                .IsRequired()
                .HasMaxLength(36);

            modelBuilder.Entity<Message>()
                .Property(m => m.ReceiverId)
                .IsRequired()
                .HasMaxLength(36);

            modelBuilder.Entity<Message>()
                .Property(m => m.Text)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .Property(m => m.CreatedAt)
                .IsRequired();

        }


    }
}
