using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Services.IServices;
using static MagicVilla_Uitility.SD;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private string baseUrl;
        public VillaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            baseUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public async Task<T> CreateAsync<T>(VillaDTO villaDTO)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = villaDTO,
                Url = string.Format("{0}/api/Villa", baseUrl)
            }); 
        }

        public async Task<T> DeleteAsync<T>(string id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = string.Format("{0}/api/Villa/{1}", baseUrl, id)
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = string.Format("{0}/api/Villa", baseUrl)
            });
        }

        public async Task<T> GetAsync<T>(string id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = string.Format("{0}/api/Villa/{1}", baseUrl, id)
            });
        }

        public async Task<T> UpdateAsync<T>(VillaDTO villaDTO)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = villaDTO,
                Url = string.Format("{0}/api/Villa", baseUrl)
            });
        }
    }
}
