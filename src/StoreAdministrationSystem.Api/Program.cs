using StoreAdministrationSystem.DataAccess.PostgresSql;
using StoreAdministrationSystem.ReadModel.PostgresSql;
using Serilog;
using Microsoft.AspNetCore.HttpLogging;
using Hellang.Middleware.ProblemDetails;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var connectionString = builder.Configuration.GetConnectionString("postgres")!;

builder.Services.AddPostgresSqlRepositories(connectionString);
builder.Services.AddPostgresSqlReadModel(connectionString);

builder.Services.AddHttpLogging(options => { options.LoggingFields = HttpLoggingFields.All; });

builder.Services.AddProblemDetails(options =>
{
    options.IncludeExceptionDetails = (_, _) => builder.Environment.IsDevelopment();
});

builder.Services.AddControllers()
    .AddJsonOptions(options => 
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseProblemDetails();

app.MapControllers();

app.Run();
