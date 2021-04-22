using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class SalesTerritoryRepository : IRepository<SalesTerritory>, IDisposable
    {
        private dbAdvent Context;
        public SalesTerritoryRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(SalesTerritory entity)
        {
            Context.SalesTerritory.Add(entity);
        }

        public void Delete(int id)
        {
            SalesTerritory b = Context.SalesTerritory.Find(id);
            if (b != null)
                Context.SalesTerritory.Remove(b);
        }

        public SalesTerritory Get(int id)
        {
            return Context.SalesTerritory.Find(id);
        }

        public IEnumerable<SalesTerritory> GetList()
        {
            return Context.SalesTerritory.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(SalesTerritory entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<SalesTerritory> GetList(Expression<Func<SalesTerritory, bool>> predicate)
        {
            return Context.SalesTerritory.Where(predicate).ToList();
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
