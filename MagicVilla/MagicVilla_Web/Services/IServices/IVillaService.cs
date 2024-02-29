using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(string id);
        Task<T> CreateAsync<T>(VillaDTO model);
        Task<T> UpdateAsync<T>(VillaDTO model);
        Task<T> DeleteAsync<T>(string id);
    }
}
