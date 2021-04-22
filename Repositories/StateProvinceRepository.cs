using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class StateProvinceRepository : IRepository<StateProvince>, IDisposable
    {
        private dbAdvent Context;
        public StateProvinceRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(StateProvince entity)
        {
            Context.StateProvince.Add(entity);
        }

        public void Delete(int id)
        {
            StateProvince b = Context.StateProvince.Find(id);
            if (b != null)
                Context.StateProvince.Remove(b);
        }

        public StateProvince Get(int id)
        {
            return Context.StateProvince.Find(id);
        }

        public IEnumerable<StateProvince> GetList()
        {
            return Context.StateProvince.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(StateProvince entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<StateProvince> GetList(Expression<Func<StateProvince, bool>> predicate)
        {
            return Context.StateProvince.Where(predicate).ToList();
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
