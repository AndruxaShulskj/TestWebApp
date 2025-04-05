using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using TestWebApp.Business;
using TestWebApp.DataAccess;
using TestWebApp.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDataAccess();
builder.Services.RegisterBusiness();
builder.Services.RegisterDto();

var app = builder.Build();

var provider = builder.Services.BuildServiceProvider();

DataAccessSetup.DatabaseMigration(provider);

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
