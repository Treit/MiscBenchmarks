# GetType.Name vs. nameof


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|         Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
|  NameViaNameOf | 0.0004 ns | 0.0009 ns | 0.0007 ns | 0.0000 ns |     ? |       ? |         - |           ? |
| NameViaGetType | 7.4465 ns | 0.0297 ns | 0.0248 ns | 7.4370 ns |     ? |       ? |         - |           ? |
