using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class AddressRepository : IRepository<Address>, IDisposable
    {
        private dbAdvent Context;
        public AddressRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(Address entity)
        {
            Context.Address.Add(entity);
        }
        public void Delete(int id)
        {
            Address a = Context.Address.Find(id);
            if(a!=null)
                Context.Address.Remove(a);
        }

        public Address Get(int id)
        {
            return Context.Address.Find(id);
        }

        public IEnumerable<Address> GetList()
        {
            return Context.Address.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(Address entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Address> GetList(Expression<Func<Address, bool>> predicate)
        {
            return Context.Address.Where(predicate).ToList();
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
