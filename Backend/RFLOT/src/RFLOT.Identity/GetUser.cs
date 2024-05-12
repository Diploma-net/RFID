using Microsoft.EntityFrameworkCore;
using RFLOT.Identity.Context;

namespace RFLOT.Identity;

public class GetUser : IGetUser
{
    private readonly UserDbContext _context;

    public GetUser(UserDbContext context)
    {
        _context = context;
    }

    public async Task<string> GetFullNameUser(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user.FullName;
    }

    public async Task<List<string>> GetFullNameUsers(List<Guid> ids)
    {
        return ids.Select(id => _context.Users.FirstOrDefault(u => u.Id == id).FullName).ToList();
    }
}