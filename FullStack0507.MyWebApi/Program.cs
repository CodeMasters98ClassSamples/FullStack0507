using FullStack0507.MyWebApi.Data;
using FullStack0507.MyWebApi.Intefaces;
using FullStack0507.MyWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//packages , Framework , IOC Container
builder.Services.AddScoped<IProductService,ProductService>();

bool develop = true;
if (develop)
{

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("AppDbContextInMemory"));
}
else
{
    string connectionString = builder.Configuration.GetConnectionString("AppDbContext") ??
    throw new InvalidOperationException("Connection string 'AppDbContext' not found.");

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}



//before -> Service Collection
var app = builder.Build();
//Afte -> Service Provider

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
