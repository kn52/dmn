using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Models.Responses;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBasicService
    {
        ApiResponse ApiResponse { get; set; }
        Task<T> GetAsync<T>(ApiRequest<T> _apiRequest);
    }
}
