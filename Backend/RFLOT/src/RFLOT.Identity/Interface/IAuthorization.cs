namespace RFLOT.Identity;

public interface IAuthorization
{
    public Task<(Guid, string)?> Authorization(string login, string password);
    public Task<(Guid, string)?> Authorization(string rfid);
}