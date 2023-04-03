using Core.Interfaces;
using Infrastrcuture.Data;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>
    (options=>options.UseSqlite(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenreicRepsitory<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DBContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try {

    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);

}catch(Exception ex) {

    logger.LogError(ex, "Error Occured while migrationg process");
}
app.Run();
