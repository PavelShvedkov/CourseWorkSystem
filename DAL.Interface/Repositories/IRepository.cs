using System.Collections;
using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface IRepository<T> where T: IEntity
    {
        IEnumerable<T> Get();
        T GetBy(int id);
    }
}