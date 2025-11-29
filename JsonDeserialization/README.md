# Deserializing JSON using a few different techniques






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Count | Mean     | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|------------------------------ |---------- |---------- |------ |---------:|---------:|---------:|-------:|-------:|----------:|
| DeserializeWithJsonDocument   | .NET 10.0 | .NET 10.0 | 100   | 19.74 μs | 0.095 μs | 0.080 μs | 0.5188 |      - |   8.64 KB |
| DeserializeWithJsonNode       | .NET 10.0 | .NET 10.0 | 100   | 37.40 μs | 0.290 μs | 0.257 μs | 3.9673 | 0.6104 |  64.97 KB |
| DeserializeWithJsonSerializer | .NET 10.0 | .NET 10.0 | 100   | 27.81 μs | 0.098 μs | 0.091 μs | 1.2512 | 0.0305 |  20.49 KB |
| DeserializeWithSourceGen      | .NET 10.0 | .NET 10.0 | 100   | 27.66 μs | 0.133 μs | 0.111 μs | 1.0986 | 0.0305 |  18.15 KB |
| DeserializeWithJsonDocument   | .NET 9.0  | .NET 9.0  | 100   | 19.58 μs | 0.109 μs | 0.102 μs | 0.5188 |      - |   8.64 KB |
| DeserializeWithJsonNode       | .NET 9.0  | .NET 9.0  | 100   | 36.52 μs | 0.247 μs | 0.231 μs | 3.9673 | 0.6104 |  64.97 KB |
| DeserializeWithJsonSerializer | .NET 9.0  | .NET 9.0  | 100   | 25.45 μs | 0.219 μs | 0.194 μs | 1.2512 | 0.0305 |  20.49 KB |
| DeserializeWithSourceGen      | .NET 9.0  | .NET 9.0  | 100   | 27.46 μs | 0.109 μs | 0.097 μs | 1.0986 | 0.0305 |  18.15 KB |
