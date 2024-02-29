using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(string id);
        Task<T> CreateAsync<T>(VillaNumberDTO model);
        Task<T> UpdateAsync<T>(VillaNumberDTO model);
        Task<T> DeleteAsync<T>(string id);
    }
}
