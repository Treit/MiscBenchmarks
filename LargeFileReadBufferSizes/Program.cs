namespace LargeFileReadBufferSizes
{
    using System;
    using BenchmarkDotNet.Running;

    internal class Program
    {
        private static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark benchmark = new Benchmark();
            benchmark.GlobalSetup();

            long? expected = null;
            bool resultsEqual = true;

            foreach (int bufferSize in Benchmark.BufferSizes)
            {
                benchmark.BufferSizeBytes = bufferSize;
                long result = benchmark.ReadFileBuffered();
                Console.WriteLine($"Buffer {bufferSize:N0} bytes: {result}");

                if (expected.HasValue)
                {
                    resultsEqual &= expected.Value == result;
                }
                else
                {
                    expected = result;
                }
            }

            Benchmark.DeleteGeneratedFile();
            Console.WriteLine($"Results equal: {resultsEqual}");
#endif
        }
    }
}