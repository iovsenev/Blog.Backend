using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace Blog.Domain.ValueObject;

public record PhoneNumber
{
    private const string PhoneRegex = "^((8 |\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";

    private PhoneNumber(string phone)
    {
        Phone = phone;
    }

    public string Phone { get; }

    public static Result<PhoneNumber, Error> Create(string input)
    {
        input = input.Trim().ToLower();

        if (string.IsNullOrEmpty(input) && !Regex.IsMatch(input, PhoneRegex))
            return ErrorFactory.General.InValid("this email is not valid.");

        return new PhoneNumber(input);
    }
}