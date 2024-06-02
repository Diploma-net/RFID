using Microsoft.AspNetCore.Mvc;
using RFLOT.Gateway.DTO.Auth;
using RFLOT.Identity;

namespace RFLOT.Gateway.Endpoints;

public static class AuthEndpoints
{
    public static WebApplication AddAuthEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/auth");

        endpoints.MapPost("/login-and-password", async (IAuthorization authorization, WithLoginAndPassDto withLoginAndPassDto) =>
        {
            var idUser = await authorization.Authorization(withLoginAndPassDto.Login, withLoginAndPassDto.Password);
            return idUser != null ? Results.Ok(new { UserId = idUser.Value.Item1, UserName = idUser.Value.Item2 }) : Results.NotFound();
        });
        endpoints.MapPost("/rfid", async (IAuthorization authorization, WithRfidDto rfid) =>
        {
            var idUser = await authorization.Authorization(rfid.Rfid);
            return idUser != null ? Results.Ok(new { UserId = idUser.Value.Item1, UserName = idUser.Value.Item2 }) : Results.NotFound();
        });
        return app;
    }
}