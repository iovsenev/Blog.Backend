using Blog.Application.Models;
using Blog.Domain.Entity.Read;
using System.Text;

namespace Blog.Application.EntityExtensions;
public static class UserExtensions
{
    public static ShortUserViewModel ToShortViewModel(this UserDto user)
    {
        return new ShortUserViewModel(
            user.Id,
            user.UserName,
            user.RegisterDate.Date,
            user.GetFullName()
            );
    }

    public static string GetFullName(this UserDto user)
    {
        if (string.IsNullOrEmpty(user.LastName))
            return "";
        var fullname = new StringBuilder(user.FirstName);

        if (string.IsNullOrEmpty($"{user.FirstName[0].ToString().ToUpper()}{user.FirstName.Skip(1).ToString().ToLower()}"))
            return fullname.ToString();
        fullname.Append($" {user.LastName[0].ToString().ToUpper()}.");

        return fullname.ToString();
    }
}
