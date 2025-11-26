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
| **RoundTripThroughString_SmallData** | **10**       |      **11.71 μs** |     **0.104 μs** |     **0.087 μs** |  **0.99** |    **0.01** |    **0.6409** |    **0.0153** |        **-** |    **10.68 KB** |        **1.56** |
| DirectFromBytes_SmallData        | 10       |      11.37 μs |     0.058 μs |     0.049 μs |  0.96 |    0.01 |    0.4120 |         - |        - |     6.85 KB |        1.00 |
| RoundTripThroughString_LargeData | 10       |      11.73 μs |     0.073 μs |     0.065 μs |  0.99 |    0.01 |    0.6409 |    0.0153 |        - |    10.68 KB |        1.56 |
| DirectFromBytes_LargeData        | 10       |      11.87 μs |     0.083 μs |     0.064 μs |  1.00 |    0.01 |    0.4120 |         - |        - |     6.86 KB |        1.00 |
|                                  |          |               |              |              |       |         |           |           |          |             |             |
| **RoundTripThroughString_SmallData** | **100000**   |      **11.89 μs** |     **0.099 μs** |     **0.087 μs** | **0.000** |    **0.00** |    **0.6409** |         **-** |        **-** |    **10.67 KB** |       **0.000** |
| DirectFromBytes_SmallData        | 100000   |      11.19 μs |     0.087 μs |     0.072 μs | 0.000 |    0.00 |    0.4120 |         - |        - |     6.85 KB |       0.000 |
| RoundTripThroughString_LargeData | 100000   | 189,593.00 μs | 3,767.017 μs | 6,083.030 μs | 1.113 |    0.05 | 3000.0000 | 2666.6667 | 666.6667 | 97711.16 KB |       1.601 |
| DirectFromBytes_LargeData        | 100000   | 170,521.27 μs | 3,029.015 μs | 4,625.626 μs | 1.001 |    0.04 | 3000.0000 | 2666.6667 | 666.6667 |    61022 KB |       1.000 |
