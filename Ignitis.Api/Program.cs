using Ignitis.Api;
using Ignitis.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStorageContext(builder.Configuration);
builder.Services.AddDependencies();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ignitis API V1");
        c.RoutePrefix = "swagger";
    });

    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (builder.Environment.IsDevelopment())
    app.Services.MigrateDatabase();

app.Run();
