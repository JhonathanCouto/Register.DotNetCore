using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mediator;
using DotNetCore.Results;
using Register.Infrastructure;

namespace Register.Application;

public sealed record DeleteAddressHandler : IHandler<DeleteAddressRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;

    public DeleteAddressHandler
    (
        IUnitOfWork unitOfWork, 
        IAddressRepository addressRepository
    )
    {
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
    }

    public async Task<Result> HandleAsync(DeleteAddressRequest request)
    {
        await _addressRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
