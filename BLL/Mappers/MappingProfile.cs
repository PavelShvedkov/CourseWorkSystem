using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Mentor,MentorDto>();
            CreateMap<MentorDto,Mentor>();
            CreateMap<Student,StudentDto>();
            CreateMap<StudentDto,Student>();
            CreateMap<CourseWork,CourseWorkDto>();
            CreateMap<CourseWorkDto,CourseWork>();
        }
    }
}