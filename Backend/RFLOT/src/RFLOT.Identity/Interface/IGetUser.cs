namespace RFLOT.Identity;

public interface IGetUser
{
    public Task<string> GetFullNameUser(Guid id);
    public Task<List<string>> GetFullNameUsers(List<Guid> ids);
}