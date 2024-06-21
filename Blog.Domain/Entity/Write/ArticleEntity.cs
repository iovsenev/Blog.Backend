using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Domain.Entity.Write;
public class ArticleEntity
{
    private ArticleEntity() { }

    private ArticleEntity(string title, string description, string text, DateTimeOffset createdDate)
    {
        Title = title;
        Description = description;
        Text = text;
        CreatedDate = createdDate;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Text { get; private set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; private set; }

    public UserEntity Author { get; private set; }

    private List<CommentEntity> _comments = [];
    public ICollection<CommentEntity> Comments => _comments.ToList();

    private List<TagEntity> _tags = [];
    public ICollection<TagEntity> Tags => _tags.ToList();

    public static Result <ArticleEntity, Error> Create(string  title, string description, string text)
    {
        title = title.Trim();
        description = description.Trim();
        text = text.Trim();

        if (string.IsNullOrWhiteSpace(title))
            return ErrorFactory.General.InValid("The title is not valid value");
        if (string.IsNullOrWhiteSpace(description))
            return ErrorFactory.General.InValid("The description is not valid value");
        if (string.IsNullOrWhiteSpace(text))
            return ErrorFactory.General.InValid("The text is not valid value");
        
        return new ArticleEntity(title, description, text, DateTimeOffset.UtcNow);
    }

    public void PostComment(CommentEntity comment)
    {
        _comments.Add(comment);
    }
}
