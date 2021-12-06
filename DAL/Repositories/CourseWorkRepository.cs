using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using AutoMapper;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using ORM.EF;
using ORM.EF.Entities;

namespace DAL.Repositories
{
    public class CourseWorkRepository : ICourseWorkRepository
    {
        private readonly CourseWorkContext context;
        private readonly IMapper mapper;

        public CourseWorkRepository(CourseWorkContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));

            mapper = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfileDal()); }).CreateMapper();
        }

        public IEnumerable<CourseWorkDto> Get()
        {
            return context.CourseWorks
                .Include(c => c.Mentor)
                .Include(c => c.Student)
                .Select(s => mapper.Map<CourseWorkDto>(s));
        }

        public CourseWorkDto GetBy(int id)
        {
            return mapper.Map<CourseWorkDto>(context.CourseWorks.First(m => m.Id == id));
        }

        public void Update(CourseWorkDto work)
        {
            var workDto = context.CourseWorks.First(w => (w.Id == work.Id));
            workDto.Status = (StatusEntity)(work.Status);
            context.SaveChanges();
        }

        public void Add(CourseWorkDto work)
        {
            context.CourseWorks.Add(mapper.Map<CourseWorkEntity>(work));
            context.SaveChanges();
        }

        public IEnumerable<CourseWorkDto> GetCourseWorks(MentorDto mentor)
        {
            var mentorEntity = mapper.Map<MentorEntity>(mentor);

           return context
               .CourseWorks
               .Include(c => c.Mentor)
               //.Include(c => c.Student)
               .Where(m => m.Mentor.Id == mentorEntity.Id)
               .Select(e => mapper.Map<CourseWorkDto>(e));
        }
    }
}