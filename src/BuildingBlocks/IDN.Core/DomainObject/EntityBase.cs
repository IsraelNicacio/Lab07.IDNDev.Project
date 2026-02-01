namespace IDN.Core.DomainObject;

public abstract class EntityBase
{
    public Guid Id { get; private set; }

    protected EntityBase()
        => Id = Guid.NewGuid();

    public override bool Equals(object? obj)
        => Equals(obj);

    public bool Equals(EntityBase? entity)
    {
        if (ReferenceEquals(this, entity)) return true;
        if (entity is null) return false;

        return Id.Equals(entity.Id);
    }

    public override int GetHashCode() 
        => Id.GetHashCode();

    public static bool operator ==(EntityBase? a, EntityBase b)
        => a is null ? b is null : a.Equals(b);

    public static bool operator !=(EntityBase? a, EntityBase? b)
        => !(a == b);
}
