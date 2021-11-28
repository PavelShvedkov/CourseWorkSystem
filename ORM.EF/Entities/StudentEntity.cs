using System;
using System.ComponentModel.DataAnnotations;

namespace ORM.EF.Entities
{
    public class StudentEntity 
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public CourseEntity Course { get; set; }
        public virtual CourseWorkEntity CourseWork { get; set; }
    }
}