using BookStoreAPI.Models;
using BookStoreAPI.EfCore;
using BookStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

// builder.Services.Configure<BookStoreDatabaseSettings>(
//     builder.Configuration.GetSection("BookStoreDatabase"));

builder.Services.AddScoped<BookService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();