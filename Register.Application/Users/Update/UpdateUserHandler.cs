using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mediator;
using DotNetCore.Results;
using Register.Infrastructure;

namespace Register.Application;
public sealed record UpdateUserHandler : IHandler<UpdateUserRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler
    (
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository
    )
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result> HandleAsync(UpdateUserRequest request)
    {
        var user = await _userRepository.GetAsync(request.Id);

        if (user == null) return Result.Success();

        user.UpdateName(request.Name);

        user.UpdateEmail(request.Email);

        user.UpdateCpf(request.Cpf);

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
