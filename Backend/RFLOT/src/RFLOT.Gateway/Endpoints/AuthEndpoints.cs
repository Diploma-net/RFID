using RFLOT.Identity;

namespace RFLOT.Gateway.Endpoints;

public static class AuthEndpoints
{
    public static WebApplication AddAuthEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/auth");

        app.MapPost("/login-and-password", async (IAuthorization authorization, string login, string pass) =>
        {
            var idUser = await authorization.Authorization(login, pass);
            return idUser != null ? Results.Ok(idUser) : Results.NotFound();
        });
        app.MapPost("/rfid", async (IAuthorization authorization, string rfid) =>
        {
            var idUser = await authorization.Authorization(rfid);
            return idUser != null ? Results.Ok(idUser) : Results.NotFound();
        });
        return app;
    }
}