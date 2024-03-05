using System.Linq.Expressions;

namespace MagicVillaAPI.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllEntity(Expression<Func<TEntity, bool>>? filter = null, bool tracked = false);

        Task<IQueryable<TEntity>> GetEntityByPropety(Expression<Func<TEntity, bool>>? filter = null, bool tracked = false);

        Task CreateEntity(TEntity entity, bool tracked = false);

        Task UpdateEntity(string id, TEntity entity, bool tracked = false);

        Task DeleteEntity(TEntity entity, bool tracked = false);

        Task SaveEntity();
    }
}
