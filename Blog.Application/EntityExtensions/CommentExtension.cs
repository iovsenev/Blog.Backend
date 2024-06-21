using Blog.Application.Models.ViewModels;
using Blog.Domain.Entity.Read;
using System.Net.WebSockets;

namespace Blog.Application.EntityExtensions;
public static class CommentExtension
{
    public static CommentViewModel ToViewModel(this CommentDto comment)
    {
        return new CommentViewModel(
            comment.Id,
            comment.Text,
            comment.CreateDate,
            comment.Author.ToShortViewModel());
    }
}
