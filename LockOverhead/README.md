# Reading and writing a string field with and without locking to demonstrate lock overhead.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method        | Mean      | Error     | StdDev    |
|-------------- |----------:|----------:|----------:|
| ReadWithLock  | 6.8282 ns | 0.0806 ns | 0.0714 ns |
| Read          | 0.4001 ns | 0.0223 ns | 0.0198 ns |
| WriteWithLock | 9.5746 ns | 0.2209 ns | 0.3097 ns |
| Write         | 2.5222 ns | 0.0288 ns | 0.0269 ns |
