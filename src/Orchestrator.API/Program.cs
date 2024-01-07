using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Orchestrator.DataAccess.Models;
using Orchestrator.DataAccess.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Options
builder.Services.Configure<MongoDbOptions>(builder.Configuration.GetSection("MongoDb"));

// MongoDB
builder.Services.AddScoped<IMongoCollection<WorkflowModel>>(provider =>
{
    var mongoOptions = provider.GetService<IOptions<MongoDbOptions>>()?.Value;
    
    if(mongoOptions is null)
    {
        throw new ArgumentNullException("Settings for MongoDB are empty!");
    }

    return new MongoClient(mongoOptions.ConnectionUri)
                .GetDatabase(mongoOptions.DatabaseName)
                .GetCollection<WorkflowModel>(mongoOptions.CollectionName);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
