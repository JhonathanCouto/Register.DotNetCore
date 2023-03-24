using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Register.Domain;
using Register.Models;
using System.Linq.Expressions;

namespace Register.Infrastructure;

public sealed class AddressRepository : EFRepository<Address>, IAddressRepository
{
    public AddressRepository(Context context) : base(context) { }

    public static Expression<Func<Address, AddressModel>> Model => address => new AddressModel
    {
        Id = address.Id,
        Street = address.Street,
        City = address.City,
        State = address.State,
        ZipCode = address.ZipCode
    };

    public Task<AddressModel> GetModelAsync(long id) =>  Queryable.Where(address => address.Id == id).Select(Model).SingleOrDefaultAsync();
    
    public async Task<IEnumerable<AddressModel>> ListModelAsync() => await Queryable.Select(Model).ToListAsync();
    
}
