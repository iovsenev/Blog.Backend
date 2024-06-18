using Blog.Domain.Entity.Write;

namespace Blog.Domain.Entity.Read;
public class TagDto
{
    public Guid Id { get; set; }
    public string TagName { get; set; }

    public List<ArticleDto> Articles { get; set; } =[];
}
