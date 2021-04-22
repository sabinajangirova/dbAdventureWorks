using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class ProductPhotoRepository : IRepository<ProductPhoto>, IDisposable
    {
        private dbAdvent Context;
        public ProductPhotoRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(ProductPhoto entity)
        {
            Context.ProductPhoto.Add(entity);
        }

        public void Delete(int id)
        {
            ProductPhoto b = Context.ProductPhoto.Find(id);
            if (b != null)
                Context.ProductPhoto.Remove(b);
        }

        public ProductPhoto Get(int id)
        {
            return Context.ProductPhoto.Find(id);
        }

        public IEnumerable<ProductPhoto> GetList()
        {
            return Context.ProductPhoto.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(ProductPhoto entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<ProductPhoto> GetList(Expression<Func<ProductPhoto, bool>> predicate)
        {
            return Context.ProductPhoto.Where(predicate).ToList();
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
