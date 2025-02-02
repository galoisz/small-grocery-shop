using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Persistence;
using WebApi.Persistence.Repositories;
using WebApi.Persistence.Repositories.Interfaces;
using WebApi.Services;
using WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader());
});

builder.Services.AddDbContext<CashFlowDataContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<ICashFlowService, CashFlowService>();
builder.Services.AddScoped<ICashFlowRepository, CashFlowRepository>();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<CashFlowProfile>();
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.MapControllers();
app.Run();
