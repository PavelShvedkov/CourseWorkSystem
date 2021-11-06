using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Servicies;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;

namespace BLL.Servicies
{
    public class CourseWorkService: ICourseWorkService
    {
        private readonly IStudentRepository studentRepo;
        private readonly IMentorRepository mentorRepo;
        private readonly ICourseWorkRepository courseWorkRepo;
        private readonly IMapper mapper;
        private readonly IMessageSender sender;
        
        public CourseWorkService(IStudentRepository students, IMentorRepository mentors, ICourseWorkRepository courseWorks, IMessageSender sender)
        {
            studentRepo = students ?? throw new ArgumentNullException(nameof(students));
            mentorRepo = mentors ?? throw new ArgumentNullException(nameof(mentors));
            courseWorkRepo =  courseWorks ?? throw new ArgumentNullException(nameof(courseWorks));
            this.sender = sender ?? throw new ArgumentNullException(nameof(sender));

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDto>();
                cfg.CreateMap<StudentDto, Student>();
                cfg.CreateMap<MentorDto, Mentor>();
                cfg.CreateMap<Mentor, MentorDto>();
                cfg.CreateMap<CourseWorkDto, CourseWork>();
                cfg.CreateMap<CourseWork, CourseWorkDto>();

            }).CreateMapper();
        }
        
        public IEnumerable<CourseWork> GetCourseWorks()
        {
            return courseWorkRepo.Get().Select(c => mapper.Map<CourseWork>(c));
        }

        public IEnumerable<Mentor> GetMentors()
        {
            return mentorRepo.Get().Select(c => mapper.Map<Mentor>(c));
        }

        public IEnumerable<Student> GetStudents()
        {
            return studentRepo.Get().Select(c => mapper.Map<Student>(c));
        }

        public void Select(Student student, CourseWork courseWork)
        {
            student.SelectCourseWork(courseWork,sender);
            courseWorkRepo.Update(mapper.Map<CourseWorkDto>(courseWork));
        }

        public void Approve(Mentor mentor, CourseWork courseWork)
        {
            mentor.Approve(courseWork);
            courseWorkRepo.Update(mapper.Map<CourseWorkDto>(courseWork));
        }

        public void Decline(Mentor mentor, CourseWork courseWork)
        {
            mentor.Decline(courseWork);
            courseWorkRepo.Update(mapper.Map<CourseWorkDto>(courseWork));
        }

        public void Publish(Mentor mentor, IEnumerable<CourseWork> courseWorks)
        {
            mentor.Publish(courseWorks,sender);
        }
    }
}