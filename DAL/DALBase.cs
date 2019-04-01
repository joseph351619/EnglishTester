using EnglishTester.Data.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.DAL
{
    public class DALBase<TEntity> : IDisposable where TEntity:class
    {
        protected BaseEntities Entities;
        bool Disposed;

        public DALBase() { Entities = new BaseEntities(); }
        public DALBase(BaseEntities entities) { Entities = entities; }

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
