# Writing bytes to an array vs. memory stream




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                    Method |  Count |      Mean |    Error |    StdDev |    Median |
|-------------------------- |------- |----------:|---------:|----------:|----------:|
|                WriteArray | 100000 | 123.78 μs | 3.218 μs |  9.488 μs | 123.47 μs |
|        WriteArrayInChunks | 100000 |  64.76 μs | 3.821 μs | 11.265 μs |  56.91 μs |
|         WriteMemoryStream | 100000 | 236.36 μs | 1.743 μs |  1.361 μs | 235.90 μs |
| WriteMemoryStreamInChunks | 100000 |  64.55 μs | 3.616 μs | 10.663 μs |  57.23 μs |
