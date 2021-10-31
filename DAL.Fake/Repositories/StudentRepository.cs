using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;

namespace DAL.Fake.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private List<StudentDto> studets = new Faker<StudentDto>("en")
            .RuleFor(s => s.Id, f => f.UniqueIndex+1)
            .RuleFor(s => s.Email,f => f.Internet.Email())
            .RuleFor(s => s.FullName, f => f.Name.FullName())
            .RuleFor(s => s.Course, f=> f.PickRandom<CourseDto>())
            .Generate(10)
            .ToList();
        
        public IEnumerable<StudentDto> Get()
        {
            return studets;
        }

        public StudentDto GetBy(int id)
        {
           return studets.First(s=> s.Id==id);
        }
    }
}