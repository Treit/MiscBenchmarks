# Using enums with different underlying types


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|          Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |    Gen0 |    Gen1 |    Gen2 | Allocated | Alloc Ratio |
|---------------- |------ |----------:|---------:|---------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| EnumsUsingInt32 | 10000 |  87.32 μs | 1.151 μs | 1.020 μs |  1.00 |    0.00 |  7.8125 |  1.8311 |       - | 128.62 KB |        1.00 |
| EnumsUsingInt64 | 10000 | 149.03 μs | 3.193 μs | 9.416 μs |  1.71 |    0.11 | 41.5039 | 41.5039 | 41.5039 | 256.62 KB |        2.00 |
|  EnumsUsingByte | 10000 |  72.60 μs | 1.210 μs | 1.010 μs |  0.83 |    0.01 |  1.9531 |  0.1221 |       - |  32.63 KB |        0.25 |
