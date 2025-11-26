# Serializing and deserializng JSON list using AsyncEnumerable vs. Normal




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Count  | Mean        | Error       | StdDev      | Gen0      | Gen1      | Gen2     | Allocated   |
|--------------------------- |------- |------------:|------------:|------------:|----------:|----------:|---------:|------------:|
| **DeserializeAsyncEnumerable** | **100**    |    **189.3 μs** |     **3.69 μs** |     **4.10 μs** |    **0.9766** |         **-** |        **-** |    **22.46 KB** |
| DeserializeNormal          | 100    |    136.1 μs |     2.28 μs |     2.13 μs |    1.2207 |         - |        - |    21.03 KB |
| **DeserializeAsyncEnumerable** | **10000**  |  **3,536.0 μs** |    **70.19 μs** |    **78.02 μs** |  **109.3750** |         **-** |        **-** |  **1811.87 KB** |
| DeserializeNormal          | 10000  |  4,559.3 μs |    74.83 μs |    70.00 μs |  140.6250 |  132.8125 |  46.8750 |  2054.19 KB |
| **DeserializeAsyncEnumerable** | **100000** | **36,145.5 μs** |   **467.93 μs** |   **437.70 μs** | **1071.4286** |   **71.4286** |        **-** | **18026.76 KB** |
| DeserializeNormal          | 100000 | 59,848.9 μs | 1,196.29 μs | 1,469.16 μs | 1555.5556 | 1444.4444 | 444.4444 | 20019.45 KB |
