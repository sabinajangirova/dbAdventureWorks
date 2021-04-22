using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class ProductCategoryRepository : IRepository<ProductCategory>, IDisposable
    {
        private dbAdvent Context;
        public ProductCategoryRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(ProductCategory entity)
        {
            Context.ProductCategory.Add(entity);
        }

        public void Delete(int id)
        {
            ProductCategory b = Context.ProductCategory.Find(id);
            if (b != null)
                Context.ProductCategory.Remove(b);
        }

        public ProductCategory Get(int id)
        {
            return Context.ProductCategory.Find(id);
        }

        public IEnumerable<ProductCategory> GetList()
        {
            return Context.ProductCategory.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(ProductCategory entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<ProductCategory> GetList(Expression<Func<ProductCategory, bool>> predicate)
        {
            return Context.ProductCategory.Where(predicate).ToList();
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
