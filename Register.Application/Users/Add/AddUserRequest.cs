namespace Register.Application;

public sealed record AddUserRequest
(
    string Name, 
    string Email, 
    string Cpf,
    string Street,
    string Number,
    string City,
    string State,
    string ZipCode
);
