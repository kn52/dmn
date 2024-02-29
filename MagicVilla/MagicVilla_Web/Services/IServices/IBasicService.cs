using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Models.Responses;
using System.Threading.Tasks;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBasicService
    {
        //APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest _apiRequest);
    }
}
