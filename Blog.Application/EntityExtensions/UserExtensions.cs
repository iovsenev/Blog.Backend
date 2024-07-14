using Blog.Application.Models.ViewModels;
using Blog.Domain.Entity.Read;
using System.Text;

namespace Blog.Application.EntityExtensions;
public static class UserExtensions
{
    public static ShortUserViewModel ToShortViewModel(this AuthorDto user)
    {
        return new ShortUserViewModel(
            user.Id,
            user.UserName,
            user.RegisterDate.Date
            );
    }

    private static string GetFullName(this AuthorDto user)
    {
        if (string.IsNullOrEmpty(user.LastName))
            return "";
        var fullname = new StringBuilder(user.FirstName);

        if (string.IsNullOrEmpty($"{user.FirstName[0].ToString().ToUpper()}{user.FirstName.Skip(1).ToString().ToLower()}"))
            return fullname.ToString();
        fullname.Append($" {user.LastName[0].ToString().ToUpper()}.");

        return fullname.ToString();
    }

    public static UserPreviewViewModel ToPreviewViewModel(this AuthorDto user)
    {
        return new UserPreviewViewModel(
            user.Id,
            user.UserName,
            user.RegisterDate,
            user.GetFullName(),
            user.Articles
                    .Select(a => a.ToShortForUser())
                    .ToList(),
            user.Comments
                    .Select(c => c.ToViewModel())
                    .ToList(),
            user.BirthDate);
    }
}
