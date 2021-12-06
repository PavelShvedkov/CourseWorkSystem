using System.Collections;
using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Servicies
{
    public interface ICourseWorkService
    {
        IEnumerable<CourseWork> GetCourseWorks();
        IEnumerable<CourseWork> GetCourseWorks(Mentor mentor);
        IEnumerable<Mentor> GetMentors();
        IEnumerable<Student> GetStudents();

        void Select(Student student, CourseWork courseWork);
        void Approve(Mentor mentor, CourseWork courseWork);
        void Decline(Mentor mentor, CourseWork courseWork);
        void Add(CourseWork courseWork);
    }
}