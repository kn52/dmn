using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.EntityContext.DBContext.Common;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Mappers;
using MagicVillaAPI.Repositories;
using MagicVillaAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static WebApplicationBuilder AddServiceConfigurationExtensions(this WebApplicationBuilder _builder)
        {
            _builder.Services.AddDbContext<CommonDBContext>(options =>
            {
                var _connect = _builder.Configuration["ConnectionStrings:MySqlConnection"];
                options.UseMySql(_connect, ServerVersion.AutoDetect(_connect));
            });

            _builder.Services.AddControllers()
            .AddNewtonsoftJson()
            .AddXmlDataContractSerializerFormatters();
            _builder.Services.AddEndpointsApiExplorer();
            
            _builder.Services.AddSwaggerGen();
            _builder.Services.AddSingleton<ILogging, Logging>();
            _builder.Services.AddScoped<MagicVillaService>();
            _builder.Services.AddScoped<MagicVillaRepository>();
            _builder.Services.AddAutoMapper(typeof(MapperConfig));

            return _builder;
        }
    }
}
