namespace RFLOT.Domain.People;

public class People
{
    public People(Guid id, string fullName, Role role)
    {
        FullName = fullName;
        Role = role;
    }
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public Role Role { get; private set; }
}