using FluentValidation;

namespace Blog.Application.Services.Account.Register;
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5);
        RuleFor(u => u.UserName)
            .NotNull();
    }
}
