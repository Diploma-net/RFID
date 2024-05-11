using RFLOT.Common.Domain.Entity;

namespace RFLOT.Identity;

public class User : IEntity<Guid>
{
    public string Login { get; }
    public string Password { get; }
    public string? Rfid { get; }
    public Guid Id { get; }
}