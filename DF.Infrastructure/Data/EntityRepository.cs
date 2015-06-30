using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DF.Infrastructure.Data
{
    public class EntityRepository<TEntity, TKey, TContext> : IRepository<TEntity, TKey> where TEntity : class
        where TContext : DbContext, new()
    {
        private TContext _context = new TContext();

        public TContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public virtual TEntity Get(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State  = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}