namespace Blog.Domain.Common;
public abstract class BaseValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponent();

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not BaseValueObject valueObject) return false;

        if (GetType() != valueObject.GetType()) return false;

        return GetEqualityComponent().SequenceEqual(valueObject.GetEqualityComponent());
    }

    public override int GetHashCode() =>
        GetEqualityComponent().Aggregate(
            default(int),
            (hashCode, value) => 
            HashCode.Combine(hashCode, value.GetHashCode()));

    public static bool operator ==(BaseValueObject left, BaseValueObject right)
    {
        if (ReferenceEquals(left, null) &&  ReferenceEquals(right, null)) return true;
        if (ReferenceEquals(left, null) ||  ReferenceEquals(right, null)) return false;

        return left.Equals(right);
    }

    public static bool operator !=(BaseValueObject left, BaseValueObject right)=>
        !(left == right);
}
