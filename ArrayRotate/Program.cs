namespace Test
{
    using BenchmarkDotNet.Running;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Amount = 26;
            b.RotateLeftWithReverse();
            b.RotateLeftWithCopy();
            b.RotateLeftWithJuggling();
#endif

        }
    }
}
