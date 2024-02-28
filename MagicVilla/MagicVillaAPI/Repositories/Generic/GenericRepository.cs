using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        public readonly CommonDBContext _db;

        public GenericRepository(CommonDBContext db)
        {
            _db = db;
        }
        public IQueryable<TEntity> GetAllEntity()
        {
            return _db.Set<TEntity>();
        }
        public async Task<TEntity> GetEntityById(string id)
        {
            var entity = await _db.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == new Guid(id));
            return entity;
        }
        public async Task CreateEntity(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await SaveEntity();
        }
        public async Task<TEntity> DeleteEntity(string id)
        {
            var entity = await GetEntityById(id);
            _db.Set<TEntity>().Remove(entity);
            await SaveEntity();
            return entity;
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
