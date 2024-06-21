using Blog.Application.Models.Requests;
using FluentValidation;

namespace Blog.Application.Models.Validators;
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
