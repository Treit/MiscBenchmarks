namespace CsvVsParquet
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
            // Debug mode: Test benchmark methods and compare results
            Benchmark b = new Benchmark();
            b.RowCount = 1000;
            b.GlobalSetup();

            var csvResult = b.ReadCsv();
            var parquetResult = b.ReadParquet();

            Console.WriteLine($"CSV records read: {csvResult.Count}");
            Console.WriteLine($"Parquet records read: {parquetResult.Count}");
            Console.WriteLine($"Results equal: {csvResult.Count == parquetResult.Count}");

            if (csvResult.Count > 0 && parquetResult.Count > 0)
            {
                Console.WriteLine($"\nFirst CSV record: Id={csvResult[0].Id}, Name={csvResult[0].Name}, Age={csvResult[0].Age}");
                Console.WriteLine($"First Parquet record: Id={parquetResult[0].Id}, Name={parquetResult[0].Name}, Age={parquetResult[0].Age}");
            }

            b.GlobalCleanup();
#endif
        }
    }
}