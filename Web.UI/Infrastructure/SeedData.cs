using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ORM.EF;
using ORM.EF.Entities;

namespace Web.UI.Infrastructure
{
    public static class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CourseWorkContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<CourseWorkContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Mentors.Any())
            {
                List<MentorEntity> mentors = new Faker<MentorEntity>("en")
                    .RuleFor(x => x.FullName, f => f.Name.FullName())
                    .RuleFor(x => x.Email, f => f.Internet.Email())
                    .Generate(5).ToList();
                context.Mentors.AddRange(mentors);
                context.SaveChanges();
            }

            if (!context.Students.Any())
            {
                List<StudentEntity> students = new Faker<StudentEntity>("en")
                    .RuleFor(x => x.FullName, f => f.Name.FullName())
                    .RuleFor(x => x.Email, f => f.Internet.Email())
                    .RuleFor(x => x.Course, f => f.PickRandom<CourseEntity>())
                    .Generate(5).ToList();
                context.Students.AddRange(students);
                context.SaveChanges();
            }

            if (!context.CourseWorks.Any())
            {
                List<CourseWorkEntity> courseWorks = new Faker<CourseWorkEntity>("en")
                    .RuleFor(x => x.Title, f => f.Lorem.Sentences(1))
                    .RuleFor(x => x.Status, f => f.Random.Enum(StatusEntity.ConfirmationAwaiting/*, StatusEntity.Appointed*/))
                    .Generate(5).ToList();
                context.CourseWorks.AddRange(courseWorks);
                context.SaveChanges();
            }
        }
    }
}
