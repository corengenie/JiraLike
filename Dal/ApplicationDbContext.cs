using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) => Database.Migrate();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=JiraLike;Integrated security=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(u => u.Login).IsRequired();
                e.Property(u => u.Password).IsRequired();
            });
        }
    }
}