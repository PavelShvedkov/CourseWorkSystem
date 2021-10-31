using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Servicies;
using BLL.Servicies;
using DAL.Fake.Repositories;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseWorkRepository courseWorks = new CourseWorkRepository();
            MentorRepository mentors = new MentorRepository();
            StudentRepository students = new StudentRepository();
            IMessageSender sender = new ConsoleMessageSender("dfjsfdnjnbjsndb;jndb");
            CourseWorkService service = new CourseWorkService(students,mentors,courseWorks,sender);

            var mentorss= service.GetMentors();
            var mentor = mentorss.First();
            var works = courseWorks.Get().Take(5);
            service.Publish(mentor,works);
            foreach (var m in mentorss)
            {
                Console.WriteLine($"{mentor.FullName}; {mentor.Id}; {mentor.Email} ");
            }
        }
    }
}