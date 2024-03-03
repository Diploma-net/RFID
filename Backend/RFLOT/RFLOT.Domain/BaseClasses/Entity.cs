namespace RFLOT.Domain;

public abstract class Entity<T> : IEquatable<Entity<T>>
{
    private readonly T id;

    protected Entity(T id)
    {
        if (object.Equals(id, default(T)))
        {
            throw new ArgumentException("The ID cannot be the default value.", "id");
        }

        this.id = id;
    }

    public T Id
    {
        get { return this.id; }
    }

    public override bool Equals(object obj)
    {
        var entity = obj as Entity<T>;
        if (entity != null)
        {
            return this.Equals(entity);
        }
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    #region IEquatable<Entity> Members

    public bool Equals(Entity<T> other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Id.Equals(other.Id);
    }

    #endregion
}