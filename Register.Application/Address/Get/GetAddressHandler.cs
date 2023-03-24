using DotNetCore.Mediator;
using DotNetCore.Results;
using Register.Domain;
using Register.Infrastructure;
using Register.Models;

namespace Register.Application;

public sealed record GetAddressHandler : IHandler<GetAddressRequest, AddressModel>
{
    private readonly IAddressRepository _addressRepository;

    public GetAddressHandler(IAddressRepository addressRepository) => _addressRepository = addressRepository;

    public async Task<Result<AddressModel>> HandleAsync(GetAddressRequest request)
    {
        var address = await _addressRepository.GetModelAsync(request.Id);

        return Result<AddressModel>.Success(address);
    }
}
