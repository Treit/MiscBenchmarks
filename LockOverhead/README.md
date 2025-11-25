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
| ReadWithLock  | 7.2012 ns | 0.1640 ns | 0.1534 ns |
| Read          | 0.3869 ns | 0.0198 ns | 0.0185 ns |
| WriteWithLock | 9.3646 ns | 0.1513 ns | 0.1341 ns |
| Write         | 2.5062 ns | 0.0271 ns | 0.0253 ns |
