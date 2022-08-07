using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainee.School.Domain.Entidades;
using Trainee.School.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Trainee.School.Domain.Contratos;
using System.Linq.Expressions;

//Pedir explicações quanto a essa classe

namespace Trainee.School.Domain.Repositorio
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        private readonly ContextoTraineeeSchool _context;
        private DbSet<TEntity> _dbSet;

        public RepositoryBase(ContextoTraineeeSchool context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public virtual IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                (_dbSet, (current, expression) => current.Include(expression));
        }

        public virtual TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (_dbSet, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.IdAluno == id);
            }

            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        private bool _dispose = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_dispose)
                if (disposing)
                {
                    _context.Dispose();
                }

            _dispose = true;
        }
    }
}