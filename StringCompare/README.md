# Searching for substrings using Contains





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Job       | Runtime   | Count | Mean       | Error     | StdDev    | Ratio | RatioSD |
|--------------------------- |---------- |---------- |------ |-----------:|----------:|----------:|------:|--------:|
| Ordinal                    | .NET 10.0 | .NET 10.0 | 1000  |  11.337 μs | 0.0372 μs | 0.0310 μs |  1.00 |    0.00 |
| OrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 1000  |   8.600 μs | 0.0379 μs | 0.0336 μs |  0.76 |    0.00 |
| CurrentCulture             | .NET 10.0 | .NET 10.0 | 1000  | 137.323 μs | 0.2057 μs | 0.1824 μs | 12.11 |    0.04 |
| CurrentCultureIgnoreCase   | .NET 10.0 | .NET 10.0 | 1000  | 205.768 μs | 0.2366 μs | 0.1976 μs | 18.15 |    0.05 |
| InvariantCulture           | .NET 10.0 | .NET 10.0 | 1000  | 136.061 μs | 0.2638 μs | 0.2468 μs | 12.00 |    0.04 |
| InvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 1000  | 203.609 μs | 0.1818 μs | 0.1518 μs | 17.96 |    0.05 |
|                            |           |           |       |            |           |           |       |         |
| Ordinal                    | .NET 9.0  | .NET 9.0  | 1000  |  11.264 μs | 0.0256 μs | 0.0214 μs |  1.00 |    0.00 |
| OrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 1000  |   8.581 μs | 0.0249 μs | 0.0208 μs |  0.76 |    0.00 |
| CurrentCulture             | .NET 9.0  | .NET 9.0  | 1000  | 137.587 μs | 0.3932 μs | 0.3486 μs | 12.21 |    0.04 |
| CurrentCultureIgnoreCase   | .NET 9.0  | .NET 9.0  | 1000  | 206.038 μs | 0.6958 μs | 0.6168 μs | 18.29 |    0.06 |
| InvariantCulture           | .NET 9.0  | .NET 9.0  | 1000  | 136.009 μs | 0.3287 μs | 0.2744 μs | 12.07 |    0.03 |
| InvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 1000  | 203.899 μs | 0.7005 μs | 0.6552 μs | 18.10 |    0.07 |
