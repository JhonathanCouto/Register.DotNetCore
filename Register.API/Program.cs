using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Mediator;
using DotNetCore.Results;
using DotNetCore.Services;
using Microsoft.EntityFrameworkCore;
using Register.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddJsonStringLocalizer();
builder.Services.AddResultService();
builder.Services.AddContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(Context))));
builder.Services.AddClassesMatchingInterfaces(nameof(Register));
builder.Services.AddMediator(nameof(Register));
builder.Services.AddControllers().AddJsonOptions();

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
