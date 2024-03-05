using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace MagicVillaAPI.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        public readonly CommonDBContext _db;
        public DbSet<TEntity> _dbSet;

        public GenericRepository(CommonDBContext db)
        {
            _db = db;
            _db.VillaNumbers.Include(u => u.Villa).ToList();
            this._dbSet = _db.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllEntity(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

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
            var _list = await query.ToListAsync();
            return _list;
        }
        public async Task<TEntity> GetEntityByPropety(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true, string? includeProperties = null)
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
            if (includeProperties != null)
            {
                foreach (var incudeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    entity.Include(incudeProp);
                }
            }
            var _entity = await entity.FirstOrDefaultAsync();

            return _entity;
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
