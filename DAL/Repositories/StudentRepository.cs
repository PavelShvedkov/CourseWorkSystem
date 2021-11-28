using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using DAL.Mappers;
using ORM.EF;

namespace DAL.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly CourseWorkContext context;
        private readonly IMapper mapper;

        public StudentRepository(CourseWorkContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));

            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileDal());
            }).CreateMapper();

        }

        public IEnumerable<StudentDto> Get()
        {
            var st = context.Students;

            return context.Students.Select(s => mapper.Map<StudentDto>(s));
        }

        public StudentDto GetBy(int id) 
            => mapper.Map<StudentDto>(context.Students.First(m => m.Id == id));
    }
}