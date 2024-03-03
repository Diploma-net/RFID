namespace RFLOT.Domain.People;

public class People : Entity<Guid>
{
    public People(Guid id, string fullName, Role role) : base(id)
    {
        FullName = fullName;
        Role = role;
    }
    
    public string FullName { get; private set; }
    public Role Role { get; private set; }
}