using AutoMapper;
using BLL.Interface.Entities;
using Web.UI.ViewModels;

namespace Web.UI.Infrastructure
{
    public class MappingProfileWeb : Profile
    {
        public MappingProfileWeb()
        {
            CreateMap<Mentor, MentorViewModel>();
            CreateMap<MentorViewModel, Mentor>();
            CreateMap<Student, StudentViewModel>()
                .ForMember(e => e.CourseViewModel,
                    expression => expression.MapFrom(x => (CourseViewModel)(int)x.Course));
            CreateMap<StudentViewModel, Student>()
                .ForMember(e => e.Course,
                    expression => expression.MapFrom(x => (Course)(int)x.CourseViewModel));
            CreateMap<CourseWork, CourseWorkViewModel>()
                .ForMember(e => e.StatusViewModel,
                    expression => expression.MapFrom(x => (StatusViewModel)(int)x.Status));
            CreateMap<CourseWorkViewModel, CourseWork>()
                .ForMember(e => e.Status,
                    expression => expression.MapFrom(x => (Status)(int)x.StatusViewModel));
        }
    }
}
