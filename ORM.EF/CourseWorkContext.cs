using Microsoft.EntityFrameworkCore;
using ORM.EF.Entities;

namespace ORM.EF
{
    public class CourseWorkContext: DbContext
    {
        public CourseWorkContext(DbContextOptions<CourseWorkContext> options) 
            : base(options)
        {
        }
        
        public DbSet<MentorEntity> Mentors { get; set; }

        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<CourseWorkEntity> CourseWorks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentEntity>()
                .HasOne(s => s.CourseWork)
                .WithOne(c => c.Student)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder
                .Entity<StudentEntity>()
                .Property(s => s.Course)
                .HasConversion<string>();

            modelBuilder
                .Entity<CourseWorkEntity>()
                .Property(c => c.Status)
                .HasConversion<string>();
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite(@"DataSource=first.db;");
        // }
    }
}