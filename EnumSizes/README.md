# Using enums with different underlying types




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|---------------- |------ |----------:|---------:|---------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| EnumsUsingInt32 | 10000 |  87.81 μs | 0.783 μs | 0.732 μs |  1.00 |    0.01 |  7.8125 |  1.8311 |       - | 128.62 KB |        1.00 |
| EnumsUsingInt64 | 10000 | 158.84 μs | 1.050 μs | 0.982 μs |  1.81 |    0.02 | 41.5039 | 41.5039 | 41.5039 | 256.62 KB |        2.00 |
| EnumsUsingByte  | 10000 |  85.81 μs | 1.687 μs | 1.496 μs |  0.98 |    0.02 |  1.9531 |  0.1221 |       - |  32.63 KB |        0.25 |
