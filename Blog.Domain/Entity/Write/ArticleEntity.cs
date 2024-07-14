using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Domain.Entity.Write;
public class ArticleEntity : BaseEntity
{
    private ArticleEntity() { }

    private ArticleEntity(string title, string description, string text, DateTimeOffset createdDate, IEnumerable<TagEntity> tags)
    {
        Title = title;
        Description = description;
        Content = text;
        CreatedDate = createdDate;
        _tags.AddRange(tags);
    }

    public string Title { get; private set; }
    public string Description { get; private set; } 
    public string Content { get; private set; } 
    public DateTimeOffset CreatedDate { get; private set; }

    public double Rating { get; private set; } = 0;
    public bool IsPublished { get; private set; } = false;
    public bool UnderInspection { get; private set; } = true;

    public UserEntity Author { get; private set; }

    private List<CommentEntity> _comments = [];
    public ICollection<CommentEntity> Comments => _comments.ToList();

    private List<TagEntity> _tags = [];
    public ICollection<TagEntity> Tags => _tags.ToList();

    public static Result <ArticleEntity, Error> Create(string  title, string description, string text, IEnumerable<TagEntity> tags)
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
        
        return new ArticleEntity(title, description, text, DateTimeOffset.UtcNow, tags);
    }

    public void PostComment(CommentEntity comment)
    {
        _comments.Add(comment);
    }
}
