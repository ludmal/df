using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DF.Infrastructure.Data
{
    public interface IRepository<TEntity,in TKey> where TEntity : class
    {
        TEntity Get(TKey id);
        void Delete(TEntity entity);
        void Save(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}