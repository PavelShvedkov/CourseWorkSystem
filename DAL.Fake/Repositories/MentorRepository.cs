using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;

namespace DAL.Fake.Repositories
{
    public class MentorRepository: IMentorRepository
    {
        private List<MentorDto> mentors = new Faker<MentorDto>("en")
            .RuleFor(s => s.Id, f => f.UniqueIndex+1)
            .RuleFor(s => s.Email,f => f.Internet.Email())
            .RuleFor(s => s.FullName, f => f.Name.FullName())
            .Generate(10)
            .ToList();
        
        public IEnumerable<MentorDto> Get()
        {
            return mentors;
        }

        public MentorDto GetBy(int id)
        {
            return mentors.First(s=> s.Id==id);
        }
    }
}