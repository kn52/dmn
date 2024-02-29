namespace MagicVilla_Web.Extensions
{
    public static class HttpConfigurationExtensions
    {
        public static WebApplication AddHttpConfigurationExtensions(this WebApplication _app)
        {
            if (!_app.Environment.IsDevelopment())
            {
                _app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _app.UseHsts();
            }

            _app.UseHttpsRedirection();
            _app.UseStaticFiles();

            _app.UseRouting();

            _app.UseAuthorization();

            _app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            _app.Run();

            return _app;
        }

    }
}
