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
            courseWork.Confirmed += (sender, args) =>
            {
                var courseWork = sender as CourseWork;
                messageSender.Message = $"Hello, {this.FullName}!\t" +
                                        $"{courseWork.Title} approved\t" +
                                        $"{args.FullName}\t" + 
                                        $"{args.Email}";
                messageSender.Send();
            };
            
            courseWork.Declined += (sender, args) =>
            {
                var courseWork = sender as CourseWork;
                messageSender.Message = $"Hello, {this.FullName}!\t" +
                                        $"{courseWork.Title} declined\t" +
                                        $"{args.FullName}\t" + 
                                        $"{args.Email}";
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