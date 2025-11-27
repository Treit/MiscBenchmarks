# Using enums with different underlying types





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Job       | Runtime   | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|---------------- |---------- |---------- |------ |----------:|---------:|---------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| EnumsUsingInt32 | .NET 10.0 | .NET 10.0 | 10000 |  89.56 μs | 1.339 μs | 1.253 μs |  1.00 |    0.02 |  7.8125 |  1.8311 |       - | 128.62 KB |        1.00 |
| EnumsUsingInt64 | .NET 10.0 | .NET 10.0 | 10000 | 141.77 μs | 2.005 μs | 1.875 μs |  1.58 |    0.03 | 41.5039 | 41.5039 | 41.5039 | 256.62 KB |        2.00 |
| EnumsUsingByte  | .NET 10.0 | .NET 10.0 | 10000 |  86.26 μs | 1.341 μs | 1.255 μs |  0.96 |    0.02 |  1.9531 |  0.1221 |       - |  32.63 KB |        0.25 |
|                 |           |           |       |           |          |          |       |         |         |         |         |           |             |
| EnumsUsingInt32 | .NET 9.0  | .NET 9.0  | 10000 |  89.20 μs | 1.119 μs | 1.047 μs |  1.00 |    0.02 |  7.8125 |  1.8311 |       - | 128.62 KB |        1.00 |
| EnumsUsingInt64 | .NET 9.0  | .NET 9.0  | 10000 | 137.80 μs | 1.339 μs | 1.253 μs |  1.55 |    0.02 | 41.5039 | 41.5039 | 41.5039 | 256.62 KB |        2.00 |
| EnumsUsingByte  | .NET 9.0  | .NET 9.0  | 10000 |  85.71 μs | 0.702 μs | 0.657 μs |  0.96 |    0.01 |  1.9531 |  0.1221 |       - |  32.63 KB |        0.25 |
