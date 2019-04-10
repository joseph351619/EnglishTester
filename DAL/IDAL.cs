﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.DAL
{
    public interface IDAL<TEntity>
    {
        TEntity Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        void Reads();
        void Add(TEntity entity);
        void Add(IList<TEntity> entites);
        IEnumerable<TEntity> ReadAll();
        void Delete(TEntity entity);
        void Save();

    }
}
