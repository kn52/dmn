using MagicVilla_Web.Mappers;
using MagicVillaServiceJ;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
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

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.ConfigureApplicationCookie(o =>
            {
                o.Cookie.HttpOnly = true;
                o.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                o.LoginPath = "/User/Login";
                o.SlidingExpiration = true;
                //o.Cookie.Domain = builder.Configuration.GetValue<string>("Domains:PoppinDomain");
                //o.Cookie.Name = ".AspNet.SharedCookie";
                //o.Cookie.Path = "/";
                //o.AccessDeniedPath = "/AccessDenied";

            });
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
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
            app.UseSession();
            app.UseAuthentication();
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
