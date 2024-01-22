using System.ComponentModel;
using GeniuseeTestTask.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("Rainfall API", new OpenApiInfo
    {
        Title = "Rainfall API",
        Version = "1.0",
        Description = "An API which provides rainfall reading data"
    });
    options.AddServer(new OpenApiServer
    {
        Url = "http://localhost:3000",
        Description = "Rainfall Api"
    });
    options.IncludeXmlComments(@"C:\Users\Admin\source\repos\GeniuseeTestTask\GeniuseeTestTask\obj\Debug\net7.0\GeniuseeTestTask.xml", true);
    options.EnableAnnotations();
    options.CustomSchemaIds(x => x.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? x.FriendlyId());
});
builder.Services.AddRainfallServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/Rainfall API/swagger.json", "Rainfall API");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
