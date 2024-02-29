using MagicVilla_Web.Mappers;
using MagicVilla_Web.Models.Responses;
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
            
            _builder.Services.AddHttpClient<IVillaService, VillaService<T>>();
            _builder.Services.AddScoped(typeof(IVillaService), typeof(VillaService<ApiResponse<T>>));



            return _builder;
        }
    }
}
