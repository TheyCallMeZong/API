using System;

namespace MetricsAgent.DB.IRepository
{
    public interface IRepository<T> 
        where T : class
    {
        T GetById(int id);
        void Create(T item);
    }
}
