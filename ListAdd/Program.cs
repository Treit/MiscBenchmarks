namespace Test;
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
        b.Count = 1000;
        b.GlobalSetup();

        // Test each benchmark method
        var result1 = b.AddValueTypesWithForEach();
        b.GlobalSetup();
        var result2 = b.AddReferenceTypesWithForEach();
        b.GlobalSetup();
        var result3 = b.AddValueTypesPresetCapacity();
        b.GlobalSetup();
        var result4 = b.AddReferenceTypesPresetCapacity();
        b.GlobalSetup();
        var result5 = b.AddValueTypesWithAddRange();
        b.GlobalSetup();
        var result6 = b.AddReferenceTypesWithAddRange();
        b.GlobalSetup();
        var result7 = b.ValueTypesToListWithConstructor();
        b.GlobalSetup();
        var result8 = b.ReferenceTypesToListWithConstructor();

        // Output results for comparison
        Console.WriteLine($"AddValueTypesWithForEach: {result1}");
        Console.WriteLine($"AddReferenceTypesWithForEach: {result2}");
        Console.WriteLine($"AddValueTypesPresetCapacity: {result3}");
        Console.WriteLine($"AddReferenceTypesPresetCapacity: {result4}");
        Console.WriteLine($"AddValueTypesWithAddRange: {result5}");
        Console.WriteLine($"AddReferenceTypesWithAddRange: {result6}");
        Console.WriteLine($"ValueTypesToListWithConstructor: {result7}");
        Console.WriteLine($"ReferenceTypesToListWithConstructor: {result8}");

        // Verify results are equivalent (if applicable)
        Console.WriteLine($"All results equal: {result1 == result2 && result2 == result3 && result3 == result4 && result4 == result5 && result5 == result6 && result6 == result7 && result7 == result8}");
#endif
    }
}
