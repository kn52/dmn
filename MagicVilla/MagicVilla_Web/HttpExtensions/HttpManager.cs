namespace MagicVilla_Web.HttpExtensions
{
    public class HttpManager
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public HttpManager(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public async Task<string> GetSessionDetailsByKey(string key)
        {
            await _contextAccessor.HttpContext.Session.LoadAsync().ConfigureAwait(false);
            return _contextAccessor.HttpContext.Session.GetString(key);
        }
    }
}
