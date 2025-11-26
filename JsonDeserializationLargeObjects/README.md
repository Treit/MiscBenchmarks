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
| DeserializeWithJsonDocument   | 100   | 1,049.2 μs | 13.53 μs | 12.66 μs |  39.0625 |  17.5781 |        - |  668.15 KB |
| DeserializeWithJsonNode       | 100   | 2,124.3 μs | 38.70 μs | 36.20 μs | 132.8125 | 109.3750 | 109.3750 | 2221.09 KB |
| DeserializeWithJsonSerializer | 100   |   931.9 μs |  3.30 μs |  2.93 μs |  38.0859 |  15.6250 |        - |  635.23 KB |
| DeserializeWithSourceGen      | 100   |   920.5 μs |  2.88 μs |  2.70 μs |  38.0859 |  15.6250 |        - |  635.23 KB |
