using Blog.Domain.Entity.Write;

namespace Blog.Domain.Entity.Read;
public class CommentDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTimeOffset CreateDate { get; set; }

    public UserDto Author { get; set; }
    public ArticleDto Article { get; set; }
}
