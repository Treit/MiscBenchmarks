# Searching for substrings using Contains




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Count | Mean       | Error     | StdDev    | Ratio | RatioSD |
|--------------------------- |------ |-----------:|----------:|----------:|------:|--------:|
| Ordinal                    | 1000  |  11.317 μs | 0.0573 μs | 0.0536 μs |  1.00 |    0.01 |
| OrdinalIgnoreCase          | 1000  |   8.639 μs | 0.0720 μs | 0.0674 μs |  0.76 |    0.01 |
| CurrentCulture             | 1000  | 138.378 μs | 1.0752 μs | 1.0058 μs | 12.23 |    0.10 |
| CurrentCultureIgnoreCase   | 1000  | 207.694 μs | 0.8385 μs | 0.7002 μs | 18.35 |    0.10 |
| InvariantCulture           | 1000  | 137.149 μs | 0.8944 μs | 0.7928 μs | 12.12 |    0.09 |
| InvariantCultureIgnoreCase | 1000  | 219.744 μs | 0.6752 μs | 0.6316 μs | 19.42 |    0.10 |
