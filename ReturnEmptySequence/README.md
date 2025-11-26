# Returning an empty sequence





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| EnumerableDotEmpty | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| ArrayDotEmpty      | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| NewEmptyArray      | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |           ? |
| NewEmptyList       | 4.0516 ns | 0.1088 ns | 0.0964 ns |     ? |       ? | 0.0019 |      32 B |           ? |
