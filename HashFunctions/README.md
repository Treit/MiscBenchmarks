# Hash functions.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25305.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                        Method | Size |       Mean |     Error |    StdDev |     Median |
|------------------------------ |----- |-----------:|----------:|----------:|-----------:|
|                   HashJenkins | 1024 | 1,474.4 ns |  25.59 ns |  27.38 ns | 1,464.2 ns |
|                     HashCRC32 | 1024 | 2,687.4 ns |  33.79 ns |  29.96 ns | 2,674.9 ns |
|      HashSystemIOHashingCRC32 | 1024 | 2,648.5 ns |  22.47 ns |  21.02 ns | 2,652.7 ns |
|                  HashMurmur32 | 1024 |   593.9 ns |  15.04 ns |  41.43 ns |   582.4 ns |
|                   HashFNV1_32 | 1024 | 1,159.9 ns |  15.45 ns |  14.45 ns | 1,156.7 ns |
|                  HashMurmur64 | 1024 |   490.0 ns |  27.17 ns |  79.25 ns |   468.6 ns |
|                   HashFNV1_64 | 1024 | 1,172.0 ns |  16.23 ns |  14.39 ns | 1,170.9 ns |
| HashFNV1_32_StackOverflowLinq | 1024 | 7,692.5 ns | 307.50 ns | 901.85 ns | 7,497.9 ns |
