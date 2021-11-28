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
    public class MentorRepository: IMentorRepository
    {
        private readonly CourseWorkContext context;
        private readonly IMapper mapper;

        public MentorRepository(CourseWorkContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));

            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileDal());
            }).CreateMapper();

        }
        
        public IEnumerable<MentorDto> Get()
        {
            return context.Mentors.Select(s => mapper.Map<MentorDto>(s));
        }

        public MentorDto GetBy(int id)
        {
            return mapper.Map<MentorDto>(context.Mentors.First(m => m.Id == id));
        }
    }
}