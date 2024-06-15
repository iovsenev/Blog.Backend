namespace Blog.Domain.Entity.Read;
public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset RegisterDate { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public DateTimeOffset? BirthDate { get; set; }

    public ICollection<ArticleDto> Articles { get; set; } = [];
}
