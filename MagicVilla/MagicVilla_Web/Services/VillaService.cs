using MagicVilla_Web.Models.DAO;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Model;
using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services.IServices;
using static MagicVilla_Uitility.SD;

namespace MagicVilla_Web.Services
{
    public class VillaService<T> : BaseService<ApiResponse<T>>, IVillaService where T : class
    {
        private VillaApiUrls villaUrls;
        public VillaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            villaUrls = configuration.GetSection("ServiceUrls:VillaUrls").Get<VillaApiUrls>();
        }

        public async Task<T> CreateAsync<T>(VillaDTO villaDTO)
        {
            var _response = await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = villaDTO,
                Url = villaUrls.CreateUrl
            });
            return _response;
        }

        public async Task<T> DeleteAsync<T>(string id)
        {
            var _response = await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = string.Format(villaUrls.DeleteUrl, id)
            });
            return _response;
        }

        public async Task<T> GetAllAsync<T>()
        {
            var _response = await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = villaUrls.GetAllUrl
            });
            return _response;
        }

        public async Task<T> GetAsync<T>(string id)
        {
            var _response = await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = string.Format(villaUrls.GetUrl, id)
            });
            return _response;
        }

        public async Task<T> UpdateAsync<T>(VillaDTO villaDTO)
        {
            var _response =  await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = villaDTO,
                Url = string.Format(villaUrls.UpdateUrl, villaDTO.Id)
            });
            return _response;
        }
    }
}
