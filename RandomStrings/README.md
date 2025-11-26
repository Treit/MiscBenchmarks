# Random strings




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                  | Count | MaxLen | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------------------------- |------ |------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| RandomStringsUsingStringBuilder                         | 100   | 100    |  19.49 μs | 0.387 μs | 0.657 μs |  1.00 |    0.05 | 1.7700 |   30048 B |        1.00 |
| RandomStringsUsingStringDotCreate                       | 100   | 100    |  36.30 μs | 0.333 μs | 0.295 μs |  1.86 |    0.06 | 1.2817 |   22320 B |        0.74 |
| RandomStringsUsingStringDotCreateConstAlpha             | 100   | 100    |  36.57 μs | 0.365 μs | 0.342 μs |  1.88 |    0.06 | 1.2817 |   21520 B |        0.72 |
| RandomStringsStackOverflowLinqVersion                   | 100   | 100    |  41.39 μs | 0.583 μs | 0.545 μs |  2.13 |    0.07 | 2.5635 |   43192 B |        1.44 |
| RandomStringsUsingStringDotCreateConstAlphaStaticRandom | 100   | 100    |  46.58 μs | 0.224 μs | 0.198 μs |  2.39 |    0.08 | 0.7324 |   12512 B |        0.42 |
| RandomStringAkari                                       | 100   | 100    |  47.24 μs | 0.227 μs | 0.201 μs |  2.43 |    0.08 |      - |     304 B |        0.01 |
| RandomStringsTCMVersion                                 | 100   | 100    | 192.26 μs | 0.937 μs | 0.877 μs |  9.87 |    0.32 | 4.6387 |   79288 B |        2.64 |
