using System.Net;

namespace MagicVilla_Web.Models.Responses
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Success!";
        public T Result { get; set; }
    }
}
