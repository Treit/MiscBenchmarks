# Turning a single item into an IEnumerable.


``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25252
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100
  [Host]     : .NET Core 6.0.11 (CoreCLR 6.0.1122.52304, CoreFX 6.0.1122.52304), X64 RyuJIT
  DefaultJob : .NET Core 6.0.11 (CoreCLR 6.0.1122.52304, CoreFX 6.0.1122.52304), X64 RyuJIT


```
|                                 Method |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------- |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|       SingleItemIntEnumerableDotRepeat | 17.05 ns | 0.375 ns | 0.968 ns |  1.00 |    0.00 | 0.0074 |     - |     - |      32 B |
|        SingleItemIntEnumerableNewArray | 20.85 ns | 0.441 ns | 0.761 ns |  1.20 |    0.09 | 0.0148 |     - |     - |      64 B |
|    SingleItemIntEnumerableWrapperClass | 10.08 ns | 0.234 ns | 0.240 ns |  0.55 |    0.03 | 0.0056 |     - |     - |      24 B |
|    SingleItemStringEnumerableDotRepeat | 18.79 ns | 0.309 ns | 0.274 ns |  1.02 |    0.05 | 0.0093 |     - |     - |      40 B |
|     SingleItemStringEnumerableNewArray | 25.72 ns | 0.546 ns | 0.765 ns |  1.47 |    0.11 | 0.0148 |     - |     - |      64 B |
| SingleItemStringEnumerableWrapperClass | 11.88 ns | 0.193 ns | 0.171 ns |  0.65 |    0.03 | 0.0074 |     - |     - |      32 B |
