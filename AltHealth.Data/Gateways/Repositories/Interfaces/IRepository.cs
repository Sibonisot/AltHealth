using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AltHealth.Data.Gateways.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Update(T entity, object key);
        void Update(T entity, object[] keyValues);
        void Delete(T entity);
        T GetById(object id);
        T GetById(object[] keyValues);
        List<T> ListAll();
        List<T> List(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
    }
}
