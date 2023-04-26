using DogBreedApp.Server.Data;
using DogBreedApp.Server.Services;
using DogBreedApp.Server.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexión SQLite
builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"] = "Data Source=dogbreeds.db";

// Agregar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddScoped<IDogService, DogService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllCors", new CorsPolicyBuilder()
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .Build());
});
var app = builder.Build();
app.UseCors("AllowAllCors");

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dbContext.Database.Migrate();
}

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
