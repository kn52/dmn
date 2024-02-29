using MagicVilla_Web.Models.Requests;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services.IServices;
using System.Text;
using System.Text.Json;
using static MagicVilla_Uitility.SD;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBasicService
    {
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            ApiResponse = new();
            _httpClientFactory = httpClientFactory;
        }

        public ApiResponse ApiResponse { get; set; }
        public IHttpClientFactory _httpClientFactory { get; set; }

        public async Task<T> SendAsync<T>(ApiRequest _apiRequest)
        {
            try
            {
                var _client = _httpClientFactory.CreateClient("MagicAPI");
                var _message = new HttpRequestMessage();
                _message.Headers.Add("Accept", "application/json");
                _message.Headers.Add("Content-Type", "application/json");
                _message.RequestUri = new Uri(_apiRequest.Url);
                if (_apiRequest.Data != null)
                {
                    _message.Content = new StringContent(JsonSerializer.Serialize(_apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                _message.Method = GetMethodType(_apiRequest.ApiType);
                var _apiResponse = await _client.SendAsync(_message);
                var _apiContent = await _apiResponse.Content.ReadAsStringAsync(); 
                var APIResponse = JsonSerializer.Deserialize<T>(_apiContent);
                return APIResponse;
            }
            catch (Exception ex) {
                var _res = JsonSerializer.Serialize(new ApiResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                });
                var APIResponse = JsonSerializer.Deserialize<T>(_res);
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
