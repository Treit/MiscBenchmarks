namespace ConcatVsAppendStringArrays
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

            // Test each benchmark method
            var result1 = b.UsingConcat();
            var result2 = b.UsingAppend();
            var result3 = b.UsingListAdd();
            var result4 = b.UsingListAddRange();
            var result5 = b.UsingArrayWithIndex();
            var result6 = b.UsingArrayCopyTo();
            var result7 = b.UsingSpanAndCopyTo();

            // Output sample results for comparison
            Console.WriteLine($"UsingConcat: Length={result1.Length}, Last 3: [{string.Join(", ", result1.TakeLast(3))}]");
            Console.WriteLine($"UsingAppend: Length={result2.Length}, Last 3: [{string.Join(", ", result2.TakeLast(3))}]");
            Console.WriteLine($"UsingListAdd: Length={result3.Length}, Last 3: [{string.Join(", ", result3.TakeLast(3))}]");
            Console.WriteLine($"UsingListAddRange: Length={result4.Length}, Last 3: [{string.Join(", ", result4.TakeLast(3))}]");
            Console.WriteLine($"UsingArrayWithIndex: Length={result5.Length}, Last 3: [{string.Join(", ", result5.TakeLast(3))}]");
            Console.WriteLine($"UsingArrayCopyTo: Length={result6.Length}, Last 3: [{string.Join(", ", result6.TakeLast(3))}]");
            Console.WriteLine($"UsingSpanAndCopyTo: Length={result7.Length}, Last 3: [{string.Join(", ", result7.TakeLast(3))}]");

            // Verify results are equivalent
            bool allEqual = result1.SequenceEqual(result2) &&
                           result2.SequenceEqual(result3) &&
                           result3.SequenceEqual(result4) &&
                           result4.SequenceEqual(result5) &&
                           result5.SequenceEqual(result6) &&
                           result6.SequenceEqual(result7);

            Console.WriteLine($"All results equal: {allEqual}");
#endif
        }
    }
}
