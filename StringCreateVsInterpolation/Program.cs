using BenchmarkDotNet.Running;
using System;
using System.Globalization;

namespace Test;

internal class Program
{
    private static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>(args: args);
#else
        var originalCulture = CultureInfo.CurrentCulture;

        try
        {
            foreach (var cultureName in new[] { "en-US", "fr-FR", "ar-SA" })
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(cultureName);

                foreach (var pageSize in new[] { 25, 1_000 })
                {
                    var benchmark = new Benchmark { PageSize = pageSize };
                    var expected = benchmark.PlainInterpolation();
                    var stringCreate = benchmark.StringCreateInvariantCulture();
                    var formUrlEncoded = benchmark.FormUrlEncodedContentDictionary().GetAwaiter().GetResult();

                    if (!string.Equals(expected, stringCreate, StringComparison.Ordinal)
                        || !string.Equals(expected, formUrlEncoded, StringComparison.Ordinal))
                    {
                        throw new InvalidOperationException(
                            $"The methods produced different results for culture {cultureName} and page size {pageSize}.");
                    }
                }
            }

            Console.WriteLine("All methods produced identical query strings.");
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
#endif
    }
}
