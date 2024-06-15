using FluentValidation;

namespace Blog.Application.Services.Users.Create;
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
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
