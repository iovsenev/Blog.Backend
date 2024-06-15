using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Interfaces;
public interface IReadDbContext
{
    DbSet<UserDto> Users { get; set; }
}