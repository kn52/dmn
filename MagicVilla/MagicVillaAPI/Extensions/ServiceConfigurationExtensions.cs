using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Mappers;
using MagicVillaAPI.Repositories;
using MagicVillaAPI.Repositories.Generic;
using MagicVillaAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static WebApplicationBuilder AddBasicServiceConfigurationExtensions(this WebApplicationBuilder _builder)
        {
            _builder.Services.AddDbContext<CommonDBContext>(options =>
            {
                var _connect = _builder.Configuration["ConnectionStrings:MySqlConnection"];
                options.UseMySql(_connect, ServerVersion.AutoDetect(_connect));
            });
            //_builder.Services.AddDbContext<CommonDBContext>(options =>
            //{
            //    var _connect = _builder.Configuration["ConnectionStrings:SqlServerConnection"];
            //    options.UseSqlServer(_connect);
            //});

            _builder.Services.AddControllers()
            .AddNewtonsoftJson()
            .AddXmlDataContractSerializerFormatters();
            _builder.Services.AddEndpointsApiExplorer();
            
            _builder.Services.AddSwaggerGen();
            _builder.Services.AddSingleton<ILogging, Logging>();
            _builder.Services.AddAutoMapper(typeof(MapperConfig));

            return _builder;
        }
        public static WebApplicationBuilder AddOtherServiceConfigurationExtensions(this WebApplicationBuilder _builder)
        {
            //Services
            _builder.Services.AddScoped<MagicVillaService>();
            _builder.Services.AddScoped<VillaNumberService>();
            _builder.Services.AddScoped<UserService>();

            //Repositories
            //_builder.Services.AddScoped<MagicVillaAPI.Repositories.Generic.IGenericRepository, MagicVillaAPI.Repositories.Generic.GenericRepository>();
            _builder.Services.AddScoped<MagicVillaRepository>();
            _builder.Services.AddScoped<VillaNumberRepository>();
            _builder.Services.AddScoped<UserRepository>();

            return _builder;
        }
    }
}
