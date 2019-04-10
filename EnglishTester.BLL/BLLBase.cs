using EnglishTester.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.BLL
{
    public class BLLBase<TEntity>
    {
        protected IDAL<TEntity> IDAL;
        public TEntity Read(
            Expression<Func<TEntity, bool>> predicate, 
            params Expression<Func<TEntity, object>>[] includes)
        {
            return IDAL.Read(predicate, includes);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return IDAL.ReadAll();
        }
        public void Add(TEntity entity)
        {
            IDAL.Add(entity);
        }
        public void Add(IList<TEntity> entities)
        {
            IDAL.Add(entities);
        }
        public void Delete(TEntity entity)
        {
            IDAL.Delete(entity);
            IDAL.Save();
        }
    }
}
