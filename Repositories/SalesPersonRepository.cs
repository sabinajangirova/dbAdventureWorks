using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class SalesPersonRepository : IRepository<SalesPerson>, IDisposable
    {
        private dbAdvent Context;
        public SalesPersonRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(SalesPerson entity)
        {
            Context.SalesPerson.Add(entity);
        }

        public void Delete(int id)
        {
            SalesPerson b = Context.SalesPerson.Find(id);
            if (b != null)
                Context.SalesPerson.Remove(b);
        }

        public SalesPerson Get(int id)
        {
            return Context.SalesPerson.Find(id);
        }

        public IEnumerable<SalesPerson> GetList()
        {
            return Context.SalesPerson.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(SalesPerson entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<SalesPerson> GetList(Expression<Func<SalesPerson, bool>> predicate)
        {
            return Context.SalesPerson.Where(predicate).ToList();
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
