using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class ProductRepository : IRepository<Product>, IDisposable
    {
        private dbAdvent Context;
        public ProductRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(Product entity)
        {
            Context.Product.Add(entity);
        }

        public void Delete(int id)
        {
            Product b = Context.Product.Find(id);
            if (b != null)
                Context.Product.Remove(b);
        }

        public Product Get(int id)
        {
            return Context.Product.Find(id);
        }

        public IEnumerable<Product> GetList()
        {
            return Context.Product.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(Product entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<Product> GetList(Expression<Func<Product, bool>> predicate)
        {
            return Context.Product.Where(predicate).ToList();
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
