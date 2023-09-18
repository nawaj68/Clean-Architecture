using FluentValidation;
using JetBrains.Annotations;

namespace TaskManagement.Core.User.Command;

[UsedImplicitly]
public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginCommandValidator()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
        RuleFor(x=>x.Password).NotEmpty().MinimumLength(6);
    }
}