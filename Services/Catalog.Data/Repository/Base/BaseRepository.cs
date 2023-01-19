using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Data.Repository.Base
{
    public class BaseRepository : IBaseRepository
    {
        #region Property
        internal readonly CatalogDbContext _context;
        #endregion

        #region Constructor
        public BaseRepository(CatalogDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Operations       
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>Id of added record</returns>
        public virtual int Add<T>(T model) where T : class
        {
            dynamic table = model;

            _context.Add<T>(table);
            _ = _context.SaveChanges();
            return table.Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>Id of added record</returns>
        public virtual async Task<int> AddAsync<T>(T model) where T : class
        {
            dynamic table = model;

            await _context.AddAsync<T>(table);
            _ = await _context.SaveChangesAsync();
            return table.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>Id of updated record</returns>
        public virtual int Update<T>(T model) where T : class
        {
            dynamic table = model;
            _ = _context.Update<T>(table);
            _ = _context.SaveChanges();
            return table.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>Id of updated record</returns>
        public virtual async Task<int> UpdateAsync<T>(T model) where T : class
        {
            dynamic table = model;

            _context.Update<T>(table);
            _ = await _context.SaveChangesAsync();
            return table.Id;
        }
        public virtual async Task<int> AddOrUpdateAsync<T>(T model) where T : class
        {
            dynamic table = model;
            return table.Id == 0 ? await AddAsync(model) : await UpdateAsync(model);
        }

        public virtual int Delete<T>(T model) where T : class
        {
            dynamic table = model;
            table.DeletedDate = DateTime.Now;
            table.IsDeleted = true;
            _context.Update<T>(table);
            return _context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync<T>(T model) where T : class
        {
            dynamic table = model;
            table.DeletedDate = DateTime.Now;
            table.IsDeleted = true;

            _context.Update<T>(table);
            return await _context.SaveChangesAsync();
        }
        public virtual int Restore<T>(T model) where T : class
        {
            dynamic table = model;
            table.DeletedDate = null;
            table.IsDeleted = false;
            _ = _context.Update<T>(model);
            return _context.SaveChanges();
        }

        public virtual async Task<int> RestoreAsync<T>(T model) where T : class
        {
            dynamic table = model;
            table.DeletedDate = null;
            table.IsDeleted = false;

            _ = _context.Update<T>(model);
            return await _context.SaveChangesAsync();
        }

        public int Destroy<T>(T model) where T : class
        {
            _ = _context.Remove<T>(model);
            return _context.SaveChanges();
        }

        public async Task<int> DestroyAsync<T>(T model) where T : class
        {
            _ = _context.Remove<T>(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> GetFirst<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            //_ = query.IncludeAll(_context);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return filter != null
                ? await query.FirstOrDefaultAsync(filter).ConfigureAwait(false)
                : await query.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<IQueryable<T>> Filter<T>(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int take = 0,
            int skip = 0) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            // _ = query.IncludeAll(_context);

            // Load all data first (client evaluation)
            query = query.ToListAsync().Result.AsQueryable();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {
                query = query.Take(take);
            }

            return await Task.Run(() => query);
        }

        public async Task<int> Count<T>(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where T : class
        {
            IQueryable<T> query = _context.Set<T>();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync().ConfigureAwait(false);
        }
        #endregion
    }
}
