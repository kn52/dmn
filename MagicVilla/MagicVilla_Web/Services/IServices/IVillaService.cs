using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Responses;
using System.Threading.Tasks;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(string id);
        Task<T> CreateAsync<T>(VillaDTO villaDTO);
        Task<T> UpdateAsync<T>(VillaDTO villaDTO);
        Task<T> DeleteAsync<T>(string id);
    }
}
