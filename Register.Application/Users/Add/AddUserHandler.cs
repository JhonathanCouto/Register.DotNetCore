using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mediator;
using DotNetCore.Results;
using Register.Domain;
using Register.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Application;

public sealed record AddUserHandler : IHandler<AddUserRequest, long>
{
    private readonly IResultService _resultService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;
    private readonly IUserRepository _userRepository;

    public AddUserHandler
    (
        IResultService resultService, 
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository,
        IAddressRepository addressRepository
    )
    {
        _resultService = resultService;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _addressRepository = addressRepository;
    }

    public async Task<Result<long>> HandleAsync(AddUserRequest request)
    {
        if (await _userRepository.EmailExistsAsync(request.Email)) return _resultService.Error<long>("EmailExists");

        var address = new Address(request.Street, request.Number, request.City, request.State, request.ZipCode);

        var user = new User(request.Name, request.Email, request.Cpf, address);

        await _addressRepository.AddAsync(address);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return _resultService.Success(user.Id);
    }
}
