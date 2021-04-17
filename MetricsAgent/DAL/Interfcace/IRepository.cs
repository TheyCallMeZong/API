using System;
using System.Collections.Generic;

namespace MetricsAgent.Interface
{
    public interface IRepository<T> 
        where T : class
    {
        IList<T> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
        void Create(T item);
        IList<T> GetAll();
    }
}
