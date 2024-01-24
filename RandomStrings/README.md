# Random strings


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                                  Method | Count | MaxLen |      Mean |    Error |   StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|-------------------------------------------------------- |------ |------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
|                         RandomStringsUsingStringBuilder |   100 |    100 |  19.01 μs | 0.232 μs | 0.217 μs |  1.00 |    0.00 | 1.7700 |   30048 B |        1.00 |
|             RandomStringsUsingStringDotCreateConstAlpha |   100 |    100 |  34.72 μs | 0.081 μs | 0.076 μs |  1.83 |    0.02 | 1.2817 |   21520 B |        0.72 |
|                       RandomStringsUsingStringDotCreate |   100 |    100 |  37.06 μs | 0.091 μs | 0.085 μs |  1.95 |    0.02 | 1.2817 |   22320 B |        0.74 |
|                   RandomStringsStackOverflowLinqVersion |   100 |    100 |  44.53 μs | 0.697 μs | 0.652 μs |  2.34 |    0.05 | 2.5635 |   43192 B |        1.44 |
| RandomStringsUsingStringDotCreateConstAlphaStaticRandom |   100 |    100 |  47.19 μs | 0.237 μs | 0.210 μs |  2.48 |    0.03 | 0.7324 |   12503 B |        0.42 |
|                                       RandomStringAkari |   100 |    100 |  53.22 μs | 0.094 μs | 0.078 μs |  2.79 |    0.03 |      - |     304 B |        0.01 |
|                                 RandomStringsTCMVersion |   100 |    100 | 194.17 μs | 1.083 μs | 0.960 μs | 10.21 |    0.11 | 4.6387 |   79288 B |        2.64 |
