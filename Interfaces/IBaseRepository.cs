using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Interfaces
{
    public interface IBaseRepository<TEntity>
    {
		Task<IRepositoryResult<IEnumerable<TEntity>>> ReadAllEntities ();
		Task<IRepositoryResult<IEnumerable<TEntity>>> ReadAllEntitiesWhere(Expression<Func<TEntity, bool>> predicate);
		Task<IRepositoryResult<TEntity>> ReadEntityWhere (Expression<Func<TEntity, bool>> predicate);
		Task<IRepositoryResult<IEnumerable<TEntity>>> UpdateAllEntities(IEnumerable<TEntity> entities);
		Task<IRepositoryResult<IEnumerable<TEntity>>> CreateAllEntities(IEnumerable<TEntity> entities);
		Task<IRepositoryResult<IEnumerable<TEntity>>> DeleteAllEntities (IEnumerable<TEntity> entities);
    }
}
