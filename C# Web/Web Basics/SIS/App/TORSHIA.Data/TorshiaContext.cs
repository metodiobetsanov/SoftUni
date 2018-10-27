

namespace TORSHIA.Data
{
    using Microsoft.EntityFrameworkCore;
    using TORSHIA.Models;

    public class TorshiaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.; Database=Torshia; Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskSector> TasksSectors { get; set; }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
