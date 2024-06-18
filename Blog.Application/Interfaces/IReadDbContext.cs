using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Interfaces;
public interface IReadDbContext
{
    DbSet<UserDto> Users { get; set; }
    DbSet<ArticleDto> Articles { get; set; }
    DbSet<CommentDto> Comments { get; set; }
    DbSet<TagDto> Tags { get; set; }
}