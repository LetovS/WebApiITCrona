using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebApiITCrona.DI;
using WebApiITCrona.Infrastructure.Options;
using WebApiITCrona.Infrastructure.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddFluentValidationAutoValidation(cfg =>
    {
        cfg.DisableDataAnnotationsValidation = false;
    });
builder.Services.AddValidatorsFromAssemblyContaining<IpRequestValidator>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Web API",
        Version = "v1"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddCustomOptions(builder.Configuration);

var options = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<CustomHttpClientOptions>>();
builder.Services.AddCustomHttpClient(options);

builder.Services.AddCallStorageContext(builder.Configuration);

builder.Services.AddServices();

builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
