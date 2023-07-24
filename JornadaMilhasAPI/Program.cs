using JornadaMilhasAPI.Data.Interfaces;
using JornadaMilhasAPI.Data.Repositories;
using JornadaMilhasAPI.Services;
using JornadaMilhasAPI.Services.Interfaces;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddTransient(x =>
  new MySqlConnection(builder.Configuration.GetConnectionString("JornadaMilhas")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDepoimentoRepository, DepoimentoRepository>();
builder.Services.AddScoped<IDepoimentoService, DepoimentoService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JornadaMilhasAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddSwaggerGen();
//https://mysqlconnector.net/tutorials/dapper/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();

});
app.UseAuthorization();

app.MapControllers();

app.Run();
