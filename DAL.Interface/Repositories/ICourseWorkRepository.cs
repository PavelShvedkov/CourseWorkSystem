using System.Collections;
using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface ICourseWorkRepository: IRepository<CourseWorkDto>
    {
        void Update(CourseWorkDto work);
        void Add(CourseWorkDto work);

        IEnumerable<CourseWorkDto> GetCourseWorks(MentorDto mentor);
    }
} 