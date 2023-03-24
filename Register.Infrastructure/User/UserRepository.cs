using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Register.Domain;
using Register.Models;
using System.Linq.Expressions;

namespace Register.Infrastructure;

public class UserRepository : EFRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context) { }

    public static Expression<Func<User, UserModel>> Model => user => new UserModel
    {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
        Cpf = user.Cpf,
        AddressId = user.AddressId
    };

    public Task<bool> EmailExistsAsync(string email) => Queryable.AnyAsync(user => user.Email == email);

    public Task<UserModel> GetModelAsync(long id) => Queryable.Where(user => user.Id == id).Select(Model).SingleOrDefaultAsync();

    public async Task<IEnumerable<UserModel>> ListModelAsync() => await Queryable.Select(Model).ToListAsync();
}
