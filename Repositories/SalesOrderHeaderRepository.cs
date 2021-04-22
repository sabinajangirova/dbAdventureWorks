using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class SalesOrderHeaderRepository : IRepository<SalesOrderHeader>, IDisposable
    {
        private dbAdvent Context;
        public SalesOrderHeaderRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(SalesOrderHeader entity)
        {
            Context.SalesOrderHeader.Add(entity);
        }

        public void Delete(int id)
        {
            SalesOrderHeader b = Context.SalesOrderHeader.Find(id);
            if (b != null)
                Context.SalesOrderHeader.Remove(b);
        }

        public SalesOrderHeader Get(int id)
        {
            return Context.SalesOrderHeader.Find(id);
        }

        public IEnumerable<SalesOrderHeader> GetList()
        {
            return Context.SalesOrderHeader.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(SalesOrderHeader entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<SalesOrderHeader> GetList(Expression<Func<SalesOrderHeader, bool>> predicate)
        {
            return Context.SalesOrderHeader.Where(predicate).ToList();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
