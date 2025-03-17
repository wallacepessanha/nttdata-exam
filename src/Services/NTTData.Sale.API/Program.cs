using FluentValidation.Results;
using MediatR;
using Microsoft.OpenApi.Models;
using NTTData.Core.Mediator;
using NTTData.Sale.API.Application.Commands;
using NTTData.Sale.API.Application.Commands.Handlers;
using NTTData.Sale.API.Application.Events;
using NTTData.Sale.API.Application.Events.Handlers;
using NTTData.Sale.API.Configuration;
using NTTData.Sale.Domain.Repositories;
using NTTData.Sale.Infra.Data.Repository;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSql(builder.Configuration);
builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "NTTDATA DeveloperStore team",
        Description = "This API is an exam for NTTDATA.",
        Contact = new OpenApiContact() { Name = "Wallace Pessanha" },
        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });   

});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
// Application
builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();

// Events
builder.Services.AddScoped<INotificationHandler<SaleCreatedEvent>, SaleCreatedEventHandler>();
builder.Services.AddScoped<INotificationHandler<SaleCancelledEvent>, SaleCancelledEventHandler>();
builder.Services.AddScoped<INotificationHandler<SaleItemCancelledEvent>, SaleItemCancelledEventHandler>();

// Commands
builder.Services.AddScoped<IRequestHandler<SaleCreatedCommand, ValidationResult>, SaleCreatedCommandHandler>();
builder.Services.AddScoped<IRequestHandler<SaleCancelledCommand, ValidationResult>, SaleCancelledCommandHandler>();
builder.Services.AddScoped<IRequestHandler<SaleItemCancelledCommand, ValidationResult>, SaleItemCancelledCommandHandler>();

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
