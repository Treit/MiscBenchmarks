# GetType.Name vs. nameof




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method         | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
| NameViaNameOf  | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |         - |           ? |
| NameViaGetType | 2.7783 ns | 0.1198 ns | 0.1380 ns | 2.8754 ns |     ? |       ? |         - |           ? |
