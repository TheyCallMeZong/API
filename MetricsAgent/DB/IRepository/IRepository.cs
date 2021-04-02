using System.Collections.Generic;

namespace MetricsAgent.DB.IRepository
{
    public interface IRepository<T> 
        where T : class
    {
        T GetById(int id);
        IList<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
