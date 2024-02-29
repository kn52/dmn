using MagicVilla_Web.Models.Model;
using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static MagicVilla_Uitility.SD;

namespace MagicVilla_Web.Services
{
    public class BaseService<TEntity> : IBasicService<TEntity> where TEntity: class
    {
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            ApiResponse = new();
            _httpClientFactory = httpClientFactory;
        }

        public ApiResponse<TEntity> ApiResponse { get; set; }
        public IHttpClientFactory _httpClientFactory { get; set; }

        public async Task<TEntity> SendAsync<TEntity>(ApiRequest _apiRequest)
        {
            try
            {
                var _client = _httpClientFactory.CreateClient("MagicAPI");
                var _message = new HttpRequestMessage();
                _message.Headers.Add("Accept", "application/json");
                //_message.Headers.Add("Content-Type", "application/json");
                _message.RequestUri = new Uri(_apiRequest.Url);
                if (_apiRequest.Data != null)
                {
                    _message.Content = new StringContent(JsonConvert.SerializeObject(_apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                _message.Method = GetMethodType(_apiRequest.ApiType);
                var _apiResponse = await _client.SendAsync(_message);
                var _apiContent = _apiResponse.Content.ReadAsStringAsync(); 
                var APIResponse = JsonConvert.DeserializeObject<TEntity>(_apiContent.Result);
                //var returnResponse = (TEntity)APIResponse;
                return APIResponse;
            }
            catch (Exception ex) {
                var _res = JsonConvert.SerializeObject(new ApiResponse<TEntity>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                });
                var APIResponse = JsonConvert.DeserializeObject<TEntity>(_res);
                return APIResponse;
            }
            throw new NotImplementedException();
        }
        public HttpMethod GetMethodType(ApiType _apiType)
        {
            return _apiType  switch
            {
                ApiType.GET => HttpMethod.Get,
                ApiType.POST => HttpMethod.Post,
                ApiType.PUT => HttpMethod.Put,
                ApiType.DELETE => HttpMethod.Delete,
                ApiType.PATCH => HttpMethod.Patch,
                _ => HttpMethod.Get,
            };
        }
    }
}
