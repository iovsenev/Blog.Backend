 using Blog.Domain.Common;

namespace Blog.Domain.ValueObject;
public class AddressValue : BaseValueObject
{
    private AddressValue(string country, string city)
    {
        Country = country;
        City = city;
    }

    public string Country { get; private set; }

    public string City { get; private set; }

    public static Result<AddressValue> Create(string country, string city)
    {
        return new AddressValue(country, city);
    }

    public static AddressValue CreateEmpty()
    {
        return new AddressValue("", "");
    }


    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Country;
        yield return City;
    }
}
