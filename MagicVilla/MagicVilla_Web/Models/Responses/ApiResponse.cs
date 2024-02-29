using System.Net;

namespace MagicVilla_Web.Models.Responses
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Success!";
        public object Result { get; set; }
    }
}
