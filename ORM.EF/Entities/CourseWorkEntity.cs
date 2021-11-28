using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.EF.Entities
{
    public class CourseWorkEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual MentorEntity Mentor { get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentEntity Student { get; set; }
        public StatusEntity Status { get; set; }
    }
}
