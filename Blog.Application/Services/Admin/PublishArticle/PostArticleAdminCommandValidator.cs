using FluentValidation;

namespace Blog.Application.Services.Admin.PublishArticle;
public class PostArticleAdminCommandValidator : AbstractValidator<PostArticleAdminCommand>
{
    public PostArticleAdminCommandValidator()
    {
        RuleFor(x => x.ArticleId)
            .NotNull()
            .NotEqual(Guid.Empty);
        RuleFor(x => x.IsPublish)
            .NotNull();
    }
}
