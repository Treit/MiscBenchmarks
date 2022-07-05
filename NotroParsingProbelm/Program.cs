namespace Test
{
    using BenchmarkDotNet.Running;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.GlobalSetup();
            var x = b.ParseUsingRegex();
            var y = b.ParseUsingStateMachine();
            var z = b.ParseUsingTokensViaSplit();

            if (x != y || y != z)
            {
                throw new InvalidOperationException("Expected everything to be equal");
            }
#endif

        }
    }
}
