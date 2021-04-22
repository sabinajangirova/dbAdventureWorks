using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class PersonPhoneRepository : IRepository<PersonPhone>, IDisposable
    {
        private dbAdvent Context;
        public PersonPhoneRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(PersonPhone entity)
        {
            Context.PersonPhone.Add(entity);
        }

        public void Delete(int id)
        {
            PersonPhone p = Context.PersonPhone.Find(id);
            if (p != null)
                Context.PersonPhone.Remove(p);
        }

        public PersonPhone Get(int id)
        {
            return Context.PersonPhone.Find(id);
        }

        public IEnumerable<PersonPhone> GetList()
        {
            return Context.PersonPhone.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(PersonPhone entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<PersonPhone> GetList(Expression<Func<PersonPhone, bool>> predicate)
        {
            return Context.PersonPhone.Where(predicate).ToList();
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
