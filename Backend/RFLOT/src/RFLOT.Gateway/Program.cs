using RFLOT.Application;
using RFLOT.Application.Monitoring;
using RFLOT.Gateway.Endpoints;
using RFLOT.Gateway.Monitoring;
using RFLOT.Gateway.Swagger;
using RFLOT.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddIdentity(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();

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
//Endpoints
app.MapHub<MonitoringHub>("/hub");
app.AddAuthEndpoints();
app.AddEquipEndpoints();
app.AddZoneEndpoints();

app.Run();