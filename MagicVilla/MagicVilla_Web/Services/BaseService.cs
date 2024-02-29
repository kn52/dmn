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
    public class BaseService : IBasicService
    {
        private IHttpClientFactory _httpClientFactory { get; set; }

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> SendAsync<T>(APIRequest _apiRequest)
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
                _message.Method = _apiRequest.HttpMethodType;
                var _apiResponse = await _client.SendAsync(_message);
                var _apiContent = _apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(_apiContent.Result);
                //var returnResponse = (TEntity)APIResponse;
                return APIResponse;
            }
            catch (Exception ex)
            {
                var _res = JsonConvert.SerializeObject(new APIResponse<T>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                });
                var APIResponse = JsonConvert.DeserializeObject<T>(_res);
                return APIResponse;
            }
        }
    }
}
