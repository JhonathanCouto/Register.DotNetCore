namespace Register.Models;

public sealed record UserModel
{
    public long Id { get; init; }

    public string Name { get; init; }

    public string Email { get; init; }

    public string Cpf { get; init; }

}
