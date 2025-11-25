# Deserializing JSON using a few different techniques with a large complex object


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count | Mean       | Error    | StdDev   | Gen0     | Gen1     | Gen2     | Allocated  |
|------------------------------ |------ |-----------:|---------:|---------:|---------:|---------:|---------:|-----------:|
| DeserializeWithJsonDocument   | 100   | 1,045.8 μs |  9.76 μs |  8.66 μs |  39.0625 |  17.5781 |        - |  668.15 KB |
| DeserializeWithJsonNode       | 100   | 2,122.2 μs | 26.39 μs | 22.04 μs | 125.0000 | 109.3750 | 109.3750 | 2221.08 KB |
| DeserializeWithJsonSerializer | 100   |   933.3 μs |  2.46 μs |  2.18 μs |  38.0859 |  15.6250 |        - |  635.23 KB |
| DeserializeWithSourceGen      | 100   |   978.7 μs | 13.75 μs | 12.87 μs |  37.1094 |  15.6250 |        - |  635.23 KB |
