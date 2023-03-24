using FluentValidation;

namespace Register.Application;

internal class DeleteAddressValidator : AbstractValidator<DeleteAddressRequest>
{
	public DeleteAddressValidator() => RuleFor(request => request.Id).Id();
}
