# GetType.Name vs. nameof





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method         | Job       | Runtime   | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------- |---------- |---------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| NameViaNameOf  | .NET 10.0 | .NET 10.0 | 0.5581 ns | 0.0385 ns | 0.0342 ns |  1.00 |    0.08 |         - |          NA |
| NameViaGetType | .NET 10.0 | .NET 10.0 | 2.5257 ns | 0.0361 ns | 0.0302 ns |  4.54 |    0.27 |         - |          NA |
|                |           |           |           |           |           |       |         |           |             |
| NameViaNameOf  | .NET 9.0  | .NET 9.0  | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |         - |           ? |
| NameViaGetType | .NET 9.0  | .NET 9.0  | 2.5725 ns | 0.0309 ns | 0.0258 ns |     ? |       ? |         - |           ? |
