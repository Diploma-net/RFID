using RFLOT.Common.Domain.Entity;

namespace RFLOT.Domain.People;

public class People : IEntity
{
    public People(string id, string fullName, Role role)
    {
        Id = id;
        FullName = fullName;
        Role = role;
    }
    
    public string Id { get; private set; }
    public string FullName { get; private set; }
    public Role Role { get; private set; }
}