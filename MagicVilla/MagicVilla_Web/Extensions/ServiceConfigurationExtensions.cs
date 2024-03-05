using MagicVilla_Web.Mappers;

namespace MagicVilla_Web.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static WebApplicationBuilder AddServiceConfigurationExtensions(this WebApplicationBuilder _builder)
        {
            _builder.Services.AddControllersWithViews();
            _builder.Services.AddAutoMapper(typeof(MapperConfig));
            
            return _builder;
        }
    }
}
