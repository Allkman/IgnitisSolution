using Ignitis.Api;
using Ignitis.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddStorageContext(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddDependencies();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();              // Generates /swagger/v1/swagger.json
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger"; // Exposes at /swagger
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (builder.Environment.IsDevelopment())
    app.Services.MigrateDatabase();

app.Run();
