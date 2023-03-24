using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mediator;
using DotNetCore.Results;
using Register.Domain;
using Register.Infrastructure;

namespace Register.Application;

public sealed class AddAddressHandler : IHandler<AddAddressRequest, long>
{
    private readonly IAddressRepository _addressRepository;
    private IResultService _resultService;
    private readonly IUnitOfWork _unitOfWork;

    public AddAddressHandler
    (
        IAddressRepository addressRepository, 
        IResultService resultService, 
        IUnitOfWork unitOfWork
    )
    {
        _addressRepository = addressRepository;
        _resultService = resultService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<long>> HandleAsync(AddAddressRequest request)
    {
        var address = new Address(request.Street, request.Number, request.City, request.State, request.ZipCode);

        await _addressRepository.AddAsync(address);

        await _unitOfWork.SaveChangesAsync();

        return _resultService.Success(address.Id);
    }
}
