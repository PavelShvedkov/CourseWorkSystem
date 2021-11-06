using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface ICourseWorkRepository: IRepository<CourseWorkDto>
    {
        void Update(CourseWorkDto work);
    }
}