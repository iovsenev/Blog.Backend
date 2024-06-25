using Blog.Domain.Entity.Write;

namespace Blog.Application.Interfaces.DbAccess;
public interface IUserRepository : IRepository<UserEntity>
{
}
