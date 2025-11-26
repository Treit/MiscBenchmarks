# Converting from bytes to long





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Size | Mean      | Error    | StdDev   | Median    |
|----------------------------------- |----- |----------:|---------:|---------:|----------:|
| ToLongBitConverter                 | 100  | 101.36 ns | 0.658 ns | 0.616 ns | 101.19 ns |
| ToLongBinaryPrimitivesLittleEndian | 100  |  94.75 ns | 0.487 ns | 0.406 ns |  94.57 ns |
| ToLongMemoryMarshalCast            | 100  | 105.72 ns | 2.141 ns | 5.089 ns | 102.60 ns |
