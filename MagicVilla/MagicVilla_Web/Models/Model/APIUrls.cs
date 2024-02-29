namespace MagicVilla_Web.Models.Model
{
    public class APIUrls
    {
        public string BaseUrl { get; set; }
        public string GetAllUrl { get; set; }
        public string GetUrl { get; set; }
        public string CreateUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string UpdateUrl { get; set; }
        public string PatchUrl { get; set; }
    }
    public class VillaApiUrls : APIUrls
    {
    }
    public class VillaNumberApiUrls : APIUrls
    {
    }
}
