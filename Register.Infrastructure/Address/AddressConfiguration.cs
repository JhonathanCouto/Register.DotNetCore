using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.Domain;

namespace Register.Infrastructure;

public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address));

        builder.HasKey(entity => entity.Id);
        
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.Street).HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.Number).HasMaxLength(4).IsRequired();

        builder.Property(entity => entity.City).HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.State).HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.ZipCode).HasMaxLength(8).IsFixedLength().IsRequired();
    }
}
