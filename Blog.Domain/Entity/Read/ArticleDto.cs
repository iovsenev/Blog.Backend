using Blog.Domain.Entity.Write;

namespace Blog.Domain.Entity.Read;
public class ArticleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;

    public UserDto Author { get; set; }

    public ICollection<CommentDto> Comments { get; set; }
    public ICollection<TagDto> Tags { get; set; }
}
