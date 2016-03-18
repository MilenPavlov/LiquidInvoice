using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Interfaces;
using ClassLibrary;


namespace DataAccess
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Resource, new()
    {
        private delegate Task<int> ActOnEntities(IEnumerable<TEntity> entities);
		private delegate Task<int> ActOnEntity(object entity);

        private ISqliteConnectionService _context;

        public BaseRepository(ISqliteConnectionService context)
        {
            _context = context;

        }

        // This method is intended to be used with sqlite methods UpdateAllAsync/DeleteAllAsync/CreateAllAsync.
        //  Pass in desired function as dbAction parameter.
        private async Task<IRepositoryResult<IEnumerable<TEntity>>> ModifyEntities(IEnumerable<TEntity> entityList, ActOnEntities action)
        {
            var result = new RepositoryResult<IEnumerable<TEntity>>();

            try
            {
                if ((await action(entityList)) < 0)
                {
                    result.ResultCode = RepositoryResultCode.Error;
                    result.ResultData = null;
                }
                else
                {
                    result.ResultCode = RepositoryResultCode.Ok;
                    result.ResultData = entityList;
                }

                return result;
            }
            catch (Exception e)
            {
                result.ResultData = null;
                result.ResultCode = RepositoryResultCode.Error;
                result.ResultDescription = e.Message;
                return result;
            }
        }

		private async Task<IRepositoryResult<TEntity>> ModifyEntity(TEntity entityList, ActOnEntity action)
		{
			var result = new RepositoryResult<TEntity>();

			try
			{
				if ((await action(entityList)) < 0)
				{
					result.ResultCode = RepositoryResultCode.Error;
					result.ResultData = default(TEntity);
				}
				else
				{
					result.ResultCode = RepositoryResultCode.Ok;
					result.ResultData = entityList;
				}

				return result;
			}
			catch (Exception e)
			{
				result.ResultData = null;
				result.ResultCode = RepositoryResultCode.Error;
				result.ResultDescription = e.Message;
				return result;
			}
		}


		// Only pass in expressions that can be converted by SQLITE.  
		//		For instance a nullable object's HasValue property will throw an exception.  Coalesce operator will also throw an error
		public virtual async Task<IRepositoryResult<IEnumerable<TEntity>>> ReadAllEntitiesWhere(Expression<Func<TEntity, bool>> predicate)
		{
			var result = new RepositoryResult<IEnumerable<TEntity>>();

			try
			{
				result.ResultData = await _context.Instance.Table<TEntity>().Where(predicate).ToListAsync();
				result.ResultCode = RepositoryResultCode.Ok;
			}
			catch (Exception e)
			{
				result.ResultData = null;
				result.ResultCode = RepositoryResultCode.Error;
				result.ResultDescription = e.Message;
			}

			return result;
		}

		public virtual async Task<IRepositoryResult<IEnumerable<TEntity>>> ReadAllEntities()
		{
			var result = new RepositoryResult<IEnumerable<TEntity>>();

			try
			{
				result.ResultData = await _context.Instance.Table<TEntity>().ToListAsync();
				result.ResultCode = RepositoryResultCode.Ok;
			}
			catch (Exception e)
			{
				result.ResultData = null;
				result.ResultCode = RepositoryResultCode.Error;
				result.ResultDescription = e.Message;
			}

			return result;
		}

		// Only pass in expressions that can be converted by SQLITE.  
		//		For instance a nullable object's HasValue property will throw an exception.  Coalesce operator will also throw an error
		public virtual async Task<IRepositoryResult<TEntity>> ReadEntityWhere(Expression<Func<TEntity, bool>> predicate)
		{
			var result = new RepositoryResult<TEntity>();

			try
			{
				result.ResultData = await _context.Instance.Table<TEntity>().Where(predicate).FirstOrDefaultAsync();
				result.ResultCode = RepositoryResultCode.Ok;
			}
			catch (Exception e)
			{
				result.ResultData = null;
				result.ResultCode = RepositoryResultCode.Error;
				result.ResultDescription = e.Message;
			}

			return result;
		}
        

		#region Create/Update/Delete
		// Update, Delete, and Create methods do not set CurrentState for entity.

		public virtual async Task<IRepositoryResult<IEnumerable<TEntity>>> UpdateAllEntities(IEnumerable<TEntity> entities)
        {
            if (entities == null) 
				throw new ArgumentNullException("entities cannot be null");
			
			return await ModifyEntities(entities, _context.Instance.UpdateAllAsync).ConfigureAwait(false);
        }
        
        // This should only be called after entity has been synced or if entity is deleted from server
		public virtual async Task<IRepositoryResult<IEnumerable<TEntity>>> DeleteAllEntities(IEnumerable<TEntity> entities)
        {
			if (entities == null)
				throw new ArgumentNullException ("entities cannot be null");

			var finalResult = new RepositoryResult<IEnumerable<TEntity>> ();
			finalResult.ResultCode = RepositoryResultCode.Ok;
			finalResult.ResultDescription = string.Empty;

			//sqlite does not support multiple deletes
			foreach (var entity in entities)
			{
				var result = await ModifyEntity (entity, _context.Instance.DeleteAsync).ConfigureAwait(false);

				if (result.ResultCode == RepositoryResultCode.Error)
				{
					finalResult.ResultCode = RepositoryResultCode.Error;
					finalResult.ResultDescription += result.ResultDescription;
				}

			}

			if (finalResult.ResultCode == RepositoryResultCode.Error)
			{
				finalResult.ResultData = null;
			}
			else
			{
				finalResult.ResultData = entities;
			}

			return finalResult;
        }

		// create entity or update if it already exists
		public virtual async Task<IRepositoryResult<IEnumerable<TEntity>>> CreateAllEntities(IEnumerable<TEntity> entities)
		{
			IRepositoryResult<IEnumerable<TEntity>> createResult = new RepositoryResult<IEnumerable<TEntity>> ();

			try
			{
				if (entities == null) 
					throw new ArgumentNullException("entities cannot be null");

				createResult = await ModifyEntities(entities, _context.Instance.InsertAllAsync).ConfigureAwait(false);
				createResult.ResultCode = RepositoryResultCode.Ok;
			}
			catch (Exception e)
			{
				createResult.ResultCode = RepositoryResultCode.Error;
				createResult.ResultData = null;
				createResult.ResultDescription = e.Message;
			}

		return createResult;
		}

		#endregion
    }
}
