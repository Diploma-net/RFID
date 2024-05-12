namespace RFLOT.Identity;

public interface IAuthorization
{
    public Task<Guid?> Authorization(string login, string password);
    public Task<Guid?> Authorization(string rfid);
}