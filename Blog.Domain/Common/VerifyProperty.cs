using Blog.Domain.ValueObject;
using System.Text.RegularExpressions;

namespace Blog.Domain.Common;
internal static class VerifyProperty
{
    private const string EmailRegex = "(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$)";
    private const string PhoneRegex = "^((8 |\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";

    public static Result VerifyEmail(string emailInput)
    {
        emailInput = emailInput.Trim().ToLower();

        if (string.IsNullOrEmpty(emailInput) && !Regex.IsMatch(emailInput, EmailRegex))
            Error.NotValid("This email is not valid.");

        return Result.Success();
    }

    public static Result VerifyPhoneNumber(string phoneInput)
    {
        phoneInput = phoneInput.Trim().ToLower();

        if (string.IsNullOrEmpty(phoneInput) && !Regex.IsMatch(phoneInput, PhoneRegex))
            return Error.NotValid("this email is not valid.");

        return Result.Success();
    }
}
