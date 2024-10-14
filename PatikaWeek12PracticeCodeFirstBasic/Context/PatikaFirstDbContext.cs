using Microsoft.EntityFrameworkCore;
using PatikaWeek12PracticeCodeFirstBasic.Entities;

namespace PatikaWeek12PracticeCodeFirstBasic.Context
{
    public class PatikaFirstDbContext : DbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Game> Games => Set<Game>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KUTPERI\SQLEXPRESS; Database=PatikaCodeFirstDb1; TrustServerCertificate=true; Trusted_connection=true");


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movies");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Genre).IsRequired().HasMaxLength(50);

            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Games");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Platform).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Rating).IsRequired();
            });

            
        }
    }
}
