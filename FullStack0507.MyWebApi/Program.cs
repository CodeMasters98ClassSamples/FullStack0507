using Asp.Versioning;
using FullStack0507.MyInfrastructure;
using Microsoft.EntityFrameworkCore;
using FullStack0507.MyApplication;
using FullStack0507.MyWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("AppDbContext") ??
    throw new InvalidOperationException("Connection string 'AppDbContext' not found.");

builder.AddServiceDefaults();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddMyCors(MyAllowSpecificOrigins)
    .AddMyVersion()
    .AddMyApplicaion()
    .AddMyInfrastructure(connectionString);

var app = builder.Build();

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

app.MapHealthChecks("/healthz");

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
