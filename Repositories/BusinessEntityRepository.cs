using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbAdventureWorks.Repositories
{
    public class BusinessEntityRepository : IRepository<BusinessEntity>, IDisposable
    {
        private dbAdvent Context;
        public BusinessEntityRepository(dbAdvent context)
        {
            Context = context;
        }
        public void Create(BusinessEntity entity)
        {
            Context.BusinessEntity.Add(entity);
        }

        public void Delete(int id)
        {
            BusinessEntity b = Context.BusinessEntity.Find(id);
            if (b != null)
                Context.BusinessEntity.Remove(b);
        }

        public BusinessEntity Get(int id)
        {
            return Context.BusinessEntity.Find(id);
        }

        public IEnumerable<BusinessEntity> GetList()
        {
            return Context.BusinessEntity.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(BusinessEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<BusinessEntity> GetList(Expression<Func<BusinessEntity, bool>> predicate)
        {
            return Context.BusinessEntity.Where(predicate).ToList();
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
