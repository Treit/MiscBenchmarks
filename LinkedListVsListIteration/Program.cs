namespace LinkedListVsListIteration
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
            b.Count = 100; // Use small count for debug testing
            b.GlobalSetup();

            // Test each benchmark method
            var resultList = b.IterateList();
            b.GlobalSetup();
            var resultListIndexer = b.IterateListWithIndexer();
            b.GlobalSetup();
            var resultLinkedList = b.IterateLinkedList();
            b.GlobalSetup();
            var resultLinkedListNodes = b.IterateLinkedListNodes();
            b.GlobalSetup();
            var resultListArray = b.IterateListArray();
            b.GlobalSetup();
            var resultListLinq = b.IterateListLinq();
            b.GlobalSetup();
            var resultLinkedListLinq = b.IterateLinkedListLinq();

            // Output results for comparison
            Console.WriteLine($"List (foreach): {resultList}");
            Console.WriteLine($"List (indexer): {resultListIndexer}");
            Console.WriteLine($"LinkedList (foreach): {resultLinkedList}");
            Console.WriteLine($"LinkedList (nodes): {resultLinkedListNodes}");
            Console.WriteLine($"List (array): {resultListArray}");
            Console.WriteLine($"List (LINQ): {resultListLinq}");
            Console.WriteLine($"LinkedList (LINQ): {resultLinkedListLinq}");

            // Verify results are equivalent
            bool allEqual = resultList == resultListIndexer &&
                           resultList == resultLinkedList &&
                           resultList == resultLinkedListNodes &&
                           resultList == resultListArray &&
                           resultList == resultListLinq &&
                           resultList == resultLinkedListLinq;

            Console.WriteLine($"All results equal: {allEqual}");
#endif
        }
    }
}
