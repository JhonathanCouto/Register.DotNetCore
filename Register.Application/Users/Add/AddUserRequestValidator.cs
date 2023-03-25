using FluentValidation;

namespace Register.Application;

public sealed class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
	public AddUserRequestValidator()
	{
        RuleFor(request => request.Name).Name();
        RuleFor(request => request.Email).Email();
        RuleFor(request => request.Cpf).Cpf();

        RuleFor(request => request.Street).Street();
        RuleFor(request => request.Number).Number();
        RuleFor(request => request.City).City();
        RuleFor(request => request.State).State();
        RuleFor(request => request.ZipCode).ZipCode();
    }
}
