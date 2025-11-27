# IterateNullDictionary
This benchmark comes from a real-world case where a dictionary is going to be iterated, but it may be null.

The original code did:







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |---------- |---------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| NewDictionary          | .NET 10.0 | .NET 10.0 | 1000  | 0.5543 ns | 0.0121 ns | 0.0113 ns |  2.64 |    0.25 |         - |          NA |
| EmptyCollectionLiteral | .NET 10.0 | .NET 10.0 | 1000  | 0.5799 ns | 0.0259 ns | 0.0230 ns |  2.76 |    0.28 |         - |          NA |
| EnumerableDotEmpty     | .NET 10.0 | .NET 10.0 | 1000  | 3.0417 ns | 0.0382 ns | 0.0357 ns | 14.50 |    1.37 |         - |          NA |
| NullCheck              | .NET 10.0 | .NET 10.0 | 1000  | 0.2117 ns | 0.0217 ns | 0.0203 ns |  1.01 |    0.13 |         - |          NA |
|                        |           |           |       |           |           |           |       |         |           |             |
| NewDictionary          | .NET 9.0  | .NET 9.0  | 1000  | 0.6829 ns | 0.0184 ns | 0.0163 ns |  3.18 |    0.25 |         - |          NA |
| EmptyCollectionLiteral | .NET 9.0  | .NET 9.0  | 1000  | 0.5742 ns | 0.0208 ns | 0.0194 ns |  2.67 |    0.22 |         - |          NA |
| EnumerableDotEmpty     | .NET 9.0  | .NET 9.0  | 1000  | 3.0418 ns | 0.0307 ns | 0.0287 ns | 14.16 |    1.07 |         - |          NA |
| NullCheck              | .NET 9.0  | .NET 9.0  | 1000  | 0.2160 ns | 0.0181 ns | 0.0169 ns |  1.01 |    0.11 |         - |          NA |
