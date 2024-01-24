# Converting from bytes to long



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                             Method | Size |     Mean |    Error |   StdDev |
|----------------------------------- |----- |---------:|---------:|---------:|
|                 ToLongBitConverter |  100 | 98.10 ns | 0.810 ns | 0.718 ns |
| ToLongBinaryPrimitivesLittleEndian |  100 | 98.09 ns | 0.344 ns | 0.287 ns |
|            ToLongMemoryMarshalCast |  100 | 97.59 ns | 0.368 ns | 0.287 ns |
