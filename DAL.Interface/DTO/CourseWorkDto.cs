using System;

namespace DAL.Interface.DTO
{
    public sealed class CourseWorkDto : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MentorDto Mentor { get; set; }
        public StudentDto Student { get; set; }
        public StatusDto Status { get; set; }
    }
}