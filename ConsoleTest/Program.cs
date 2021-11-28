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
            // CourseWorkRepository courseWorks = new CourseWorkRepository();
            // MentorRepository mentors = new MentorRepository();
            // StudentRepository students = new StudentRepository();
            // IMessageSender sender = new ConsoleMessageSender("QWEERTREBDBNBDBBSDJBNDJ SD");
            // CourseWorkService service = new CourseWorkService(students,mentors,courseWorks,sender);
            //
            // var mentorss= service.GetMentors();
            // var mentor = mentorss.First();
            // var studentss = service.GetStudents();
            // var works = service.GetCourseWorks().Take(5);
            //
            // service.Publish(mentor,works);
            //
            // //foreach (var s in studentss)
            // //{
            // //    Console.WriteLine($"{s.Course};");
            // //}
            //
            // var courseWork = works.First();
            //
            // var student = studentss.First();
            //
            // service.Select(student, courseWork);
            //
            // // foreach (var work in works)
            // // {
            // //  Console.WriteLine($"Title: {work.Title}; Status: {work.Status};");
            // // }
            //
            // service.Approve(mentor, courseWork);
            //
            // //foreach (var work in works)
            // //{
            // //    Console.WriteLine($"Title: {work.Title}; Status: {work.Status};");
            // //}
        }
    }
}