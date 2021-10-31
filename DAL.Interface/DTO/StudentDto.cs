using System;

namespace DAL.Interface.DTO
{
    public sealed class StudentDto : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public CourseDto Course { get; set; }
        public CourseWorkDto CourseWork { get; set; }
    }
}