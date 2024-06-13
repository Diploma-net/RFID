using Microsoft.AspNetCore.HttpLogging;

const string polity = "https://10.147.17.151";

var builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddHealthChecks();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: polity,
        policy =>
        {
            policy.WithOrigins("https://10.147.17.151", "https://10.147.17.151:5031", "https://10.147.17.151:5032",
                    "http://10.147.17.251:5050")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
    options.AddPolicy("reactHub", builder =>
    {
        builder.WithOrigins("https://10.147.17.151:5032/hub")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();
app.UseHttpsRedirection();
app.Run();