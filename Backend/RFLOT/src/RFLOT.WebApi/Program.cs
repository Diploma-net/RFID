using MediatR;
using Microsoft.AspNetCore.Mvc;
using RFLOT.Application;
using RFLOT.WebApi.Endpoints;
using RFLOT.WebApi.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApplication(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

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
app.AddEquipEndpoints();
app.AddZoneEndpoints();
app.MapPost("/auth",  (string login, string pass) =>
{
    if (login == "admin" && login == "admin")
    {
        return Results.Ok("admin");
    }
    return Results.NotFound();
});

app.Run();

