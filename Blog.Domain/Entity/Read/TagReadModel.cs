using Blog.Domain.Entity.Write;

namespace Blog.Domain.Entity.Read;
public class TagReadModel
{
    public Guid Id { get; set; }
    public string TagName { get; set; } = string.Empty; 

    public List<ArticleReadModel> Articles { get; set; } =[];
}
