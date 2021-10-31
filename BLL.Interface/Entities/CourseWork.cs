using System;

namespace BLL.Interface.Entities
{
    public sealed class CourseWork : IEquatable<CourseWork>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Mentor Mentor { get; set; }
        public Student Student { get; set; }
        public Status Status { get; set; }

        public event EventHandler<SelectedEventArgs> Selected;
        public event EventHandler<SelectedEventArgs> Confirmed;
        public event EventHandler<SelectedEventArgs> Declined;
        

        public void Selecting(Student student)
        {
            Status = Status.ConfirmationAwaiting;
            OnSelected(new SelectedEventArgs(student.FullName,student.Email));
        }

        public void Approving(Mentor mentor)
        {
            Status = Status.Appointed;
            OnConfirmed(new SelectedEventArgs(mentor.FullName, mentor.Email));
        }

        public void Declining(Mentor mentor)
        {
            Status = Status.NotAppointed;
            OnDeclined(new SelectedEventArgs(mentor.FullName, mentor.Email));
        }
        
        public bool Equals(CourseWork other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is CourseWork other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        private void OnSelected(SelectedEventArgs e)
        {
            Selected?.Invoke(this, e);
        }

        private void OnConfirmed(SelectedEventArgs e)
        {
            Confirmed?.Invoke(this, e);
        }

        private void OnDeclined(SelectedEventArgs e)
        {
            Declined?.Invoke(this, e);
        }
    }

    public class SelectedEventArgs: EventArgs
    {
        public SelectedEventArgs(string fullName, string email)
        {
            this.FullName = fullName;
            this.Email = email;
        }
        
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}