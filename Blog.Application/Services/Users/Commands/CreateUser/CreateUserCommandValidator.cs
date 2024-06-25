using FluentValidation;

namespace Blog.Application.Services.Users.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8);
        RuleFor(u => u.UserName)
            .NotEmpty()
            .NotNull();
    }
}
