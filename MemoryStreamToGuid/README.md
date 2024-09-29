# String to bytes



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27713.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                  | Count | Mean       | Error     | StdDev     | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------- |------ |-----------:|----------:|-----------:|-------:|--------:|-------:|----------:|------------:|
| MemoryStreamToGuidUsingBitConverter     | 1000  | 425.772 ns | 8.5401 ns | 12.7824 ns | 129.32 |    9.93 | 0.0572 |     248 B |          NA |
| MemoryStreamToGuidUsingToHexString      | 1000  |  54.718 ns | 1.0312 ns |  1.4789 ns |  16.60 |    1.20 | 0.0204 |      88 B |          NA |
| MemoryStreamToGuidUsingSpanAndBigEndian | 1000  |   3.207 ns | 0.0997 ns |  0.2388 ns |   1.00 |    0.00 |      - |         - |          NA |
