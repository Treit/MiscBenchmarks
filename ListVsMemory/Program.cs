namespace ListVsReadOnlyMemory
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
            b.GlobalSetup();

            // Test each benchmark method
            var readListResult = b.ReadList();
            b.GlobalSetup();
            var readReadOnlyMemoryResult = b.ReadReadOnlyMemory();
            b.GlobalSetup();
            var readMemoryResult = b.ReadMemory();
            b.GlobalSetup();
            var readListForeachResult = b.ReadListForeach();
            b.GlobalSetup();
            var readReadOnlyMemoryForeachResult = b.ReadReadOnlyMemoryForeach();

            // Output results for comparison
            Console.WriteLine($"ReadList: {readListResult}");
            Console.WriteLine($"ReadReadOnlyMemory: {readReadOnlyMemoryResult}");
            Console.WriteLine($"ReadMemory: {readMemoryResult}");
            Console.WriteLine($"ReadListForeach: {readListForeachResult}");
            Console.WriteLine($"ReadReadOnlyMemoryForeach: {readReadOnlyMemoryForeachResult}");

            // Verify results are equivalent
            bool allEqual = readListResult == readReadOnlyMemoryResult && 
                           readReadOnlyMemoryResult == readMemoryResult &&
                           readMemoryResult == readListForeachResult &&
                           readListForeachResult == readReadOnlyMemoryForeachResult;
            Console.WriteLine($"All read results equal: {allEqual}");

            // Test write operations
            b.GlobalSetup();
            b.WriteList();
            Console.WriteLine("WriteList completed");
            
            b.GlobalSetup();
            b.WriteMemory();
            Console.WriteLine("WriteMemory completed");

            // Test creation operations
            var createdList = b.CreateList();
            var createdReadOnlyMemory = b.CreateReadOnlyMemory();
            Console.WriteLine($"Created List count: {createdList.Count}");
            Console.WriteLine($"Created ReadOnlyMemory length: {createdReadOnlyMemory.Length}");
#endif
        }
    }
}

// Edited by AI 🤖
