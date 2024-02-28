namespace MagicVillaAPI.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllEntity();

        Task<TEntity> GetEntityById(string id);

        Task CreateEntity(TEntity entity);

        Task UpdateEntity(string id, TEntity entity);

        Task DeleteEntity(TEntity entity);

        Task SaveEntity();
    }
}
