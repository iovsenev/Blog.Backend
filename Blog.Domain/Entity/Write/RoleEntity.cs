using Blog.Domain.Common;

namespace Blog.Domain.Entity.Write;
public class RoleEntity : BaseEntity
{
    public static RoleEntity Admin = new RoleEntity(nameof(Admin).ToUpper());
    public static RoleEntity Moderator = new RoleEntity(nameof(Moderator).ToUpper());
    public static RoleEntity User = new RoleEntity(nameof(User).ToUpper());
    private RoleEntity() { }

    private RoleEntity(string name)
    {
        Name = name;
    }   

    public string Name { get; private set; }
}
