using RFLOT.Common.Domain;

namespace RFLOT.Identity;

public class User : Entity<Guid>
{
    public Guid Id { get; private set; }
    public string Login { get; private set; }
    public string Password { get; private set; }
    public string? Rfid { get; private set; }
    public string FullName { get; private set; }
}