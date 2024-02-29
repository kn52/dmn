using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Models.Responses;
using System.Threading.Tasks;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBasicService<TEntity> where TEntity : class
    {
        ApiResponse<TEntity> ApiResponse { get; set; }
        Task<TEntity> SendAsync<TEntity>(ApiRequest _apiRequest);
    }
}
