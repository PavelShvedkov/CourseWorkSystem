using System;
using BLL.Interface.Servicies;

namespace BLL.Interface.Entities
{
    public sealed class Student : IEquatable<Student>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Course Course { get; set; }
        public CourseWork CourseWork { get; set; }

        public void SelectCourseWork(CourseWork courseWork, IMessageSender messageSender)
        {
            courseWork.Confirmed += (sender, e) =>
            {
                this.CourseWork = sender as CourseWork;

                messageSender.Message = $"Good day, {this.FullName}!" +
                                        $"\n\nCoursework '{CourseWork?.Title}' has been approved by '{e.FullName}'." +
                                        $"\nInformation to contact to your mentor: {e?.FullName}." +
                                        $"\n\nBest Regards, Coursework Management System!";

                messageSender.Send();
            };

            courseWork.Declined += (sender, e) =>
            {
                messageSender.Message = $"Good day, {this.FullName!}" +
                                        $"\n\nCoursework '{CourseWork?.Title}' has been declined by '{e.FullName}'." +
                                        $"\n\nBest Regards, Coursework Management System!";

                messageSender.Send();
            };

            courseWork.Selecting(this);
        }
        
        public bool Equals(Student other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Student other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}