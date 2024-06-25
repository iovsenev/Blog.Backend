using FluentValidation;

namespace Blog.Application.Services.Users.Commands.CreateComment;
public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
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
