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
| EnumsUsingInt32 | 10000 |  91.07 μs | 0.835 μs | 0.781 μs |  1.00 |    0.01 |  7.8125 |  1.8311 |       - | 128.62 KB |        1.00 |
| EnumsUsingInt64 | 10000 | 156.70 μs | 3.056 μs | 3.396 μs |  1.72 |    0.04 | 41.5039 | 41.5039 | 41.5039 | 256.62 KB |        2.00 |
| EnumsUsingByte  | 10000 |  84.68 μs | 0.933 μs | 0.779 μs |  0.93 |    0.01 |  1.9531 |  0.1221 |       - |  32.63 KB |        0.25 |
