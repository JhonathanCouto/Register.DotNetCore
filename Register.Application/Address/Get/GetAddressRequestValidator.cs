using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Application;

public sealed class GetAddressRequestValidator : AbstractValidator<GetAddressRequest>
{
    public GetAddressRequestValidator() => RuleFor(request => request.Id).Id();
    
}
