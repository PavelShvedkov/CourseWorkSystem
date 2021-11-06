namespace Web.UI.ViewModels
{
    public sealed class StudentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public CourseViewModel CourseViewModel { get; set; }

        public CourseWorkViewModel CourseWorkViewModel { get; set; }
    }
}
