using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class SalesOrderDetailRepository : IRepository<SalesOrderDetail>, IDisposable
    {
        private dbAdvent Context;
        public SalesOrderDetailRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(SalesOrderDetail entity)
        {
            Context.SalesOrderDetail.Add(entity);
        }

        public void Delete(int id)
        {
            SalesOrderDetail b = Context.SalesOrderDetail.Find(id);
            if (b != null)
                Context.SalesOrderDetail.Remove(b);
        }

        public SalesOrderDetail Get(int id)
        {
            return Context.SalesOrderDetail.Find(id);
        }

        public IEnumerable<SalesOrderDetail> GetList()
        {
            return Context.SalesOrderDetail.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(SalesOrderDetail entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<SalesOrderDetail> GetList(Expression<Func<SalesOrderDetail, bool>> predicate)
        {
            return Context.SalesOrderDetail.Where(predicate).ToList();
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
