using EnglishTester.Data.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.DAL
{
    public class DALBase<TEntity> : IDisposable where TEntity:class
    {
        protected BaseEntities Entities;
        bool Disposed;
        public IQueryable<TEntity> Data;

        public DALBase() { Entities = new BaseEntities(); }
        public DALBase(BaseEntities entities) { Entities = entities; }

        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Set<TEntity>().Where(predicate).FirstOrDefault();
        }
        public void Reads()
        {
            Data = Entities.Set<TEntity>().AsQueryable();
        }
        public void Add(TEntity entity)
        {
            Entities.Set<TEntity>().Add(entity);
        }
        public void Add(IList<TEntity> entites)
        {
            foreach(var entity in entites)
            {
                Entities.Set<TEntity>().Add(entity);
            }
        }
        public void Delete(TEntity entity)
        {
            Entities.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }
        public void Save()
        {
            Entities.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                Entities.Dispose();
                Entities = null;
                Disposed = true;
            }
        }
    }
}
