using Catelog.API.HostingService;
using Catelog.API.Interfaces.Manager;
using Catelog.API.Manager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<AppHostedService>();

//Controller depencyes
builder.Services.AddScoped<IProductManager, ProductManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() && app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
        options.DocumentTitle = "CatalogAPI - Microservices";
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
