namespace Blog.Application.Models.Requests;
public record CreateCommentRequest(
    Guid AuthorId,
    Guid ArticleId,
    string Text);
