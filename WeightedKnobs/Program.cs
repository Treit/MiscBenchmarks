﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

namespace Test;
public class Program
{
    public static void Main(string[] args)
    {
#if RELEASE
        Console.WriteLine("Running Benchmark Test (TopWeightedKnobs = 1):\n");
        Benchmark benchmark = new Benchmark();
        benchmark.Count = 5000;
        benchmark.GlobalSetup();
        BenchmarkRunner.Run(typeof(Benchmark));
#else
        Console.WriteLine("\nRunning Weighted Distribution Test (TopWeightedKnobs = 1):\n");
        TestWeightedDistribution();
        Test();
#endif
    }

    static void Test()
    {
        var experienceConfig = new Experience
        {
            Id = "testConfig",
            TopWeightedKnobs = 3,
        };

        var scores = new List<RankerResult>
        {
            new RankerResult
            {
                KnobId = "testknob1", Score = 2, Knob = new Knob {Id = "testknob1", Weight = 0.0029 }
            },
            new RankerResult
            {
                KnobId = "testknob2", Score = 1, Knob = new Knob {Id = "testknob2", Weight = 0 }
            },
            new RankerResult
            {
                KnobId = "testknob3", Score = 3, Knob = new Knob {Id = "testknob3", Weight = 0 }
            },
            new RankerResult
            {
                KnobId = "testknob4", Score = 6
            },
            new RankerResult
            {
                KnobId = "testknob5", Score = 4
            },
            new RankerResult
            {
                KnobId = "testknob6", Score = 5
            },
            new RankerResult
            {
                KnobId = "testknob6", Score = 7
            },
        };

        var b = new Benchmark();
        b.Count = 100;
        b.GlobalSetup();
        var result = b.GetRandomWeightedKnobs(scores, experienceConfig);
        var result2 = b.GetRandomWeightsBinarySearch(scores, experienceConfig);

        Console.WriteLine("Original Method Result:");
        foreach (var r in result)
        {
            Console.WriteLine($"KnobId: {r.KnobId}, Score: {r.Score}, Weight: {r.Knob?.Weight}");
        }

        Console.WriteLine("\nOptimized Method Result:");
        foreach (var r in result2)
        {
            Console.WriteLine($"KnobId: {r.KnobId}, Score: {r.Score}, Weight: {r.Knob?.Weight}");
        }
    }

    static void TestWeightedDistribution()
    {
        // Create a fixed collection of 20 RankerResults with deterministic weights.
        int count = 20;
        List<RankerResult> results = new List<RankerResult>();
        double totalWeight = 0.0;
        for (int i = 0; i < count; i++)
        {
            double weight = Math.Pow(i + 1, 2); // Weight increases non-linearly.
            totalWeight += weight;
            results.Add(new RankerResult
            {
                Score = 1.0,
                KnobId = "Knob" + i,
                Knob = new Knob { Id = "Knob" + i, Weight = weight }
            });
        }

        // Fixed experience configuration to select only 1 knob.
        Experience experience = new Experience { TopWeightedKnobs = 1 };

        Benchmark benchmark = new Benchmark();

        Dictionary<string, int> originalFreq = new Dictionary<string, int>();
        Dictionary<string, int> optimizedFreq = new Dictionary<string, int>();
        Dictionary<string, int> optimizedV2Freq = new Dictionary<string, int>(); // Added for V2

        int iterations = 10000;
        for (int i = 0; i < iterations; i++)
        {
            benchmark.Count = i; // Vary the seed for each iteration.
            var origSelection = benchmark.GetRandomWeightedKnobs(results, experience);
            benchmark.Count = i; // Ensure all methods use the same seed.
            var optSelection = benchmark.GetRandomWeightsBinarySearch(results, experience);
            benchmark.Count = i; // Reset seed again for V2
            var optV2Selection = benchmark.GetRandomWeightsFenwick(results, experience);

            // Handle cases where selection might return empty (shouldn't happen here, but good practice)
            string origId = origSelection.Count > 0 ? origSelection[0].Knob.Id : "None";
            string optId = optSelection.Count > 0 ? optSelection[0].Knob.Id : "None";
            string optV2Id = optV2Selection.Count > 0 ? optV2Selection[0].Knob.Id : "None";


            if (!originalFreq.ContainsKey(origId))
                originalFreq[origId] = 0;
            originalFreq[origId]++;

            if (!optimizedFreq.ContainsKey(optId))
                optimizedFreq[optId] = 0;
            optimizedFreq[optId]++;

            if (!optimizedV2Freq.ContainsKey(optV2Id)) // Added for V2
                optimizedV2Freq[optV2Id] = 0;
            optimizedV2Freq[optV2Id]++; // Added for V2
        }

        Console.WriteLine("Expected Distribution (based on weights):");
        for (int i = 0; i < count; i++)
        {
            double weight = Math.Pow(i + 1, 2);
            double expectedProb = weight / totalWeight;
            Console.WriteLine($"Knob Knob{i}: {expectedProb:P2}");
        }
        Console.WriteLine();

        Console.WriteLine("Original Method Distribution (observed proportions):");
        foreach (var kv in originalFreq.OrderBy(k => k.Key))
        {
            Console.WriteLine($"Knob {kv.Key}: {((double)kv.Value / iterations):P2}");
        }

        Console.WriteLine("\nOptimized Method Distribution (observed proportions):");
        foreach (var kv in optimizedFreq.OrderBy(k => k.Key))
        {
            Console.WriteLine($"Knob {kv.Key}: {((double)kv.Value / iterations):P2}");
        }

        Console.WriteLine("\nOptimized V2 Method Distribution (observed proportions):"); // Added for V2
        foreach (var kv in optimizedV2Freq.OrderBy(k => k.Key)) // Added for V2
        {
            Console.WriteLine($"Knob {kv.Key}: {((double)kv.Value / iterations):P2}"); // Added for V2
        }

        Console.WriteLine("\nWeighted distribution test completed.");
    }
}
