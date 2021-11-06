using System.Collections.Generic;

namespace Web.UI.ViewModels
{
    public sealed class MentorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Information { get; set; }
        public string Email { get; set; }
        public IEnumerable<CourseWorkViewModel> CourseWorks { get; set; }
    }
}
