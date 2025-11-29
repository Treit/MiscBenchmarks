﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Jobs;

public class Knob
{
    public string Id { get; set; }
    public double? Weight { get; set; }
}
public class RankerResult
{
    public double? Score { get; set; }
    public string KnobId { get; set; }
    public Knob Knob { get; set; }
}

public class Experience
{
    public string Id { get; set; }
    public int? TopWeightedKnobs { get; set; }
}

[MemoryDiagnoser]
[MemoryRandomization]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    public IList<RankerResult> RankerResults { get; set; }
    public Experience ExperienceConfiguration { get; set; }

    [Params(5000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(Count);
        RankerResults = new List<RankerResult>();
        ExperienceConfiguration = new Experience();
        for (int i = 0; i < Count; i++)
        {
            RankerResults.Add(new RankerResult
            {
                Score = Math.Round(random.NextDouble(), 2),
                KnobId = Guid.NewGuid().ToString(),
                Knob = new Knob
                {
                    Id = Guid.NewGuid().ToString(),
                    Weight = Math.Round(random.NextDouble(), 2)
                }
            });
        }

        ExperienceConfiguration = new Experience
        {
            Id = Guid.NewGuid().ToString(),
            TopWeightedKnobs = random.Next(1, 10)
        };
    }

    [Benchmark]
    public List<RankerResult> GetRandomWeightedKnobsOriginal()
    {
        return GetRandomWeightedKnobs(RankerResults, ExperienceConfiguration);
    }

    [Benchmark]
    public List<RankerResult> GetRandomWeightedKnobsBinarySearch()
    {
        return GetRandomWeightsBinarySearch(RankerResults, ExperienceConfiguration);
    }

    [Benchmark(Baseline = true)]
    public List<RankerResult> GetRandomWeightedKnobsFenwickTree()
    {
        return GetRandomWeightsFenwick(RankerResults, ExperienceConfiguration);
    }

    public List<RankerResult>? GetRandomWeightedKnobs(IList<RankerResult> rankedResults, Experience experienceConfiguration)
    {
        int topKnobs = experienceConfiguration.TopWeightedKnobs ?? 1;
        var weightedRankedResults = rankedResults.Where(r => r?.Knob?.Weight != null).ToList();

        if (!weightedRankedResults.Any())
        {
            // If there is no knob returned with weight, then return the top score knob
            return rankedResults.OrderByDescending(r => r?.Score).Take(Math.Min(topKnobs, rankedResults.Count)).ToList();
        }

        if (weightedRankedResults.Count == 1)
        {
            return weightedRankedResults;
        }

        // Step 3: Random sampling
        int numDesiredKnobs = Math.Min(topKnobs, weightedRankedResults.Count); // TODO: This should be coming from layout config
        Random random = new Random(Count);
        var targetScopes = new List<RankerResult>();

        for (int i = 0; i < numDesiredKnobs && targetScopes.Count < numDesiredKnobs; i++)
        {
            double totalWeight = (double)weightedRankedResults.Sum(r => r?.Knob?.Weight ?? 0);
            var normalizedWeightedKnobs = new Dictionary<string, RankerResult>();

            foreach (var weightedKnob in weightedRankedResults)
            {
                if (weightedKnob?.Knob?.Weight > 0 && totalWeight != 0)
                {
                    double normalizedWeight = (double)(weightedKnob.Knob.Weight / totalWeight);
                    string knobNameWeighted = normalizedWeight.ToString() + '_' + weightedKnob.KnobId;
                    normalizedWeightedKnobs.TryAdd(knobNameWeighted, weightedKnob);
                }
            }

            double randomValue = random.NextDouble(); // Generate random number between 0 and 1

            // Compare random value with normalized weights
            double currentWeight = 0;

            foreach (var normalizedKnobs in normalizedWeightedKnobs.OrderBy(kv => kv.Key))
            {
                if (double.TryParse(normalizedKnobs.Key.Split('_')[0], out var normalizedWeight))
                {
                    currentWeight += normalizedWeight;

                    if (randomValue <= currentWeight)
                    {
                        targetScopes.Add(normalizedKnobs.Value);
                        var knobId = normalizedKnobs.Value.Knob?.Id;
                        int index = weightedRankedResults.FindIndex(x => x.Knob.Id == knobId);
                        weightedRankedResults.RemoveAt(index);

                        break;
                    }
                }
            }

            if (targetScopes.Count < numDesiredKnobs && weightedRankedResults.Count == 1)
            {
                targetScopes.Add(weightedRankedResults[0]);
            }
        }

        return targetScopes;
    }


    public List<RankerResult>? GetRandomWeightsFenwick(IList<RankerResult> rankedResults, Experience experienceConfiguration)
    {
        int topKnobs = experienceConfiguration.TopWeightedKnobs ?? 1;
        // Filter for positive weights only, as BIT assumes non-negative contributions
        var weightedRankedResults =
            rankedResults.Where(r => r?.Knob?.Weight.HasValue == true &&
            r.Knob.Weight.Value > 0).ToList();

        int n = weightedRankedResults.Count;

        if (n == 0)
        {
            return rankedResults.OrderByDescending(r => r?.Score ?? double.MinValue)
                                .Take(Math.Min(topKnobs, rankedResults.Count))
                                .ToList();
        }

        int numDesiredKnobs = Math.Min(topKnobs, n);

        if (numDesiredKnobs == n)
        {
            return weightedRankedResults; // Return all if desired count >= available
        }

        if (numDesiredKnobs == 0)
        {
            return new List<RankerResult>();
        }

        var selectedKnobs = new List<RankerResult>(numDesiredKnobs);

        // Extract initial weights for O(N) BIT construction
        double[] initialWeights = new double[n];
        double totalWeight = 0;
        for (int i = 0; i < n; i++)
        {
            double weight = weightedRankedResults[i].Knob.Weight.Value;
            initialWeights[i] = weight;
            totalWeight += weight;
        }

        // Use the O(N) constructor
        using var bit = new FenwickTree(initialWeights);

        Random random = new Random(Count);

        for (int i = 0; i < numDesiredKnobs; i++)
        {
            if (totalWeight <= 1e-9 || n - i == 0) break; // Check for near-zero weight or no items left

            double randomValue = random.NextDouble() * totalWeight;

            // Find the index in the BIT corresponding to the random cumulative weight
            int selectedIndex = bit.FindIndexByCumulativeValue(randomValue);

            // Handle edge case where randomValue might be extremely close to totalWeight
            // or if FindIndexByCumulativeValue returns -1 unexpectedly
            if (selectedIndex < 0)
            {
                // Fallback: find the first item with non-zero weight if search fails
                // This shouldn't ideally happen if randomValue is generated correctly
                // and totalWeight > 0. We might need a more robust FindIndex method.
                // For now, let's find the first available index as a simple fallback.
                for (int k = 0; k < weightedRankedResults.Count; ++k)
                {
                    if (bit.Query(k) - (k > 0 ? bit.Query(k - 1) : 0) > 1e-9)
                    {
                        // Check if weight at k > 0
                        selectedIndex = k;
                        break;
                    }
                }

                if (selectedIndex < 0) break; // Still couldn't find one
            }


            RankerResult selected = weightedRankedResults[selectedIndex];
            selectedKnobs.Add(selected);

            // Remove the weight of the selected item from the BIT
            double selectedWeight = selected.Knob.Weight.Value;
            bit.Add(selectedIndex, -selectedWeight); // Subtract the weight
            totalWeight -= selectedWeight;
        }

        return selectedKnobs;
    }

    public List<RankerResult>? GetRandomWeightsBinarySearch(IList<RankerResult> rankedResults, Experience experienceConfiguration)
    {
        var topKnobs = experienceConfiguration.TopWeightedKnobs ?? 1;
        var weightedRankedResults = rankedResults.Where(
            r => r?.Knob?.Weight != null &&
            r?.Knob.Weight > 0).ToList();

        if (!weightedRankedResults.Any())
        {
            return rankedResults.OrderByDescending(r => r?.Score)
                .Take(Math.Min(topKnobs, rankedResults.Count))
                .ToList();
        }

        if (weightedRankedResults.Count == 1)
        {
            return weightedRankedResults;
        }

        var numDesiredKnobs = Math.Min(topKnobs, weightedRankedResults.Count);

        var selected = new List<RankerResult>();
        var remaining = new List<RankerResult>(weightedRankedResults);
        var array = ArrayPool<double>.Shared.Rent(remaining.Count);
        var cumulativeArray = array.AsSpan(0, remaining.Count);
        var random = new Random(Count);

        while (selected.Count < numDesiredKnobs && remaining.Count > 0)
        {
            var cumulative = 0.0;
            var count = remaining.Count;

            for (int i = 0; i < count; i++)
            {
                cumulative += remaining[i].Knob.Weight ?? 0;
                cumulativeArray[i] = cumulative;
            }

            var r = random.NextDouble() * cumulative;
            var index = cumulativeArray.BinarySearch(r);

            if (index < 0)
            {
                index = ~index;
            }

            selected.Add(remaining[index]);
            remaining.RemoveAt(index);
            cumulativeArray = cumulativeArray.Slice(1);
        }

        ArrayPool<double>.Shared.Return(array);

        return selected;
    }

    // --- Fenwick Tree (Binary Indexed Tree) Implementation ---
    private class FenwickTree : IDisposable
    {
        private readonly double[] tree;
        private bool disposed;
        public readonly int size; // Made public for optimized FindIndex

        // O(N) Constructor - Takes initial weights directly
        public FenwickTree(double[] initialValues)
        {
            this.size = initialValues.Length;
            this.tree = ArrayPool<double>.Shared.Rent(size + 1);
            Array.Clear(tree, 0, size + 1);

            // Place initial values directly (leaves of the conceptual tree)
            for (int i = 0; i < size; i++)
            {
                tree[i + 1] = initialValues[i];
            }

            // Build the tree by propagating sums upwards
            for (int i = 1; i <= size; i++)
            {
                int parent = i + (i & -i); // Find the next node to update
                if (parent <= size)
                {
                    tree[parent] += tree[i];
                }
            }
        }

        // Add 'delta' to the element at index 'idx' (0-based index)
        // Used for updates after selection
        public void Add(int idx, double delta)
        {
            idx++; // Convert to 1-based index
            while (idx <= size)
            {
                tree[idx] += delta;
                idx += idx & (-idx); // Move to the next relevant index in the tree
            }
        }

        // Get the cumulative sum from index 0 up to 'idx' (0-based index)
        public double Query(int idx)
        {
            idx++; // Convert to 1-based index
            double sum = 0;
            while (idx > 0)
            {
                sum += tree[idx];
                idx -= idx & (-idx); // Move to the parent index in the tree
            }
            return sum;
        }

        // Find the smallest index 'idx' (0-based) such that Query(idx) >= value
        // Assumes values added are non-negative and value > 0
        // This implementation uses O(log N) tree traversal.
        public int FindIndexByCumulativeValue(double value)
        {
            int idx = 0;
            // Start with highest power of 2 less than or equal to size
            int bitmask = 1;
            while ((bitmask << 1) <= size)
            {
                bitmask <<= 1;
            }
            // Alternative way to find highest power of 2:
            // int bitmask = size == 0 ? 0 : 1 << (int)Math.Floor(Math.Log2(size));

            while (bitmask > 0)
            {
                int tIdx = idx + bitmask; // Potential next index
                if (tIdx <= size) // Check bounds
                {
                    // If the cumulative sum up to tIdx is less than the target value,
                    // it means our target index is further to the right.
                    // We take the sum from this block and move right.
                    // Use a tolerance for floating point comparison
                    if (value - tree[tIdx] > 1e-9) // if value > tree[tIdx]
                    {
                        value -= tree[tIdx];
                        idx = tIdx;
                    }
                    // Otherwise, the target index is within the current block or before it,
                    // so we don't add this block's index and continue searching left/within.
                }
                bitmask >>= 1; // Move to the next smaller power of 2
            }

            // 'idx' is now the 0-based index of the element whose cumulative sum range contains 'value'.
            // Ensure index is within bounds [0, size-1]
            return Math.Min(idx, size - 1);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                ArrayPool<double>.Shared.Return(tree);
                disposed = true;
            }
        }
    }
}
