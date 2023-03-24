using Microsoft.EntityFrameworkCore;
using Register.Domain;

namespace Register.Infrastructure;

public static class ContextSeed 
{
    public static void Seed(this ModelBuilder builder) => builder.SeedUsers();

    private static void SeedUsers(this ModelBuilder builder)
    {
        builder.Entity<Address>(entity => entity.HasData(new
        {
            Id      = 1L,
            Street  = "Test Street",
            Number  = "584",
            City    = "Test State",
            State   = "Test State",
            ZipCode = "12345678"
        }));

        builder.Entity<User>(entity => entity.HasData(new
        {
            Id        = 1L,
            Name      = "Test Name",
            Email     = "Test Email",
            Cpf       = "12345678912",
            AddressId = 1L,
            CreatedAt = DateTime.Now
        }));
    }
}
