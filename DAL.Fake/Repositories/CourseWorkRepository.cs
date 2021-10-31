using System.Collections.Generic;
using System.Linq;
using Bogus;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;

namespace DAL.Fake.Repositories
{
    public class CourseWorkRepository: ICourseWorkRepository
    {
        private List<CourseWorkDto> courseWorks = new Faker<CourseWorkDto>("en")
            .RuleFor(s => s.Id, f => f.UniqueIndex+1)
            .RuleFor(s => s.Title,f => f.Lorem.Lines(1))
            .RuleFor(s => s.Status, f => f.Random.Enum(StatusDto.Appointed,StatusDto.ConfirmationAwaiting))
            .Generate(10)
            .ToList();
        
        public IEnumerable<CourseWorkDto> Get()
        {
            return courseWorks;
        }

        public CourseWorkDto GetBy(int id)
        {
            return courseWorks.First(s=> s.Id==id);
        }
    }
}