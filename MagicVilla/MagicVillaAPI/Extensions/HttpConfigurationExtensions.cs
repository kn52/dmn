namespace MagicVillaAPI.Extensions
{
    public static class HttpConfigurationExtensions
    {
        public static WebApplication AddHttpConfigurationExtensions(this WebApplication _app)
        {
            if (_app.Environment.IsDevelopment())
            {
                _app.UseSwagger();
                _app.UseSwaggerUI();
            }

            _app.UseHttpsRedirection();
            _app.UseAuthorization();
            _app.MapControllers();
            _app.Run();

            return _app;
        }
    }
}
