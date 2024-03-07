using MagicVilla_Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceConfigs();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddHttpConfigs();