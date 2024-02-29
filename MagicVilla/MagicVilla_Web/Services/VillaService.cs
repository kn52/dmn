using MagicVilla_Web.Models.DAO;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Model;
using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services.IServices;
using MagicVilla_Web.Utilities.HttpMethodTypes;
using static MagicVilla_Uitility.SD;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly VillaApiUrls villaUrls;
        public VillaService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            villaUrls = configuration.GetSection("ServiceUrls:VillaUrls").Get<VillaApiUrls>();
        }
        public async Task<T> GetAllAsync<T>()
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.GET),
                Url = villaUrls.GetAllUrl
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> GetAsync<T>(string id)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.GET),
                Url = string.Format(villaUrls.GetUrl, id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> CreateAsync<T>(VillaDTO villaDTO)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.POST),
                Data = villaDTO,
                Url = villaUrls.CreateUrl
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> DeleteAsync<T>(string id)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.DELETE),
                Url = string.Format(villaUrls.DeleteUrl, id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> UpdateAsync<T>(VillaDTO villaDTO)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.PUT),
                Data = villaDTO,
                Url = string.Format(villaUrls.UpdateUrl, villaDTO.Id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
    }
}
