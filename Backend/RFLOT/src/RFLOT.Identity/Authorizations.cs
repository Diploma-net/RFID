using Microsoft.EntityFrameworkCore;
using RFLOT.Identity.Context;

namespace RFLOT.Identity;

public class Authorizations : IAuthorization
{
    private readonly UserDbContext _context;

    public Authorizations(UserDbContext context)
    {
        _context = context;
    }

    public async Task<(Guid, string)?> Authorization(string login, string password)
    {
        var user = await _context.Users.FirstAsync(u => u.Login == login && u.Password == password);
        return new ValueTuple<Guid, string>(user.Id, user.FullName);
    }

    public async Task<(Guid, string)?> Authorization(string rfid)
    {
        var user = await _context.Users.FirstAsync(u => u.Rfid == rfid);
        return new ValueTuple<Guid, string>(user.Id, user.FullName);
    }
}