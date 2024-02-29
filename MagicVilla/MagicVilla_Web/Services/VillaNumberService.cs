using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Model;
using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Services.IServices;
using MagicVilla_Web.Utilities.HttpMethodTypes;
using System.Reflection;
using static MagicVilla_Uitility.SD;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly VillaNumberApiUrls urls;
        public VillaNumberService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            urls = configuration.GetSection("ServiceUrls:VillNumberaUrls").Get<VillaNumberApiUrls>();
        }
        public async Task<T> GetAllAsync<T>()
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.GET),
                Url = urls.GetAllUrl
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> GetAsync<T>(string id)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.GET),
                Url = string.Format(urls.GetUrl, id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> CreateAsync<T>(VillaNumberDTO model)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.POST),
                Data = model,
                Url = urls.CreateUrl
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> DeleteAsync<T>(string id)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.DELETE),
                Url = string.Format(urls.DeleteUrl, id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
        public async Task<T> UpdateAsync<T>(VillaNumberDTO model)
        {
            var _req = new APIRequest()
            {
                HttpMethodType = HttpMethodType.GetMethodType(ApiType.PUT),
                Data = model,
                Url = string.Format(urls.UpdateUrl, model.Id)
            };
            var _response = await SendAsync<T>(_req);
            return _response;
        }
    }
}
