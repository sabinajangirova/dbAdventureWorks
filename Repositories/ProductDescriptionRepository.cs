using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class ProductDescriptionRepository : IRepository<ProductDescription>, IDisposable
    {
        private dbAdvent Context;
        public ProductDescriptionRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(ProductDescription entity)
        {
            Context.ProductDescription.Add(entity);
        }

        public void Delete(int id)
        {
            ProductDescription b = Context.ProductDescription.Find(id);
            if (b != null)
                Context.ProductDescription.Remove(b);
        }

        public ProductDescription Get(int id)
        {
            return Context.ProductDescription.Find(id);
        }

        public IEnumerable<ProductDescription> GetList()
        {
            return Context.ProductDescription.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(ProductDescription entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<ProductDescription> GetList(Expression<Func<ProductDescription, bool>> predicate)
        {
            return Context.ProductDescription.Where(predicate).ToList();
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
