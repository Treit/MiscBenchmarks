# String to bytes




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27718.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                         | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| MemoryStreamToGuidUsingBitConverter            | 1000  | 422.49 ns | 7.452 ns | 6.223 ns | 40.30 |    0.77 | 0.0572 |     248 B |          NA |
| MemoryStreamToGuidUsingToHexString             | 1000  |  54.00 ns | 1.015 ns | 1.246 ns |  5.15 |    0.18 | 0.0204 |      88 B |          NA |
| MemoryStreamToGuidUsingSpanAndBigEndian        | 1000  |  10.50 ns | 0.141 ns | 0.125 ns |  1.00 |    0.00 |      - |         - |          NA |
| MemoryStreamToGuidUsingBinaryPrimitivesChatGPT | 1000  |  14.67 ns | 0.321 ns | 0.285 ns |  1.40 |    0.04 |      - |         - |          NA |
| MemoryStreamToGuidUsingReadByteOrThrowChatGPT  | 1000  |  49.17 ns | 0.744 ns | 0.581 ns |  4.69 |    0.08 |      - |         - |          NA |
