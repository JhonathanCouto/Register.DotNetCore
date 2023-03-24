using DotNetCore.Mediator;
using DotNetCore.Results;
using Register.Infrastructure;
using Register.Models;

namespace Register.Application;

public sealed record ListAddressHandler : IHandler<ListAddressRequest, IEnumerable<AddressModel>>
{
    private readonly IAddressRepository _addressRepository;

    public ListAddressHandler(IAddressRepository addressRepository) => _addressRepository = addressRepository;

    public async Task<Result<IEnumerable<AddressModel>>> HandleAsync(ListAddressRequest request)
    {
        var address = await _addressRepository.ListModelAsync();

        return Result<IEnumerable<AddressModel>>.Success(address);
    }
}
