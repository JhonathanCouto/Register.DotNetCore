using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mediator;
using DotNetCore.Results;
using Register.Infrastructure;

namespace Register.Application;

public sealed record UpdateAddressHandler : IHandler<UpdateAddressRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;

    public UpdateAddressHandler
    (
        IUnitOfWork unitOfWork, 
        IAddressRepository addressRepository
    )
    {
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
    }

    public async Task<Result> HandleAsync(UpdateAddressRequest request)
    {
        var address = await _addressRepository.GetAsync(request.Id);

        if (address == null) return Result.Success();

        address.UpdateStreet(request.Street);

        address.UpdateNumber(request.Number);

        address.UpdateCity(request.City);

        address.UpdateState(request.State);

        address.UpdateZipCode(request.ZipCode); 

        await _addressRepository.UpdateAsync(address);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
