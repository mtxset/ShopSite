﻿using System.Collections.Generic;
using System.Linq;

namespace ShopSite.Data.Repository
{
    public interface IRepository<T> where T : class
    {

        T GetById(object id);

        void Insert(T entity);
        void Insert(IEnumerable<T> entities);

        void Update(T entity);
        void Update(IEnumerable<T> entities);

        void Delete(T entity);
        void Delete(IEnumerable<T> entities);

        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }
    }
}
