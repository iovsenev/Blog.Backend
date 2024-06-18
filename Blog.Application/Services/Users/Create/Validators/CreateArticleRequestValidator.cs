using Blog.Application.Services.Users.Create.Requests;
using FluentValidation;

namespace Blog.Application.Services.Users.Create.Validators;
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
