﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        void Create(T item);
        IList<T> GettAll();
    }
}
