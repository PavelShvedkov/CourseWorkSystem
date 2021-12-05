using Microsoft.EntityFrameworkCore;

namespace Web.UI.Infrastructure
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role[]
            {
                new Role { Id = 1, Name = "Mentor" },
                new Role { Id = 2, Name = "Student" }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}