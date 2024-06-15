using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace Blog.Domain.ValueObject;

public record EmailAddress
{
    private const string EmailRegex = "(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$)";

    private EmailAddress(string email)
    {
        Email = email;
    }

    public string Email { get; }

    public static Result<EmailAddress, Error> Create(string input)
    {
        input = input.Trim().ToLower();

        if (string.IsNullOrEmpty(input) && !Regex.IsMatch(input, EmailRegex))
            return ErrorFactory.General.InValid("this email is not valid.");

        return new EmailAddress(input);
    }
}
