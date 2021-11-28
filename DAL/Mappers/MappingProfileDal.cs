using AutoMapper;
using DAL.Interface.DTO;
using ORM.EF.Entities;

namespace DAL.Mappers
{
    class MappingProfileDal : Profile
    {
        public MappingProfileDal()
        {
            CreateMap<MentorEntity, MentorDto>();
            CreateMap<MentorDto, MentorEntity>();
            CreateMap<CourseWorkEntity, CourseWorkDto>()
                .ForMember(e => e.Status,
                    expression => expression.MapFrom(x => (StatusDto)(int)x.Status));
            CreateMap<CourseWorkDto, CourseWorkEntity>()
                .ForMember(e => e.Status,
                    expression => expression.MapFrom(x => (StatusEntity)(int)x.Status));
            CreateMap<StudentEntity, StudentDto>()
                .ForMember(e => e.Course,
                    expression => expression.MapFrom(x => (CourseDto)(int)x.Course));
            CreateMap<StudentDto, StudentEntity>()
                .ForMember(e => e.Course,
                    expression => expression.MapFrom(x => (CourseEntity)(int)x.Course));
        }
    }
}