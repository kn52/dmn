using MagicVillaAPI.Logger;
using MagicVillaAPI.Services.DBContext;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Extensions
{
    public static class Extensions
    {
        public static WebApplicationBuilder AddExtensions(this WebApplicationBuilder _builder)
        {
            _builder.Services.AddSwaggerGen();
            _builder.Services.AddSingleton<ILogging, Logging>();
            
            return _builder;
        }
    }
}
