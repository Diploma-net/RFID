using RFLOT.Application;
using RFLOT.Application.Monitoring;
using RFLOT.BackgroundTasks;
using RFLOT.Gateway.Endpoints;
using RFLOT.Gateway.Swagger;
using RFLOT.Identity;
const string polity = "https://10.147.17.151";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddIdentity(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: polity,
        policy  =>
        {
            policy.WithOrigins("https://10.147.17.151", "https://10.147.17.151:5031","https://10.147.17.151:5032", "http://10.147.17.251:5050");
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
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
app.Run();
