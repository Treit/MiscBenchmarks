# Base64 Deserialization Round Trip Benchmark

This benchmark compares the performance of different approaches to deserializing JSON data that has been base64-encoded, with a focus on how performance scales with data size.

The benchmark tests objects containing lists of varying sizes (10 vs 100,000 items) to demonstrate how the different approaches perform with both small and large datasets.

## Approaches Tested

1. **Round Trip Through String**: `base64 → bytes → string → deserialize` (creates intermediate string)
2. **Direct From Bytes** (Baseline): `base64 → bytes → deserialize directly` (avoids string allocation)
3. **Direct From Span**: `base64 → bytes → deserialize from ReadOnlySpan<byte>` (most memory efficient)

## Key Points

- **Small Data**: Tests with objects containing 10 items in their lists
- **Large Data**: Tests with objects containing 100,000 items in their lists (parameterized)
- Each object includes complex nested data (lists, arrays, multiple properties)
- The performance difference becomes more pronounced with larger datasets

## Expected Results

The direct approaches should outperform the round-trip approach, especially with large datasets, due to:
- Avoiding unnecessary string allocation for large JSON payloads
- Reduced memory pressure and GC overhead
- Better memory locality when deserializing directly from bytes

## Results

| Method                           | ListSize | Mean | Error | StdDev | Ratio | Gen0 | Gen1 | Gen2 | Allocated | Alloc Ratio |
|--------------------------------- |--------- |-----:|------:|-------:|------:|-----:|-----:|-----:|----------:|------------:|
| DirectFromBytes_SmallData        | 10       |      |       |        |  1.00 |      |      |      |           |        1.00 |
| RoundTripThroughString_SmallData | 10       |      |       |        |       |      |      |      |           |             |
| DirectFromSpan_SmallData         | 10       |      |       |        |       |      |      |      |           |             |
| DirectFromBytes_LargeData        | 10       |      |       |        |  1.00 |      |      |      |           |        1.00 |
| RoundTripThroughString_LargeData | 10       |      |       |        |       |      |      |      |           |             |
| DirectFromSpan_LargeData         | 10       |      |       |        |       |      |      |      |           |             |
| DirectFromBytes_SmallData        | 100000   |      |       |        |  1.00 |      |      |      |           |        1.00 |
| RoundTripThroughString_SmallData | 100000   |      |       |        |       |      |      |      |           |             |
| DirectFromSpan_SmallData         | 100000   |      |       |        |       |      |      |      |           |             |
| DirectFromBytes_LargeData        | 100000   |      |       |        |  1.00 |      |      |      |           |        1.00 |
| RoundTripThroughString_LargeData | 100000   |      |       |        |       |      |      |      |           |             |
| DirectFromSpan_LargeData         | 100000   |      |       |        |       |      |      |      |           |             |

*Run `..\update_results.ps1` to update these results.*

## How to Run




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | ListSize | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0      | Gen1      | Gen2     | Allocated   | Alloc Ratio |
|--------------------------------- |--------- |--------------:|-------------:|-------------:|------:|--------:|----------:|----------:|---------:|------------:|------------:|
| **RoundTripThroughString_SmallData** | **10**       |      **11.50 μs** |     **0.086 μs** |     **0.080 μs** |  **0.98** |    **0.01** |    **0.6409** |         **-** |        **-** |    **10.67 KB** |        **1.56** |
| DirectFromBytes_SmallData        | 10       |      11.84 μs |     0.233 μs |     0.195 μs |  1.01 |    0.02 |    0.4120 |         - |        - |     6.85 KB |        1.00 |
| RoundTripThroughString_LargeData | 10       |      12.05 μs |     0.114 μs |     0.095 μs |  1.03 |    0.01 |    0.6409 |         - |        - |    10.67 KB |        1.56 |
| DirectFromBytes_LargeData        | 10       |      11.74 μs |     0.104 μs |     0.092 μs |  1.00 |    0.01 |    0.4120 |         - |        - |     6.85 KB |        1.00 |
|                                  |          |               |              |              |       |         |           |           |          |             |             |
| **RoundTripThroughString_SmallData** | **100000**   |      **11.94 μs** |     **0.061 μs** |     **0.057 μs** | **0.000** |    **0.00** |    **0.6409** |    **0.0153** |        **-** |    **10.68 KB** |       **0.000** |
| DirectFromBytes_SmallData        | 100000   |      11.19 μs |     0.066 μs |     0.062 μs | 0.000 |    0.00 |    0.4120 |         - |        - |     6.85 KB |       0.000 |
| RoundTripThroughString_LargeData | 100000   | 170,565.68 μs | 2,396.953 μs | 3,660.400 μs | 1.063 |    0.03 | 3000.0000 | 2666.6667 | 666.6667 | 97712.46 KB |       1.601 |
| DirectFromBytes_LargeData        | 100000   | 160,518.48 μs | 1,875.950 μs | 2,690.432 μs | 1.000 |    0.02 | 3000.0000 | 2750.0000 | 750.0000 | 61022.61 KB |       1.000 |
