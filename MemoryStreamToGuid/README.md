# String to bytes







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Job       | Runtime   | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------------- |---------- |---------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| MemoryStreamToGuidUsingBitConverter            | .NET 10.0 | .NET 10.0 | 1000  | 337.759 ns | 1.7228 ns | 1.6115 ns | 35.31 |    0.17 | 0.0148 |     248 B |          NA |
| MemoryStreamToGuidUsingToHexString             | .NET 10.0 | .NET 10.0 | 1000  |  49.239 ns | 0.2945 ns | 0.2755 ns |  5.15 |    0.03 | 0.0052 |      88 B |          NA |
| MemoryStreamToGuidUsingSpanAndBigEndian        | .NET 10.0 | .NET 10.0 | 1000  |   9.565 ns | 0.0096 ns | 0.0085 ns |  1.00 |    0.00 |      - |         - |          NA |
| MemoryStreamToGuidUsingBinaryPrimitivesChatGPT | .NET 10.0 | .NET 10.0 | 1000  |  13.638 ns | 0.0239 ns | 0.0224 ns |  1.43 |    0.00 |      - |         - |          NA |
| MemoryStreamToGuidUsingReadByteOrThrowChatGPT  | .NET 10.0 | .NET 10.0 | 1000  |  40.324 ns | 0.0387 ns | 0.0343 ns |  4.22 |    0.01 |      - |         - |          NA |
|                                                |           |           |       |            |           |           |       |         |        |           |             |
| MemoryStreamToGuidUsingBitConverter            | .NET 9.0  | .NET 9.0  | 1000  | 336.585 ns | 1.5131 ns | 1.4153 ns | 37.00 |    0.20 | 0.0148 |     248 B |          NA |
| MemoryStreamToGuidUsingToHexString             | .NET 9.0  | .NET 9.0  | 1000  |  55.592 ns | 0.2796 ns | 0.2615 ns |  6.11 |    0.04 | 0.0052 |      88 B |          NA |
| MemoryStreamToGuidUsingSpanAndBigEndian        | .NET 9.0  | .NET 9.0  | 1000  |   9.097 ns | 0.0416 ns | 0.0347 ns |  1.00 |    0.01 |      - |         - |          NA |
| MemoryStreamToGuidUsingBinaryPrimitivesChatGPT | .NET 9.0  | .NET 9.0  | 1000  |  13.709 ns | 0.0215 ns | 0.0201 ns |  1.51 |    0.01 |      - |         - |          NA |
| MemoryStreamToGuidUsingReadByteOrThrowChatGPT  | .NET 9.0  | .NET 9.0  | 1000  |  40.257 ns | 0.0415 ns | 0.0347 ns |  4.43 |    0.02 |      - |         - |          NA |
