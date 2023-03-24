using DotNetCore.Mediator;
using DotNetCore.Objects;
using DotNetCore.Results;
using Register.Infrastructure;
using Register.Models;

namespace Register.Application;

public sealed record GridUserHandler : IHandler<GridUserRequest, Grid<UserModel>>
{
    private readonly IUserRepository _userRepository;

    public GridUserHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<Result<Grid<UserModel>>> HandleAsync(GridUserRequest request)
    {
        var grid = await _userRepository.GridAsync(request);

        return Result<Grid<UserModel>>.Success(grid);
    }
}
