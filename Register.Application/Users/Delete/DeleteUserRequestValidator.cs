using FluentValidation;

namespace Register.Application;

public sealed class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserRequestValidator() => RuleFor(request => request.Id).Id();
}
