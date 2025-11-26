# GetTypeVsTypeofFullName

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method    | Mean      | Error     | StdDev    | Median    |
|---------- |----------:|----------:|----------:|----------:|
| Scenario1 | 0.0028 ns | 0.0035 ns | 0.0033 ns | 0.0010 ns |
| Scenario2 | 0.0012 ns | 0.0029 ns | 0.0026 ns | 0.0000 ns |
