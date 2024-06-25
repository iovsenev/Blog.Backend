using Blog.Application.Models.ViewModels;

namespace Blog.Application.Services.Articles.Queries.GetById;

public record GetArticleByIdResponse(ArticleFullViewModel Article);