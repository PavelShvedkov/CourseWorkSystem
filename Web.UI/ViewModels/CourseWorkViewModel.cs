namespace Web.UI.ViewModels
{
    public sealed class CourseWorkViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public StudentViewModel StudentViewModel { get; set; }

        public MentorViewModel MentorViewModel { get; set; }

        public StatusViewModel StatusViewModel { get; set; }
    }
}
