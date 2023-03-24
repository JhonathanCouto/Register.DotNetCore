using FluentValidation;

namespace Register.Application;

public sealed class AddAddressRequestValidator : AbstractValidator<AddAddressRequest>
{
	public AddAddressRequestValidator()
	{
		RuleFor(request => request.Street).Street();
        RuleFor(request => request.Number).Number();
        RuleFor(request => request.City).City();
        RuleFor(request => request.State).State();
        RuleFor(request => request.ZipCode).ZipCode();
    }
}
