using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM.EF.Entities
{
    public class MentorEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual IEnumerable<CourseWorkEntity> CourseWorks { get; set; }
    }
}