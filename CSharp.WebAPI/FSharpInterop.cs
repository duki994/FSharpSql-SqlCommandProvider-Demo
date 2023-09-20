namespace CSharp.WebAPI
{
    public static class FSharpInterop
    {
        public static Microsoft.FSharp.Core.FSharpOption<T> ToOption<T>(T? x) where T : struct 
            => Microsoft.FSharp.Core.OptionModule.OfNullable(x);

        public static Microsoft.FSharp.Core.FSharpOption<T> ToOption<T>(T x) where T : class 
            => Microsoft.FSharp.Core.OptionModule.OfObj(x);
    }
}
