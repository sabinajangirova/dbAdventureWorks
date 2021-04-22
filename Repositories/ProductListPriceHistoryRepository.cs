using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class ProductListPriceHistoryRepository : IRepository<ProductListPriceHistory>, IDisposable
    {
        private dbAdvent Context;
        public ProductListPriceHistoryRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(ProductListPriceHistory entity)
        {
            Context.ProductListPriceHistory.Add(entity);
        }

        public void Delete(int id)
        {
            ProductListPriceHistory b = Context.ProductListPriceHistory.Find(id);
            if (b != null)
                Context.ProductListPriceHistory.Remove(b);
        }

        public ProductListPriceHistory Get(int id)
        {
            return Context.ProductListPriceHistory.Find(id);
        }

        public IEnumerable<ProductListPriceHistory> GetList()
        {
            return Context.ProductListPriceHistory.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(ProductListPriceHistory entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<ProductListPriceHistory> GetList(Expression<Func<ProductListPriceHistory, bool>> predicate)
        {
            return Context.ProductListPriceHistory.Where(predicate).ToList();
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
