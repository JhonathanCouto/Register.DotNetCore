using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.Domain;

namespace Register.Infrastructure;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.Name).HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.Email).HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.Cpf).HasMaxLength(11).IsFixedLength().IsRequired();

        builder.HasOne(entity => entity.Address).WithOne().HasForeignKey<User>("AddressId").IsRequired();

        builder.Property(entity => entity.CreatedAt).IsRequired();


    }
}
