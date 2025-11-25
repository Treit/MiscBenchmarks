# Deserializing JSON using a few different techniques




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count | Mean     | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|------------------------------ |------ |---------:|---------:|---------:|-------:|-------:|----------:|
| DeserializeWithJsonDocument   | 100   | 20.33 μs | 0.138 μs | 0.122 μs | 0.5188 |      - |   8.64 KB |
| DeserializeWithJsonNode       | 100   | 36.46 μs | 0.462 μs | 0.409 μs | 3.9673 | 0.6714 |  64.97 KB |
| DeserializeWithJsonSerializer | 100   | 26.57 μs | 0.213 μs | 0.178 μs | 1.2512 | 0.0305 |  20.49 KB |
| DeserializeWithSourceGen      | 100   | 28.45 μs | 0.108 μs | 0.101 μs | 1.0986 | 0.0305 |  18.15 KB |
