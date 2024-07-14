using Blog.Domain.Entity.Write;

namespace Blog.Application.Interfaces.DbAccess;
public interface IAuthorRepository : IRepository<UserEntity>
{
}
