using Blog.Domain.Entity.Write;
using Blog.Domain.ValueObject;

namespace Blog.Domain.Entity.Read;
public class UserReadModel
{
    public Guid Id { get; set; }
    public string Email { get;  set; } =string.Empty;
    public string PasswordHash { get;  set; } = string.Empty;
    public string UserName { get;  set; } = string.Empty ;
    public DateTimeOffset RegisterDate { get;  set; }

    public string PhoneNumber { get;  set; } = string.Empty;
    public string FirstName { get;  set; } = "";
    public string LastName { get;  set; } = string.Empty;
    public string SecondName { get;  set; } = string.Empty;
    public DateTimeOffset? BirthDate { get;  set; } = null!;

    public AddressValue Address { get;  set; } = null!;

    public ICollection<ArticleReadModel> Articles { get; set; } =[];

    public ICollection<CommentReadEntity> Comments { get; set; } =[];
}
