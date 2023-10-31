# Writing bytes to an array vs. memory stream



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25987.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2


```
|                    Method |  Count |      Mean |    Error |   StdDev |
|-------------------------- |------- |----------:|---------:|---------:|
|                WriteArray | 100000 | 161.53 μs | 3.167 μs | 5.711 μs |
|        WriteArrayInChunks | 100000 |  69.24 μs | 1.246 μs | 1.826 μs |
|         WriteMemoryStream | 100000 | 363.24 μs | 7.116 μs | 7.308 μs |
| WriteMemoryStreamInChunks | 100000 |  67.05 μs | 0.707 μs | 0.626 μs |
