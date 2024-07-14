using Blog.Application.Models.ViewModels;
using Blog.Domain.Entity.Read;
using System.Net.WebSockets;

namespace Blog.Application.EntityExtensions;
public static class CommentExtension
{
    public static CommentViewModel ToViewModel(this CommentReadEntity comment)
    {
        return new CommentViewModel(
            comment.Id,
            comment.Content,
            comment.CreateDate,
            comment.Author.ToShortViewModel());
    }
}
