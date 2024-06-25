using FluentValidation;

namespace Blog.Application.Services.Users.Commands.CreateArticle;
public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(a => a.AuthorId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);
        RuleFor(a => a.Title)
            .NotNull()
            .NotEmpty();
        RuleFor(a => a.Description)
            .NotNull()
            .NotEmpty();
        RuleFor(a => a.Text)
            .NotNull()
            .NotEmpty();
        RuleFor(a => a.Tags)
            .NotNull();
    }
}
