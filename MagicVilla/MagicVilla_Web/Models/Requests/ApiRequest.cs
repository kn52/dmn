namespace MagicVilla_Web.Models.Requests
{
    public class APIRequest
    {
        public HttpMethod HttpMethodType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
