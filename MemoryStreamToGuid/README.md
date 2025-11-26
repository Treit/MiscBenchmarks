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
| MemoryStreamToGuidUsingBitConverter            | 1000  | 334.468 ns | 4.2823 ns | 4.0057 ns | 36.65 |    0.46 | 0.0148 |     248 B |          NA |
| MemoryStreamToGuidUsingToHexString             | 1000  |  50.120 ns | 0.4425 ns | 0.4139 ns |  5.49 |    0.05 | 0.0052 |      88 B |          NA |
| MemoryStreamToGuidUsingSpanAndBigEndian        | 1000  |   9.127 ns | 0.0559 ns | 0.0437 ns |  1.00 |    0.01 |      - |         - |          NA |
| MemoryStreamToGuidUsingBinaryPrimitivesChatGPT | 1000  |  13.871 ns | 0.2063 ns | 0.1930 ns |  1.52 |    0.02 |      - |         - |          NA |
| MemoryStreamToGuidUsingReadByteOrThrowChatGPT  | 1000  |  40.727 ns | 0.3173 ns | 0.2968 ns |  4.46 |    0.04 |      - |         - |          NA |
