using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class CustomerRepository : IRepository<Customer>, IDisposable
    {
        private dbAdvent Context;
        public CustomerRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(Customer entity)
        {
            Context.Customer.Add(entity);
        }

        public void Delete(int id)
        {
            Customer b = Context.Customer.Find(id);
            if (b != null)
                Context.Customer.Remove(b);
        }

        public Customer Get(int id)
        {
            return Context.Customer.Find(id);
        }

        public IEnumerable<Customer> GetList()
        {
            return Context.Customer.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<Customer> GetList(Expression<Func<Customer, bool>> predicate)
        {
            return Context.Customer.Where(predicate).ToList();
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
