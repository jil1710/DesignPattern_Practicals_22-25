using BusinessAccessLayer;
using BusinessAccessLayer.Models;
using CQRSPattern.Interfaces;
using CQRSPattern.Repository;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Repository;
using Serilog;
using MediatR;
using System.Reflection;
using MediatorComponent.Repository;
using DataAccessLayer.DataConnection;
using MediatorComponent.Validation;
using MediatorComponent.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllers();

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

// Singleton
builder.Services.AddScoped<IDataAccessService, DataAccessService>();

// Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// CQRS
builder.Services.AddScoped<IEmployeeQueryRepository, EmployeeQueryRepository>();
builder.Services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();

// Factory
builder.Services.AddScoped<IOverTimePaymentDetails, OverTimePaymentDetailsIT>();

// Mediator
builder.Services.AddScoped<IValidator<Employee>, EmployeeValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
    var Assemblies = new List<Assembly>();

    foreach (var item in assemblyNames)
    {
        Assemblies.Add(Assembly.Load(item));
    }
    foreach (var item in Assemblies)
    {
        x.RegisterServicesFromAssembly(item);
    }
});
builder.Services.AddScoped<IEmployeeRepositoryforMediator, EmployeeRepositoryforMediator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
