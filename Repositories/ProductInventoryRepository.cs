using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class ProductInventoryRepository : IRepository<ProductInventory>, IDisposable
    {
        private dbAdvent Context;
        public ProductInventoryRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(ProductInventory entity)
        {
            Context.ProductInventory.Add(entity);
        }

        public void Delete(int id)
        {
            ProductInventory b = Context.ProductInventory.Find(id);
            if (b != null)
                Context.ProductInventory.Remove(b);
        }

        public ProductInventory Get(int id)
        {
            return Context.ProductInventory.Find(id);
        }

        public IEnumerable<ProductInventory> GetList()
        {
            return Context.ProductInventory.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(ProductInventory entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<ProductInventory> GetList(Expression<Func<ProductInventory, bool>> predicate)
        {
            return Context.ProductInventory.Where(predicate).ToList();
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
