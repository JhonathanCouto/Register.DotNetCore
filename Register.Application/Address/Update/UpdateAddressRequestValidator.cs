using FluentValidation;

namespace Register.Application;

public class UpdateAddressRequestValidator : AbstractValidator<UpdateAddressRequest>
{
    public UpdateAddressRequestValidator()
    {
        RuleFor(request => request.Id).Id();
        RuleFor(request => request.Street).Street();
        RuleFor(request => request.Number).Number();
        RuleFor(request => request.City).City();
        RuleFor(request => request.State).State();
        RuleFor(request => request.ZipCode).ZipCode();
    }
}
