using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Domain.Entity.Write;
public class CommentEntity : BaseEntity
{
    private CommentEntity() { }
    private CommentEntity(
        string text,
        DateTimeOffset createdDate)
    {
        Text = text;
        CreateDate = createdDate;
    }

    public string Text { get; private set; }
    public DateTimeOffset CreateDate { get; private set; }

    public UserEntity Author { get; private set; }
    public ArticleEntity Article { get; private set; }

    public static Result<CommentEntity, Error> Create(string inputText)
    {
        inputText = inputText.Trim();

        return string.IsNullOrEmpty(inputText)
             ? ErrorFactory.General.InValid($"Input comment must be not empty or null")
             : new CommentEntity(inputText, DateTimeOffset.UtcNow);
    }
}
