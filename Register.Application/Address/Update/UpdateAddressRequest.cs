namespace Register.Application;

public sealed record UpdateAddressRequest(long Id, string Street, string Number, string City, string State, string ZipCode);
