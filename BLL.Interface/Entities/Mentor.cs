using System;
using System.Collections;
using System.Collections.Generic;
using BLL.Interface.Servicies;

namespace BLL.Interface.Entities
{
    public sealed class Mentor : IEquatable<Mentor>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<CourseWork> CourseWorks { get; set; }
        
        
        public bool Equals(Mentor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Mentor other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public void Publish(IEnumerable<CourseWork> courseWorks, IMessageSender messageSender)
        {
            foreach (var work in courseWorks)
            {
                work.Mentor = this;

                work.Selected += (sender, args) =>
                {
                    var work = sender as CourseWork;

                    messageSender.Message = $"\nGood day, {this.FullName}!" +
                                            $"\n\nYour coursework '{work?.Title}' has been selected by '{args.FullName}'." +
                                            $"\nWaiting for your approve." +
                                            $"\nEmail of the student for contact: {args.Email}." +
                                            $"\n\nBest Regards, Coursework Management System!";

                    messageSender.Send();
                };
                
                this.CourseWorks.Add(work);
            }
        }

        public void Approve(CourseWork courseWork)
        {
            foreach (var work in CourseWorks)
            {
                if (courseWork != null && work.Equals(courseWork))
                {
                    courseWork.Approving(this);
                    return;
                }
            }
        }
        public void Decline(CourseWork courseWork)
        {
            foreach (var work in CourseWorks)
            {
                if (courseWork != null && work.Equals(courseWork))
                {
                    courseWork.Declining(this);
                    return;
                }
            }
        }

    }
}