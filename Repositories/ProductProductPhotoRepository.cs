using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class ProductProductPhotoRepository : IRepository<ProductProductPhoto>, IDisposable
    {
        private dbAdvent Context;
        public ProductProductPhotoRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(ProductProductPhoto entity)
        {
            Context.ProductProductPhoto.Add(entity);
        }

        public void Delete(int id)
        {
            ProductProductPhoto b = Context.ProductProductPhoto.Find(id);
            if (b != null)
                Context.ProductProductPhoto.Remove(b);
        }

        public ProductProductPhoto Get(int id)
        {
            return Context.ProductProductPhoto.Find(id);
        }

        public IEnumerable<ProductProductPhoto> GetList()
        {
            return Context.ProductProductPhoto.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(ProductProductPhoto entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<ProductProductPhoto> GetList(Expression<Func<ProductProductPhoto, bool>> predicate)
        {
            return Context.ProductProductPhoto.Where(predicate).ToList();
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
