using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class ShoppingCartItemRepository : IRepository<ShoppingCartItem>, IDisposable
    {
        private dbAdvent Context;
        public ShoppingCartItemRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(ShoppingCartItem entity)
        {
            Context.ShoppingCartItem.Add(entity);
        }

        public void Delete(int id)
        {
            ShoppingCartItem b = Context.ShoppingCartItem.Find(id);
            if (b != null)
                Context.ShoppingCartItem.Remove(b);
        }

        public ShoppingCartItem Get(int id)
        {
            return Context.ShoppingCartItem.Find(id);
        }

        public IEnumerable<ShoppingCartItem> GetList()
        {
            return Context.ShoppingCartItem.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(ShoppingCartItem entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<ShoppingCartItem> GetList(Expression<Func<ShoppingCartItem, bool>> predicate)
        {
            return Context.ShoppingCartItem.Where(predicate).ToList();
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
