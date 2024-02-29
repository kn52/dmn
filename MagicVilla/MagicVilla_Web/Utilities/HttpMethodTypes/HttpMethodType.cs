using static MagicVilla_Uitility.SD;

namespace MagicVilla_Web.Utilities.HttpMethodTypes
{
    public static class HttpMethodType
    {
        public static HttpMethod GetMethodType(ApiType _apiType)
        {
            return _apiType switch
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
