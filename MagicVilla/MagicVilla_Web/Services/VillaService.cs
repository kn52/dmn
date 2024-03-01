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
        private readonly VillaApiUrls urls;
        public VillaService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            urls = configuration.GetSection("ServiceUrls").Get<VillaApiUrls>();
        }
        public async Task<T> GetAllAsync<T>()
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.GET),
                Url = string.Format(urls.VillaUrls.GetAllUrl, urls.BaseUrl)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> GetAsync<T>(string id)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.GET),
                Url = string.Format(urls.VillaUrls.GetUrl, urls.BaseUrl, id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> CreateAsync<T>(VillaDTO model)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.POST),
                Data = model,
                Url = string.Format(urls.VillaUrls.CreateUrl, urls.BaseUrl)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> DeleteAsync<T>(string id)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.DELETE),
                Url = string.Format(urls.VillaUrls.DeleteUrl, urls.BaseUrl, id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> UpdateAsync<T>(VillaDTO model)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.PUT),
                Data = model,
                Url = string.Format(urls.VillaUrls.UpdateUrl, urls.BaseUrl, model.Id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
    }
}
