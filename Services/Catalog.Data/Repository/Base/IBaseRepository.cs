using System.Linq.Expressions;

namespace Catalog.Data.Repository.Base
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Get the first record 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        Task<T> GetFirst<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where T : class;

        /// <summary>
        /// Get filtered records
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        Task<IQueryable<T>> Filter<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int take = 0, int skip = 0) where T : class;

        /// <summary>
        /// Count the records based on matching crieteria
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        Task<int> Count<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where T : class;

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add<T>(T model) where T : class;
        /// <summary>
        /// Add new entity asynchronously
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddAsync<T>(T model) where T : class;

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update<T>(T model) where T : class;
        /// <summary>
        /// Update entity asynchronously
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> UpdateAsync<T>(T model) where T : class;

        Task<int> AddOrUpdateAsync<T>(T model) where T : class;
        /// <summary>
        /// Delete entity from database ( Set IsDeleted flag to true )
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Delete<T>(T model) where T : class;
        /// <summary>
        /// Delete entity from database ( Set IsDeleted flag to true ) asynchronously
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(T model) where T : class;

        /// <summary>
        /// Restore the deleted entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Restore<T>(T model) where T : class;
        /// <summary>
        /// Restore the deleted entity asynchronously
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> RestoreAsync<T>(T model) where T : class;

        /// <summary>
        /// Permanently remove entity from database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Destroy<T>(T model) where T : class;
        /// <summary>
        /// Permanently remove entity from database asynchronously
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> DestroyAsync<T>(T model) where T : class;
    }
}
