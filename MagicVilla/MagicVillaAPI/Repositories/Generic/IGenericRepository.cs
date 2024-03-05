using System.Linq.Expressions;

namespace MagicVillaAPI.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllEntity(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true, string? includeProperties = null);

        Task<TEntity> GetEntityByPropety(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true, string? includeProperties = null);

        Task CreateEntity(TEntity entity, bool tracked = false);

        Task UpdateEntity(string id, TEntity entity, bool tracked = false);

        Task DeleteEntity(TEntity entity, bool tracked = false);

        Task SaveEntity();
    }
}
