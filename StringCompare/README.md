# Searching for substrings using Contains


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                     Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |
|--------------------------- |------ |----------:|---------:|---------:|------:|--------:|
|                    Ordinal |  1000 |  10.39 μs | 0.011 μs | 0.009 μs |  1.00 |    0.00 |
|          OrdinalIgnoreCase |  1000 |  12.90 μs | 0.014 μs | 0.011 μs |  1.24 |    0.00 |
|             CurrentCulture |  1000 | 143.35 μs | 0.364 μs | 0.322 μs | 13.80 |    0.04 |
|   CurrentCultureIgnoreCase |  1000 | 202.12 μs | 0.428 μs | 0.357 μs | 19.46 |    0.04 |
|           InvariantCulture |  1000 | 142.64 μs | 0.188 μs | 0.167 μs | 13.73 |    0.02 |
| InvariantCultureIgnoreCase |  1000 | 202.63 μs | 0.416 μs | 0.389 μs | 19.50 |    0.04 |
