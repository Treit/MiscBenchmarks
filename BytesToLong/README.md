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
| ToLongBitConverter                 | 100  | 101.68 ns | 0.559 ns | 0.495 ns | 101.75 ns |
| ToLongBinaryPrimitivesLittleEndian | 100  |  94.25 ns | 0.642 ns | 0.536 ns |  94.25 ns |
| ToLongMemoryMarshalCast            | 100  | 105.79 ns | 2.156 ns | 5.866 ns | 101.72 ns |
