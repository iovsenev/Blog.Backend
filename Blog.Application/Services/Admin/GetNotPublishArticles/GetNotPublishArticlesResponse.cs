using Blog.Application.Models.ViewModels;

namespace Blog.Application.Services.Admin.GetNotPublishArticles;

public record GetNotPublishArticlesResponse(
    ICollection<ArticleShortViewModel> Articles);
