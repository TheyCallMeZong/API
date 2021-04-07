using System;

namespace MetricsAgent.Interface
{
    public interface IRepository<T> 
        where T : class
    {
        T GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime);
        void Create(T item);
    }
}
