namespace Register.Application;

public sealed record AddAddressRequest(string Street, string Number, string City, string State, string ZipCode);
