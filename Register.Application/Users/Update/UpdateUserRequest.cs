namespace Register.Application;

public sealed record UpdateUserRequest(long Id, string Name, string Email, string Cpf);
