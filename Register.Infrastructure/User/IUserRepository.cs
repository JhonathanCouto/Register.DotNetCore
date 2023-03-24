using DotNetCore.Repositories;
using Register.Domain;
using Register.Models;

namespace Register.Infrastructure;

public interface IUserRepository : IRepository<User>
{
    Task<bool> EmailExistsAsync(string email);

    Task<UserModel> GetModelAsync(long id);

    Task<IEnumerable<UserModel>> ListModelAsync(); 
}
