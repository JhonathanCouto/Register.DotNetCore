using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mediator;
using DotNetCore.Results;
using Register.Infrastructure;

namespace Register.Application;

public sealed record DeleteUserHandler : IHandler<DeleteUserRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler
    (
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository
    )
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result> HandleAsync(DeleteUserRequest request)
    {
        await _userRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
