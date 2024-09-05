using Blog.Domain.Entity.Write;

namespace Blog.Domain.Entity.Read;
public class ArticleReadModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; }

    public double Rating { get; set; } = 0;
    public bool IsPublished { get; set; } = false;
    public bool UnderInspection { get; set; } = true;

    public UserReadModel Author { get; set; }

    public ICollection<CommentReadEntity> Comments { get; set; } = [];

    public ICollection<TagReadModel> Tags { get; set; } = [];
}
