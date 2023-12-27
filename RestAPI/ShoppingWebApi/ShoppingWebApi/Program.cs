using Microsoft.EntityFrameworkCore;
using ShoppingWebApi.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Ef_DataContext>(
    o=>o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db"))
    );

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
