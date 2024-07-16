using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Admin.PublishArticle;

public record PostArticleAdminCommand(
    Guid ArticleId,
    bool IsPublish) : ICommand;