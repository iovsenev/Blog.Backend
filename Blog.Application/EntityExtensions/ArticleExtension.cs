using Blog.Application.Models.ViewModels;
using Blog.Domain.Entity.Read;

namespace Blog.Application.EntityExtensions;
public static class ArticleExtension
{
    public static ArticleShortModelForUser ToShortForUser(this ArticleDto article)
    {
        return new ArticleShortModelForUser(
            article.Id,
            article.Title,
            article.Description,
            article.CreatedDate);
    }

    public static ArticleShortViewModel ToShortViewModel(this ArticleDto article)
    {
        return new ArticleShortViewModel(
            article.Id,
            article.Title,
            article.Description,
            article.CreatedDate,
            article.Author.ToShortViewModel());
    }

    public static ArticleFullViewModel ToFullViewModel(this ArticleDto article)
    {
        return new ArticleFullViewModel(
            article.Id,
            article.Title,
            article.Description,
            article.Text,
            article.CreatedDate,
            article.Author.ToShortViewModel(),
            article.Comments
                    .Select(c => c.ToViewModel())
                    .ToList());
    }
}
