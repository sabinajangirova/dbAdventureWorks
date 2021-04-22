using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    interface IRepository<T> : IDisposable
    {
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        IEnumerable<T> GetList();
        void Delete(int id);
        void Save();
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
    }
}
