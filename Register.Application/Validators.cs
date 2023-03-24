using FluentValidation;

namespace Register.Application;

public static class Validators
{
    public static IRuleBuilderOptions<T, long> Id<T>(this IRuleBuilder<T, long> builder) => builder.NotEmpty().GreaterThan(0);

    public static IRuleBuilderOptions<T, string> Name<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty().MinimumLength(3);

    public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty().EmailAddress();

    public static IRuleBuilderOptions<T, string> Cpf<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty().Length(11);


    public static IRuleBuilderOptions<T, string> Street<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty();

    public static IRuleBuilderOptions<T, string> Number<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty();
    
    public static IRuleBuilderOptions<T, string> City<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty();

    public static IRuleBuilderOptions<T, string> State<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty();

    public static IRuleBuilderOptions<T, string> ZipCode<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty().Length(8);

}
