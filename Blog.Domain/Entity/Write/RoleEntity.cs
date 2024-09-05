using Blog.Domain.Common;
using Blog.Domain.Constants;

namespace Blog.Domain.Entity.Write;
public class RoleEntity : BaseEntity
{
    public static RoleEntity Admin = new RoleEntity(nameof(Admin), [
        Permission.Account.Delete,
        Permission.Account.Update,

        Permission.User.Read,
        Permission.User.Update,
        Permission.User.Create,

        Permission.Article.Publish,
        Permission.Article.Read,

        Permission.Role.Read,
        Permission.Role.Update,
        Permission.Role.Create,
        Permission.Role.Delete,

        Permission.Comment.Read,
        Permission.Comment.Delete,
        ]);
    public static RoleEntity Moderator = new RoleEntity(nameof(Moderator), [
        Permission.Account.Delete,
        Permission.Account.Update,

        Permission.User.Read,
        Permission.User.Update,

        Permission.Article.Publish,
        Permission.Article.Read,
        Permission.Article.Create,
        Permission.Article.Delete,

        Permission.Comment.Read,
        Permission.Comment.Delete,
        ]);
    public static RoleEntity User = new RoleEntity(nameof(User), [
        Permission.Account.Delete,
        Permission.Account.Update,

        Permission.Article.Create,
        Permission.Article.Delete,
        Permission.Article.Update,

        Permission.Comment.Read,
        Permission.Comment.Delete,
        Permission.Comment.Update,
        Permission.Comment.Create,
        ]);
    private RoleEntity() { }

    private RoleEntity(string name, string[] permissions )
    {
        Name = name;
        Permissions = permissions;
    }   

    public string Name { get; private set; }

    public string[] Permissions { get; private set; } = [];
}
