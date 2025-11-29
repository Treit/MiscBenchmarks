# Deserializing JSON using a few different techniques with a large complex object




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Count | Mean       | Error    | StdDev   | Gen0     | Gen1     | Gen2     | Allocated  |
|------------------------------ |---------- |---------- |------ |-----------:|---------:|---------:|---------:|---------:|---------:|-----------:|
| DeserializeWithJsonDocument   | .NET 10.0 | .NET 10.0 | 100   | 1,046.9 μs |  9.59 μs |  8.97 μs |  39.0625 |  17.5781 |        - |  668.15 KB |
| DeserializeWithJsonNode       | .NET 10.0 | .NET 10.0 | 100   | 2,095.6 μs | 37.67 μs | 33.39 μs | 132.8125 | 109.3750 | 109.3750 | 2221.08 KB |
| DeserializeWithJsonSerializer | .NET 10.0 | .NET 10.0 | 100   |   932.8 μs |  5.14 μs |  4.81 μs |  38.0859 |  15.6250 |        - |  635.23 KB |
| DeserializeWithSourceGen      | .NET 10.0 | .NET 10.0 | 100   |   926.4 μs |  5.24 μs |  4.38 μs |  38.0859 |  15.6250 |        - |  635.23 KB |
| DeserializeWithJsonDocument   | .NET 9.0  | .NET 9.0  | 100   | 1,050.8 μs |  8.75 μs |  7.76 μs |  39.0625 |  17.5781 |        - |  668.15 KB |
| DeserializeWithJsonNode       | .NET 9.0  | .NET 9.0  | 100   | 2,079.2 μs | 28.77 μs | 24.02 μs | 132.8125 | 109.3750 | 109.3750 | 2221.08 KB |
| DeserializeWithJsonSerializer | .NET 9.0  | .NET 9.0  | 100   |   938.7 μs |  3.33 μs |  3.12 μs |  38.0859 |  15.6250 |        - |  635.23 KB |
| DeserializeWithSourceGen      | .NET 9.0  | .NET 9.0  | 100   |   933.2 μs |  4.74 μs |  4.43 μs |  38.0859 |  15.6250 |        - |  635.23 KB |
