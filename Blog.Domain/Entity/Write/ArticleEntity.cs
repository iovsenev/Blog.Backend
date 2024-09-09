using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Domain.Entity.Write;
public class ArticleEntity : BaseEntity
{
    //private ArticleEntity() { }

    private ArticleEntity(
        string title,
        string description,
        string content,
        DateTimeOffset createdDate,
        double rating = 0,
        bool isPublished = false,
        bool underInspection = true
        )
    {
        Title = title;
        Description = description;
        Content = content;
        CreatedDate = createdDate;
        Rating = rating;
        IsPublished = isPublished;
        UnderInspection = underInspection;
    }

    public string Title { get; private set; }
    public string Description { get; private set; } 
    public string Content { get; private set; } 
    public DateTimeOffset CreatedDate { get; private set; }

    public double Rating { get; private set; }
    public bool IsPublished { get; private set; } 
    public bool UnderInspection { get; private set; } 

    public UserEntity? Author { get; private set; }

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
            return ErrorFactory.General.NotValid("The title is not valid value");
        if (string.IsNullOrWhiteSpace(description))
            return ErrorFactory.General.NotValid("The description is not valid value");
        if (string.IsNullOrWhiteSpace(text))
            return ErrorFactory.General.NotValid("The text is not valid value");
        
        var article =  new ArticleEntity( title, description, text, DateTimeOffset.UtcNow);

        article._comments = [];
        article._tags.AddRange(tags);
        return article;
    }

    public void PostComment(CommentEntity comment)
    {
        _comments.Add(comment);
    }

    public void PublishArticle(bool isPosted) =>
        IsPublished = isPosted;
}
