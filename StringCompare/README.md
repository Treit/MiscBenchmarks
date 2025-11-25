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
| Ordinal                    | 1000  |  11.292 μs | 0.0585 μs | 0.0548 μs |  1.00 |    0.01 |
| OrdinalIgnoreCase          | 1000  |   8.691 μs | 0.1098 μs | 0.1027 μs |  0.77 |    0.01 |
| CurrentCulture             | 1000  | 138.393 μs | 1.0486 μs | 0.9809 μs | 12.26 |    0.10 |
| CurrentCultureIgnoreCase   | 1000  | 207.595 μs | 0.8951 μs | 0.7475 μs | 18.39 |    0.11 |
| InvariantCulture           | 1000  | 137.474 μs | 1.0662 μs | 0.9974 μs | 12.17 |    0.10 |
| InvariantCultureIgnoreCase | 1000  | 220.301 μs | 0.7751 μs | 0.6871 μs | 19.51 |    0.11 |
