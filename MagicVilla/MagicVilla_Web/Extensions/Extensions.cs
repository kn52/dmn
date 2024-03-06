using MagicVilla_Web.Mappers;
using VillaService;

namespace MagicVilla_Web.Extensions
{
    public static class Extensions
    {
        // Http Configurations
        public static WebApplicationBuilder AddServiceConfigs(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MapperConfig));


            // Services
            var baseURI = builder.Configuration["ServiceUrls:BaseUrl"];
            builder.Services.AddHttpClient<VillaServiceClient>(o => o.BaseAddress = new Uri(baseURI));

            builder.Services.AddScoped<VillaServiceClient>();

            return builder;
        }


        // Http Configurations
        public static WebApplication AddHttpConfigs(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            app.Run();

            return app;
        }
    }
}
