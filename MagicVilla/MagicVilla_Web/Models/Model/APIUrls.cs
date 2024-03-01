namespace MagicVilla_Web.Models.Model
{
    public class APIUrls
    {
        public string GetAllUrl { get; set; }
        public string GetUrl { get; set; }
        public string CreateUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string UpdateUrl { get; set; }
        public string PatchUrl { get; set; }
    }
    public class VillaApiUrls
    {
        public string BaseUrl { get; set; }
        public VillaUrls VillaUrls { get; set; }
    }
    public class VillaUrls : APIUrls { }
    public class VillaNumberApiUrls
    {
        public string BaseUrl { get; set; }

        public VillaNumberUrls VillaNumberUrls { get; set; }
    }
    public class VillaNumberUrls : APIUrls { }
}
