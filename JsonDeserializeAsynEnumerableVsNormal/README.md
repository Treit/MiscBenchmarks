# Serializing and deserializng JSON list using AsyncEnumerable vs. Normal





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Job       | Runtime   | Count  | Mean        | Error       | StdDev      | Gen0      | Gen1      | Gen2     | Allocated   |
|--------------------------- |---------- |---------- |------- |------------:|------------:|------------:|----------:|----------:|---------:|------------:|
| **DeserializeAsyncEnumerable** | **.NET 10.0** | **.NET 10.0** | **100**    |    **186.4 μs** |     **3.68 μs** |     **5.28 μs** |    **0.9766** |         **-** |        **-** |    **22.47 KB** |
| DeserializeNormal          | .NET 10.0 | .NET 10.0 | 100    |    130.7 μs |     2.58 μs |     2.53 μs |    1.2207 |         - |        - |    21.04 KB |
| DeserializeAsyncEnumerable | .NET 9.0  | .NET 9.0  | 100    |    186.1 μs |     3.72 μs |     4.96 μs |    0.9766 |         - |        - |    22.47 KB |
| DeserializeNormal          | .NET 9.0  | .NET 9.0  | 100    |    130.7 μs |     1.88 μs |     1.76 μs |    1.2207 |         - |        - |    21.04 KB |
| **DeserializeAsyncEnumerable** | **.NET 10.0** | **.NET 10.0** | **10000**  |  **3,616.9 μs** |    **63.87 μs** |    **76.03 μs** |  **109.3750** |         **-** |        **-** |  **1812.36 KB** |
| DeserializeNormal          | .NET 10.0 | .NET 10.0 | 10000  |  4,483.7 μs |    63.06 μs |    55.90 μs |  148.4375 |  132.8125 |  46.8750 |  2054.33 KB |
| DeserializeAsyncEnumerable | .NET 9.0  | .NET 9.0  | 10000  |  3,556.6 μs |    68.07 μs |    69.91 μs |  109.3750 |         - |        - |  1812.37 KB |
| DeserializeNormal          | .NET 9.0  | .NET 9.0  | 10000  |  4,426.6 μs |    84.90 μs |    97.77 μs |  148.4375 |  132.8125 |  46.8750 |  2054.31 KB |
| **DeserializeAsyncEnumerable** | **.NET 10.0** | **.NET 10.0** | **100000** | **37,767.2 μs** |   **452.08 μs** |   **422.88 μs** | **1076.9231** |   **76.9231** |        **-** | **18029.13 KB** |
| DeserializeNormal          | .NET 10.0 | .NET 10.0 | 100000 | 55,965.6 μs | 1,117.46 μs | 1,286.87 μs | 1400.0000 | 1300.0000 | 600.0000 |  20021.5 KB |
| DeserializeAsyncEnumerable | .NET 9.0  | .NET 9.0  | 100000 | 37,261.3 μs |   570.07 μs |   533.24 μs | 1071.4286 |   71.4286 |        - | 18029.05 KB |
| DeserializeNormal          | .NET 9.0  | .NET 9.0  | 100000 | 54,164.7 μs | 1,023.58 μs | 1,137.71 μs | 1400.0000 | 1300.0000 | 600.0000 | 20020.86 KB |
