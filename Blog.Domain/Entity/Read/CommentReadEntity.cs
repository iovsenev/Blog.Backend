using Blog.Domain.Entity.Write;

namespace Blog.Domain.Entity.Read;
public class CommentReadEntity
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTimeOffset CreateDate { get; set; }

    public UserReadModel Author { get; set; }
    public ArticleReadModel Article { get; set; }
}
