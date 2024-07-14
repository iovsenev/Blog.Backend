using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Interfaces.DbAccess;
public interface IReadDbContext
{
    DbSet<UserReadModel> Users { get; set; }
    DbSet<ArticleReadModel> Articles { get; set; }
    DbSet<CommentReadEntity> Comments { get; set; }
    DbSet<TagReadModel> Tags { get; set; }
}