# String to bytes





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| MemoryStreamToGuidUsingBitConverter            | 1000  | 331.677 ns | 3.4796 ns | 3.0846 ns | 37.52 |    0.41 | 0.0148 |     248 B |          NA |
| MemoryStreamToGuidUsingToHexString             | 1000  |  50.394 ns | 0.2132 ns | 0.1780 ns |  5.70 |    0.04 | 0.0052 |      88 B |          NA |
| MemoryStreamToGuidUsingSpanAndBigEndian        | 1000  |   8.840 ns | 0.0639 ns | 0.0566 ns |  1.00 |    0.01 |      - |         - |          NA |
| MemoryStreamToGuidUsingBinaryPrimitivesChatGPT | 1000  |  13.789 ns | 0.1209 ns | 0.1072 ns |  1.56 |    0.02 |      - |         - |          NA |
| MemoryStreamToGuidUsingReadByteOrThrowChatGPT  | 1000  |  40.619 ns | 0.3102 ns | 0.2750 ns |  4.60 |    0.04 |      - |         - |          NA |
