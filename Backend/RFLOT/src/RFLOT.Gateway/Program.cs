using System.Reflection;
using Microsoft.AspNetCore.HttpLogging;
using Prometheus;
using RFLOT.Application;
using RFLOT.Application.Monitoring;
using RFLOT.Gateway.Endpoints;
using RFLOT.Gateway.Metrics;
using RFLOT.Gateway.Middlewares;
using RFLOT.Gateway.Swagger;
using RFLOT.Identity;
using Serilog;
using Serilog.Sinks.Elasticsearch;

const string polity = "https://10.147.17.151";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MetricReporter>();
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

builder.Services.AddIdentity(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
ConfigureLogging();
builder.Host.UseSerilog();
builder.Services.AddHealthChecks();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: polity,
        policy =>
        {
            policy.WithOrigins("https://10.147.17.151", "https://10.147.17.151:5031", "https://10.147.17.151:5032",
                "http://10.147.17.251:5050");
        });
});

builder.SetupSwagger();

builder.Services.Configure<RouteOptions>(
    options =>
    {
        options.LowercaseUrls = true;
        options.LowercaseQueryStrings = true;
    }
);

var app = builder.Build();
app.UseHttpLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMetricServer();
app.UseMiddleware<ResponseMetricMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHealthChecks("/health");
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
//Endpoints
app.MapHub<MonitoringHub>("/hub");
app.AddAuthEndpoints();
app.AddEquipEndpoints();
app.AddPlaneEndpoints();
app.AddZoneEndpoints();
app.AddReportEndpoints();
app.AddMonitoringEndpoints();
app.AddSystemEndpoints();
app.AddAnalyticEndpoints();
app.Run();

void ConfigureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(
            $"appsettings.{environment}.json", optional: true
        )
        .Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment!))
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    return new ElasticsearchSinkOptions(new Uri(Environment.GetEnvironmentVariable("ELASTIC_ROUTE") ??
                                                configuration["ElasticConfiguration:Uri"]!))
    {
        AutoRegisterTemplate = true,
        IndexFormat =
            $"route-{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
        NumberOfReplicas = 1,
        NumberOfShards = 2
    };
}