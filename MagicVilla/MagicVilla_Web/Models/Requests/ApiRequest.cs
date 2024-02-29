using System.Net;
using static MagicVilla_Uitility.SD;

namespace MagicVilla_Web.Models.Requests
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
