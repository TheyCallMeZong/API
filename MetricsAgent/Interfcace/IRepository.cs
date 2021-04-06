using System;

namespace MetricsAgent.Interface
{
    public interface IRepository<T> 
        where T : class
    {
        int GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime);
        void Create(T item);
    }
}
