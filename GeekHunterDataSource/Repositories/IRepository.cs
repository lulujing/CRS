using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GeekHunterDataSource.Repositories
{
    public interface IRepository<T, V> where T : class
    {
        T Get(V Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);


    }
}
