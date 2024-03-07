using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Mappers;
using MagicVillaAPI.Repositories;
using MagicVillaAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using MagicVillaAPI.Utilities.Jwt;

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

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(y =>
                {
                    y.RequireHttpsMetadata = true;
                    y.SaveToken = true;
                    y.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["SecretKey"]))
                    };
                });

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            builder.Services.AddSingleton<ILogging, Logging>();
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddScoped<JwtTokenGeneration>();
            builder.Services.AddScoped<MapperConfig>();

            //Services
            builder.Services.AddScoped<MagicVillaService>();
            builder.Services.AddScoped<VillaNumberService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<UserRoleService>();
            

            //Repositories
            //builder.Services.AddScoped<MagicVillaAPI.Repositories.Generic.IGenericRepository, MagicVillaAPI.Repositories.Generic.GenericRepository>();
            builder.Services.AddScoped<MagicVillaRepository>();
            builder.Services.AddScoped<VillaNumberRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<UserRoleRepository>();

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
