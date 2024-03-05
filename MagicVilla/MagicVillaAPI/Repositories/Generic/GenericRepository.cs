using MagicVillaAPI.EntityContext.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVillaAPI.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly CommonDBContext _db;
        public DbSet<TEntity> _dbSet;

        public GenericRepository(CommonDBContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }
        public async Task<IQueryable<TEntity>> GetAllEntity(Expression<Func<TEntity, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!tracked)
            {
                query.AsNoTracking();
            }

            return query;
        }
        public async Task<IQueryable<TEntity>> GetEntityByPropety(Expression<Func<TEntity, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<TEntity> entity = _dbSet;
            if (!tracked)
            {
                entity.AsNoTracking();
            }
            if (filter != null)
            {
                entity = entity.Where(filter);
            }

            return entity;
        }
        public async Task CreateEntity(TEntity entity, bool tracked = false)
        {
            try
            {
                if (!tracked)
                {
                    _dbSet.AsNoTracking();
                }
                await _dbSet.AddAsync(entity);
                await SaveEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task DeleteEntity(TEntity entity, bool tracked = false)
        {
            try
            {
                if (!tracked)
                {
                    _dbSet.AsNoTracking();
                }
                _dbSet.Remove(entity);
                await SaveEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task UpdateEntity(string id, TEntity entity, bool tracked = false)
        {
            try
            {
                if (!tracked)
                {
                    _dbSet.AsNoTracking();
                }
                _db.Entry(entity).State = EntityState.Modified;
                await SaveEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task SaveEntity()
        {
            await _db.SaveChangesAsync(false);
        }
    }
}
