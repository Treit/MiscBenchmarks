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
| **DeserializeAsyncEnumerable** | **100**    |    **186.6 μs** |     **2.41 μs** |     **2.01 μs** |    **0.9766** |         **-** |        **-** |    **22.46 KB** |
| DeserializeNormal          | 100    |    133.8 μs |     1.42 μs |     1.26 μs |    1.2207 |         - |        - |    21.03 KB |
| **DeserializeAsyncEnumerable** | **10000**  |  **3,527.4 μs** |    **32.44 μs** |    **30.35 μs** |  **109.3750** |    **7.8125** |        **-** |  **1811.87 KB** |
| DeserializeNormal          | 10000  |  4,378.5 μs |    85.42 μs |    83.90 μs |  140.6250 |  132.8125 |  46.8750 |  2054.27 KB |
| **DeserializeAsyncEnumerable** | **100000** | **36,481.6 μs** |   **307.23 μs** |   **287.38 μs** | **1071.4286** |   **71.4286** |        **-** | **18026.76 KB** |
| DeserializeNormal          | 100000 | 59,090.4 μs | 1,110.81 μs | 1,090.96 μs | 1555.5556 | 1444.4444 | 444.4444 | 20019.12 KB |
