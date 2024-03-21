# Dynamic vs regular C# types



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26052.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                 | Size | Mean        | Error       | StdDev      | Ratio  | RatioSD | Gen0      | Gen1      | Gen2      | Allocated | Alloc Ratio |
|----------------------- |----- |------------:|------------:|------------:|-------:|--------:|----------:|----------:|----------:|----------:|------------:|
| InitJaggedArray        | 1024 |    750.1 μs |    14.72 μs |    36.66 μs |   1.00 |    0.00 |  188.4766 |  142.5781 |         - |   1.03 MB |        1.00 |
| InitDynamicJaggedArray | 1024 | 91,961.3 μs | 1,801.53 μs | 1,769.35 μs | 120.42 |    4.99 | 6333.3333 | 3833.3333 | 1000.0000 |  32.03 MB |       31.06 |
