using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using StoreAdministrationSystem.Integration.Client;
using Hellang.Middleware.ProblemDetails;
using System.Text.Json.Serialization;
using StoreAdministrationSystem.Admin.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddStorerAdministrationServiceRefitClient(builder.Configuration.GetSection("Integrations:KycService")
    .Get<HttpStoreAdministrationServiceClientOptions>()!);

builder.Services.AddHttpLogging(options => options.LoggingFields = HttpLoggingFields.All);

builder.Services.AddProblemDetails(options =>
{
    options.ValidationProblemStatusCode = 400;
});

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsOptions = builder.Configuration.GetSection("Cors").Get<CorsOptions>()!;

builder.Services.AddCors(options =>
{
    if (corsOptions.Name == "AnyOrigins")
    {
        options.AddPolicy("AnyOrigins", policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
            .AllowAnyHeader();
        });
    }

    if (corsOptions.Name == "SpecificOrigins")
    {
        options.AddPolicy("SpecificOrigins", policyBuilder =>
        {
            policyBuilder.WithOrigins(corsOptions.Origins)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsOptions.Name);

app.UseProblemDetails();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
