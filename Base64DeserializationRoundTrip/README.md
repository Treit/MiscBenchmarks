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

```bash
dotnet run -c Release
```

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-XVRJLJ : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True

```
| Method                | Count  | Mean           | Error         | StdDev        | Median         | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------- |------- |---------------:|--------------:|--------------:|---------------:|------:|--------:|-------:|----------:|------------:|
| **JustEnumerate**         | **10**     |       **4.618 ns** |     **0.1239 ns** |     **0.1568 ns** |       **4.582 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| AnyCheckThenEnumerate | 10     |      64.347 ns |     4.9993 ns |    14.7407 ns |      57.995 ns | 12.55 |    0.68 | 0.0074 |      32 B |          NA |
|                       |        |                |               |               |                |       |         |        |           |             |
| **JustEnumerate**         | **100000** |  **35,547.062 ns** |   **707.7673 ns** | **1,925.5332 ns** |  **34,892.603 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| AnyCheckThenEnumerate | 100000 | 368,679.915 ns | 4,162.2757 ns | 3,893.3953 ns | 368,073.730 ns |  9.99 |    0.67 |      - |      32 B |          NA |
