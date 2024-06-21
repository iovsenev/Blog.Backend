using Blog.Application.Models.ViewModels;

namespace Blog.Application.Models.Responses;

public record GetAllArticlesByPageResponse(
    ICollection<ArticleShortViewModel> Articles,
    int TotalCount);