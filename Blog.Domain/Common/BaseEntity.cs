namespace Blog.Domain.Common;
public abstract class BaseEntity
{
    public Guid Id { get; private set; }

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity entity) return false;

        if (GetType() != entity.GetType()) return false;

        return Id == entity.Id;
    }

    public override int GetHashCode() =>
        (GetType().ToString() + Id).GetHashCode();

    public static bool operator ==(BaseEntity left, BaseEntity right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right,null)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right,null)) return false;

        return left.Equals(right);
    }

    public static bool operator !=(BaseEntity left, BaseEntity right) =>
        !(left == right);   
}
