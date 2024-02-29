using MagicVilla_Web.Models.Requests;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBasicService
    {
        Task<T> SendAsync<T>(APIRequest _apiRequest);
    }
}
