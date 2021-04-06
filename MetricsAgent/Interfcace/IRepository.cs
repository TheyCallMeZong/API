using System;

namespace MetricsAgent.Interface
{
    public interface IRepository<T> 
        where T : class
    {
        T GetById(int id);
        void Create(T item);
    }
}
