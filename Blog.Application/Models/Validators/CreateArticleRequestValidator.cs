using Blog.Application.Models.Requests;
using FluentValidation;

namespace Blog.Application.Models.Validators;
public class CreateArticleRequestValidator : AbstractValidator<CreateArticleRequest>
{
    public CreateArticleRequestValidator()
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
