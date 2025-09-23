# Check if there is anything worth processing with Any before enumerating vs...well...just enumerating.

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
