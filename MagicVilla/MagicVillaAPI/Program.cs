using MagicVillaAPI.Extensions;
using MagicVillaAPI.Services.DBContext;
using Microsoft.EntityFrameworkCore;

var _builder = WebApplication.CreateBuilder(args);

// Add services to the container.
_builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var _connect = _builder.Configuration["ConnectionStrings:MySqlConnection"];
    options.UseMySql(_connect, ServerVersion.AutoDetect(_connect));
});
_builder.Services.AddControllers(op => {
    //op.ReturnHttpNotAcceptable = true
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_builder.Services.AddEndpointsApiExplorer();
_builder.AddExtensions();

var app = _builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
