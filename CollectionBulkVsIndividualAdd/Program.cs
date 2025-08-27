namespace CollectionBulkVsIndividualAdd
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            // Debug mode: Test benchmark methods and compare results
            Benchmark b = new Benchmark();
            b.Count = 100; // Use smaller count for debug testing
            b.GlobalSetup();

            // Test each benchmark method
            var result1 = b.ListIndividualAdd();
            b.GlobalSetup();
            var result2 = b.ListAddRange();
            b.GlobalSetup();
            var result3 = b.ListConstructorWithCollection();
            b.GlobalSetup();
            var result4 = b.HashSetIndividualAdd();
            b.GlobalSetup();
            var result5 = b.HashSetUnionWith();
            b.GlobalSetup();
            var result6 = b.HashSetConstructorWithCollection();

            // Output results for comparison
            Console.WriteLine($"ListIndividualAdd: Count={result1.Count}, First 5: [{string.Join(", ", result1.Take(5))}]");
            Console.WriteLine($"ListAddRange: Count={result2.Count}, First 5: [{string.Join(", ", result2.Take(5))}]");
            Console.WriteLine($"ListConstructorWithCollection: Count={result3.Count}, First 5: [{string.Join(", ", result3.Take(5))}]");
            Console.WriteLine($"HashSetIndividualAdd: Count={result4.Count}, First 5: [{string.Join(", ", result4.Take(5))}]");
            Console.WriteLine($"HashSetUnionWith: Count={result5.Count}, First 5: [{string.Join(", ", result5.Take(5))}]");
            Console.WriteLine($"HashSetConstructorWithCollection: Count={result6.Count}, First 5: [{string.Join(", ", result6.Take(5))}]");

            // Verify results are equivalent
            bool listsEqual = result1.SequenceEqual(result2) && result2.SequenceEqual(result3);
            bool hashSetsEqual = result4.SetEquals(result5) && result5.SetEquals(result6);

            Console.WriteLine($"All List results equal: {listsEqual}");
            Console.WriteLine($"All HashSet results equal: {hashSetsEqual}");
#endif
        }
    }
}
