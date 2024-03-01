using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVillaAPI.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        public readonly CommonDBContext _db;

        public GenericRepository(CommonDBContext db)
        {
            _db = db;
        }
        public IQueryable<TEntity> GetAllEntity(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true, string? includeProperties = null)
        {
            var query = _db.Set<TEntity>();

            if (!tracked)
            {
                query.AsNoTracking();
            }

            if (includeProperties != null)
            {
                foreach (var incudeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(incudeProp);
                }
            }
            return query;
        }
        public async Task<TEntity> GetEntityByPropety(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<TEntity> entity = _db.Set<TEntity>();
            if (!tracked)
            {
                entity.AsNoTracking();
            }
            if (filter != null)
            {
                entity = entity.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var incudeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    entity.Include(incudeProp);
                }
            }

            return await entity.FirstOrDefaultAsync();
        }
        public async Task CreateEntity(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await SaveEntity();
        }
        public async Task DeleteEntity(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
            await SaveEntity();
        }
        public async Task UpdateEntity(string id, TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await SaveEntity();
        }
        public async Task SaveEntity()
        {
            await _db.SaveChangesAsync(false);
        }
    }
}
