using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trainee.School.Domain.Entidades;

namespace Trainee.School.Domain.Contratos
{
    public interface IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includeExpressions);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions);
    }
}
