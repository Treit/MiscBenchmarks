# Returning an empty sequence






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Job       | Runtime   | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| EnumerableDotEmpty | .NET 10.0 | .NET 10.0 | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| ArrayDotEmpty      | .NET 10.0 | .NET 10.0 | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| NewEmptyArray      | .NET 10.0 | .NET 10.0 | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| NewEmptyList       | .NET 10.0 | .NET 10.0 | 3.8692 ns | 0.0467 ns | 0.0414 ns |     ? |       ? | 0.0019 |      32 B |           ? |
|                    |           |           |           |           |           |       |         |        |           |             |
| EnumerableDotEmpty | .NET 9.0  | .NET 9.0  | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| ArrayDotEmpty      | .NET 9.0  | .NET 9.0  | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| NewEmptyArray      | .NET 9.0  | .NET 9.0  | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| NewEmptyList       | .NET 9.0  | .NET 9.0  | 3.9343 ns | 0.0642 ns | 0.0601 ns |     ? |       ? | 0.0019 |      32 B |           ? |
