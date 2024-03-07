using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Mappers;
using MagicVillaAPI.Repositories;
using Microsoft.Extensions.Options;
using MagicVillaAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Extensions
{
    public static class Extensions
    {
        // Service Configurations
        public static WebApplicationBuilder AddServiceConfigs(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CommonDBContext>(options =>
            {
                var _connect = builder.Configuration["ConnectionStrings:MySqlConnection"];
                options.UseMySql(_connect, ServerVersion.AutoDetect(_connect));
            });

            builder.Services.AddControllers()
            .AddNewtonsoftJson()
            .AddXmlDataContractSerializerFormatters();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<ILogging, Logging>();
            builder.Services.AddAutoMapper(typeof(MapperConfig));


            //Services
            builder.Services.AddScoped<MagicVillaService>();
            builder.Services.AddScoped<VillaNumberService>();
            builder.Services.AddScoped<UserService>();

            //Repositories
            //builder.Services.AddScoped<MagicVillaAPI.Repositories.Generic.IGenericRepository, MagicVillaAPI.Repositories.Generic.GenericRepository>();
            builder.Services.AddScoped<MagicVillaRepository>();
            builder.Services.AddScoped<VillaNumberRepository>();
            builder.Services.AddScoped<UserRepository>();

            return builder;
        }


        // Http Configurations
        public static WebApplication AddHttpConfigs(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

            return app;
        }
    }
}
