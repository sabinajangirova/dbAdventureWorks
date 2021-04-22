using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class BusinessEntityAddressRepository : IRepository<BusinessEntityAddress>, IDisposable
    {
        private dbAdvent Context;
        public BusinessEntityAddressRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(BusinessEntityAddress entity)
        {
            Context.BusinessEntityAddress.Add(entity);
        }

        public void Delete(int id)
        {
            BusinessEntityAddress b = Context.BusinessEntityAddress.Find(id);
            if (b != null)
                Context.BusinessEntityAddress.Remove(b);
        }

        public BusinessEntityAddress Get(int id)
        {
            return Context.BusinessEntityAddress.Find(id);
        }

        public IEnumerable<BusinessEntityAddress> GetList()
        {
            return Context.BusinessEntityAddress.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(BusinessEntityAddress entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<BusinessEntityAddress> GetList(Expression<Func<BusinessEntityAddress, bool>> predicate)
        {
            return Context.BusinessEntityAddress.Where(predicate).ToList();
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
