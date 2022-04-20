# Random strings

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22598
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.202
  [Host]     : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT


```
|                                                  Method | Count | MaxLen |      Mean |    Error |   StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------------------------- |------ |------- |----------:|---------:|---------:|------:|--------:|--------:|------:|------:|----------:|
| RandomStringsUsingStringDotCreateConstAlphaStaticRandom |   100 |    100 |  65.13 μs | 1.302 μs | 2.176 μs |  0.81 |    0.06 |  2.8076 |     - |     - |   12513 B |
|             RandomStringsUsingStringDotCreateConstAlpha |   100 |    100 |  70.00 μs | 1.387 μs | 2.466 μs |  0.88 |    0.07 |  4.8828 |     - |     - |   21520 B |
|                       RandomStringsUsingStringDotCreate |   100 |    100 |  72.18 μs | 1.372 μs | 2.474 μs |  0.90 |    0.04 |  5.1270 |     - |     - |   22320 B |
|                         RandomStringsUsingStringBuilder |   100 |    100 |  78.81 μs | 1.519 μs | 4.080 μs |  1.00 |    0.00 |  6.9580 |     - |     - |   30048 B |
|                   RandomStringsStackOverflowLinqVersion |   100 |    100 | 117.71 μs | 2.344 μs | 4.105 μs |  1.47 |    0.09 | 10.0098 |     - |     - |   43192 B |
|                                       RandomStringAkari |   100 |    100 | 126.13 μs | 2.483 μs | 5.182 μs |  1.60 |    0.11 |       - |     - |     - |     304 B |
|                                 RandomStringsTCMVersion |   100 |    100 | 259.25 μs | 5.017 μs | 7.958 μs |  3.21 |    0.20 | 18.0664 |     - |     - |   79288 B |
