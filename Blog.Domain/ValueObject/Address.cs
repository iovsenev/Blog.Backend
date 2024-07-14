using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Domain.ValueObject;
public class Address : BaseValueObject
{
    private Address(string country, string city)
    {
        Country = country;
        City = city;
    }

    public string Country { get; private set; }

    public string City { get; private set; }

    private static Result<Address, Error> Create(string country, string city)
    {
        return new Address(country, city);
    }


    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Country;
        yield return City;
    }
}
