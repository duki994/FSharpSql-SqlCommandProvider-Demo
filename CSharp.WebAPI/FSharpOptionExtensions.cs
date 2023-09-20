using Microsoft.FSharp.Core;
namespace CSharp.WebAPI;

public static class FSharpOptionExtensions
{
    public static FSharpOption<T> ToOption<T>(this T? x) where T : struct
        => OptionModule.OfNullable(x);

    public static FSharpOption<T> ToOption<T>(this T x) where T : class
        => OptionModule.OfObj(x);

    public static FSharpOption<bool> ToOption(this bool x)
        => FSharpOption<bool>.Some(x);

    public static FSharpOption<int> ToOption(this int x)
        => FSharpOption<int>.Some(x);

    public static FSharpOption<double> ToOption(this double x)
        => FSharpOption<double>.Some(x);

    public static FSharpOption<decimal> ToOption(this decimal x)
        => FSharpOption<decimal>.Some(x);

    public static bool IsSome<T>(this FSharpOption<T> x)
        => OptionModule.IsSome(x);

    public static bool IsNone<T>(this FSharpOption<T> x)
        => OptionModule.IsNone(x);

    public static T GetValue<T>(this FSharpOption<T> x)
        => OptionModule.GetValue(x);
}
