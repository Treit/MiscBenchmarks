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
| DeserializeWithJsonDocument   | 100   | 19.97 μs | 0.180 μs | 0.169 μs | 0.5188 |      - |   8.64 KB |
| DeserializeWithJsonNode       | 100   | 38.24 μs | 0.488 μs | 0.433 μs | 3.9673 | 0.6714 |  64.97 KB |
| DeserializeWithJsonSerializer | 100   | 27.08 μs | 0.109 μs | 0.096 μs | 1.2512 | 0.0305 |  20.49 KB |
| DeserializeWithSourceGen      | 100   | 27.83 μs | 0.153 μs | 0.143 μs | 1.0986 | 0.0305 |  18.15 KB |
