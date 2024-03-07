using MagicVilla_Web.Mappers;
using MagicVillaServiceJ;
using System.Configuration;

namespace MagicVilla_Web.Extensions
{
    public static class Extensions
    {
        // Http Configurations
        public static WebApplicationBuilder AddServiceConfigs(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();

            // Services
            builder.Services.AddHttpClient<MagicVillaServiceJClient>(o =>
            {
                o.BaseAddress = new Uri(builder.Configuration["ServiceUrls:BaseUrl"]);
            });

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
