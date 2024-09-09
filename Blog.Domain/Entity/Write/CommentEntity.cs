using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Domain.Entity.Write;
public class CommentEntity : BaseEntity
{
    //private CommentEntity() { }
    private CommentEntity(
        string content,
        DateTimeOffset createDate)
    {
        Content = content;
        CreateDate = createDate;
    }

    public string Content { get; private set; }
    public DateTimeOffset CreateDate { get; private set; }

    public UserEntity? Author { get; private set; }
    public ArticleEntity? Article { get; private set; }

    public static Result<CommentEntity, Error> Create(UserEntity author, ArticleEntity article, string inputText)
    {
        inputText = inputText.Trim();

        if (string.IsNullOrEmpty(inputText))
            return ErrorFactory.General.NotValid($"Comment must be not empty");
        var comment = new CommentEntity(inputText, DateTimeOffset.UtcNow);
        comment.Author = author;
        comment.Article = article;  
        return comment;
    }
}
