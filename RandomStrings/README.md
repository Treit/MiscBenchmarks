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
| RandomStringsUsingStringBuilder                         | 100   | 100    |  19.59 μs | 0.222 μs | 0.197 μs |  1.00 |    0.01 | 1.7700 |   30048 B |        1.00 |
| RandomStringsUsingStringDotCreate                       | 100   | 100    |  36.08 μs | 0.376 μs | 0.351 μs |  1.84 |    0.02 | 1.2817 |   22320 B |        0.74 |
| RandomStringsUsingStringDotCreateConstAlpha             | 100   | 100    |  37.65 μs | 0.292 μs | 0.274 μs |  1.92 |    0.02 | 1.2817 |   21520 B |        0.72 |
| RandomStringsStackOverflowLinqVersion                   | 100   | 100    |  40.55 μs | 0.303 μs | 0.253 μs |  2.07 |    0.02 | 2.5635 |   43192 B |        1.44 |
| RandomStringAkari                                       | 100   | 100    |  47.03 μs | 0.190 μs | 0.168 μs |  2.40 |    0.02 |      - |     304 B |        0.01 |
| RandomStringsUsingStringDotCreateConstAlphaStaticRandom | 100   | 100    |  47.39 μs | 0.219 μs | 0.194 μs |  2.42 |    0.03 | 0.7324 |   12512 B |        0.42 |
| RandomStringsTCMVersion                                 | 100   | 100    | 194.40 μs | 1.092 μs | 0.912 μs |  9.92 |    0.11 | 4.6387 |   79288 B |        2.64 |
