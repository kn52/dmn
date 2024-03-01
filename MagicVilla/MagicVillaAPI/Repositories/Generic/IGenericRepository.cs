using System.Linq.Expressions;

namespace MagicVillaAPI.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllEntity(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true, string? includeProperties = null);

        Task<TEntity> GetEntityByPropety(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true, string? includeProperties = null);

        Task CreateEntity(TEntity entity);

        Task UpdateEntity(string id, TEntity entity);

        Task DeleteEntity(TEntity entity);

        Task SaveEntity();
    }
}
