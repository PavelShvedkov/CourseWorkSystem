using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public sealed class MentorDto : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<CourseWorkDto> CourseWorks { get; set; }
    }
}