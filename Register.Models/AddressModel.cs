namespace Register.Models;

public sealed record AddressModel
{
    public long Id { get; init; }

    public string Street { get; init; }

    public string City { get; init; }

    public string State { get; init; }

    public string ZipCode { get; init; }
}
