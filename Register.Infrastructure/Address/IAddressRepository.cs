using DotNetCore.Repositories;
using Register.Domain;
using Register.Models;

namespace Register.Infrastructure;

public interface IAddressRepository : IRepository<Address>
{
    Task<AddressModel> GetModelAsync(long id);

    Task<IEnumerable<AddressModel>> ListModelAsync();  
}
