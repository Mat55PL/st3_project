using CarManageSystem.Infrastructure.Extensions;
using CarManageSystem.Infrastructure.Seeders;
using CarManageSystem.Application.Extensions;
using CarManageSystem.Infrastructure.Resolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});*/

builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddHttpClient<DocumentIntegrationDataResolver>();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
// Seed the database with some initial data
var seeder = scope.ServiceProvider.GetRequiredService<ICarSeeder>();

await seeder.Seed();
// Configure the HTTP request pipeline.



app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
