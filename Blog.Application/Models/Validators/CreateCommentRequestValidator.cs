using Blog.Application.Models.Requests;
using FluentValidation;

namespace Blog.Application.Models.Validators;
public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentRequestValidator()
    {
        RuleFor(c => c.AuthorId)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(c => c.ArticleId)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(c => c.Text)
            .NotNull()
            .NotEmpty();
    }
}
