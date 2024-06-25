using Blog.Application.Models.ViewModels;

namespace Blog.Application.Services.Articles.Queries.GetAll;

public record GetArticlesByPageResponse(
    ICollection<ArticleShortViewModel> Articles,
    int TotalCount);