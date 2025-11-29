# Random strings





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                  | Job       | Runtime   | Count | MaxLen | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------------------------- |---------- |---------- |------ |------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| RandomStringsUsingStringBuilder                         | .NET 10.0 | .NET 10.0 | 100   | 100    |  18.85 μs | 0.376 μs | 0.462 μs |  1.00 |    0.03 | 1.7700 |   30048 B |        1.00 |
| RandomStringsUsingStringDotCreateConstAlpha             | .NET 10.0 | .NET 10.0 | 100   | 100    |  34.23 μs | 0.201 μs | 0.168 μs |  1.82 |    0.04 | 1.2817 |   21520 B |        0.72 |
| RandomStringsUsingStringDotCreate                       | .NET 10.0 | .NET 10.0 | 100   | 100    |  36.53 μs | 0.680 μs | 0.636 μs |  1.94 |    0.06 | 1.2817 |   22320 B |        0.74 |
| RandomStringsStackOverflowLinqVersion                   | .NET 10.0 | .NET 10.0 | 100   | 100    |  39.99 μs | 0.338 μs | 0.316 μs |  2.12 |    0.05 | 2.5635 |   43192 B |        1.44 |
| RandomStringAkari                                       | .NET 10.0 | .NET 10.0 | 100   | 100    |  46.96 μs | 0.184 μs | 0.163 μs |  2.49 |    0.06 |      - |     304 B |        0.01 |
| RandomStringsUsingStringDotCreateConstAlphaStaticRandom | .NET 10.0 | .NET 10.0 | 100   | 100    |  47.01 μs | 0.065 μs | 0.055 μs |  2.50 |    0.06 | 0.7324 |   12512 B |        0.42 |
| RandomStringsTCMVersion                                 | .NET 10.0 | .NET 10.0 | 100   | 100    | 189.35 μs | 0.910 μs | 0.851 μs | 10.05 |    0.24 | 4.6387 |   79288 B |        2.64 |
|                                                         |           |           |       |        |           |          |          |       |         |        |           |             |
| RandomStringsUsingStringBuilder                         | .NET 9.0  | .NET 9.0  | 100   | 100    |  18.54 μs | 0.214 μs | 0.190 μs |  1.00 |    0.01 | 1.7700 |   30048 B |        1.00 |
| RandomStringsUsingStringDotCreate                       | .NET 9.0  | .NET 9.0  | 100   | 100    |  35.52 μs | 0.203 μs | 0.159 μs |  1.92 |    0.02 | 1.2817 |   22320 B |        0.74 |
| RandomStringsUsingStringDotCreateConstAlpha             | .NET 9.0  | .NET 9.0  | 100   | 100    |  35.83 μs | 0.142 μs | 0.126 μs |  1.93 |    0.02 | 1.2817 |   21520 B |        0.72 |
| RandomStringsStackOverflowLinqVersion                   | .NET 9.0  | .NET 9.0  | 100   | 100    |  40.02 μs | 0.240 μs | 0.225 μs |  2.16 |    0.02 | 2.5635 |   43192 B |        1.44 |
| RandomStringAkari                                       | .NET 9.0  | .NET 9.0  | 100   | 100    |  46.92 μs | 0.255 μs | 0.239 μs |  2.53 |    0.03 |      - |     304 B |        0.01 |
| RandomStringsUsingStringDotCreateConstAlphaStaticRandom | .NET 9.0  | .NET 9.0  | 100   | 100    |  47.38 μs | 0.190 μs | 0.178 μs |  2.56 |    0.03 | 0.7324 |   12512 B |        0.42 |
| RandomStringsTCMVersion                                 | .NET 9.0  | .NET 9.0  | 100   | 100    | 188.88 μs | 0.535 μs | 0.474 μs | 10.19 |    0.10 | 4.6387 |   79288 B |        2.64 |
