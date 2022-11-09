using DataAccess.UOW;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class GenericRepository<TEntity> : UnitOfWork where TEntity : class
    {
        #region Fields

        internal SOPOContext context;
        internal DbSet<TEntity> dbSet;

        #endregion


        #region Constructor

        public GenericRepository(SOPOContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        #endregion


        #region Methods

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await DeleteAsync(entityToDelete);
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                dbSet.Remove(entityToDelete);
            });
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            await Task.Run(() =>
            {
                dbSet.Update(entityToUpdate);
            });
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        #endregion

    }
}