namespace MagicVillaServiceJ
{
    public partial class MagicVillaServiceJClient
    {
        public MagicVillaServiceJClient AddToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            return this;
        }
    }
}
