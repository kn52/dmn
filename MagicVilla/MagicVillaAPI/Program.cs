using MagicVillaAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceConfigs();

// Configuration object for the HTTP request pipeline.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddHttpConfigs();
