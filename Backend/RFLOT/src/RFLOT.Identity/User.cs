using RFLOT.Common.Domain;

namespace RFLOT.Identity;

public class User : Entity<Guid>
{
    private User()
    {
        
    }
    public User(Guid id, string login, string password, string? rfid, string fullName)
    {
        Id = id;
        Login = login;
        Password = password;
        Rfid = rfid;
        FullName = fullName;
    }

    public string Login { get; private set; }
    public string Password { get; private set; }
    public string? Rfid { get; private set; }
    public string FullName { get; set; }
}