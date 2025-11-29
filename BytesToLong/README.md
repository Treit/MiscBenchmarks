# Converting from bytes to long






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Size | Mean      | Error    | StdDev   |
|----------------------------------- |---------- |---------- |----- |----------:|---------:|---------:|
| ToLongBitConverter                 | .NET 10.0 | .NET 10.0 | 100  | 101.66 ns | 0.896 ns | 0.749 ns |
| ToLongBinaryPrimitivesLittleEndian | .NET 10.0 | .NET 10.0 | 100  |  94.73 ns | 1.317 ns | 1.665 ns |
| ToLongMemoryMarshalCast            | .NET 10.0 | .NET 10.0 | 100  | 101.37 ns | 0.559 ns | 0.495 ns |
| ToLongBitConverter                 | .NET 9.0  | .NET 9.0  | 100  | 102.10 ns | 1.755 ns | 2.021 ns |
| ToLongBinaryPrimitivesLittleEndian | .NET 9.0  | .NET 9.0  | 100  |  96.66 ns | 1.968 ns | 2.489 ns |
| ToLongMemoryMarshalCast            | .NET 9.0  | .NET 9.0  | 100  | 108.87 ns | 2.196 ns | 5.046 ns |
