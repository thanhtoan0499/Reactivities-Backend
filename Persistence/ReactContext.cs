using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ReactContext : DbContext
    {
        public ReactContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=reactivities.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Activity> Activities   { get; set; }
    }
}
