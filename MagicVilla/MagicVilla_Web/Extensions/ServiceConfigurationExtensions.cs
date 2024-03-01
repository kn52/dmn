using MagicVilla_Web.Mappers;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static WebApplicationBuilder AddServiceConfigurationExtensions(this WebApplicationBuilder _builder)
        {
            _builder.Services.AddControllersWithViews();
            _builder.Services.AddAutoMapper(typeof(MapperConfig));
            
            //_builder.Services.AddHttpClient("MyHttpClient", client =>
            //{
            //    client.BaseAddress = new Uri(_builder.Configuration["ServiceUrls:BaseUrl"]);
            //});
            
            _builder.Services.AddHttpClient<IVillaService, VillaService>();
            _builder.Services.AddHttpClient<IVillaNumberService, VillaNumberService>();


            _builder.Services.AddScoped<IVillaService, VillaService>();
            _builder.Services.AddScoped<IVillaNumberService, VillaNumberService>();

            return _builder;
        }
    }
}
