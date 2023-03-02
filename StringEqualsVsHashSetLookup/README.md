# Testing checking a property for equality vs. HashSet lookup.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.25290
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT


```
|            Method | Count |       Mean |     Error |    StdDev |     Median |
|------------------ |------ |-----------:|----------:|----------:|-----------:|
|  CheckUsingEquals | 10000 |  0.8545 ns | 0.0826 ns | 0.2384 ns |  0.8411 ns |
| CheckUsingHashset | 10000 | 41.2491 ns | 1.1582 ns | 3.3230 ns | 41.3047 ns |
|    CheckUsingEnum | 10000 |  0.0706 ns | 0.0302 ns | 0.0881 ns |  0.0306 ns |
