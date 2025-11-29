# Reading and writing a string field with and without locking to demonstrate lock overhead.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method        | Job       | Runtime   | Mean      | Error     | StdDev    |
|-------------- |---------- |---------- |----------:|----------:|----------:|
| ReadWithLock  | .NET 10.0 | .NET 10.0 | 6.4538 ns | 0.0263 ns | 0.0205 ns |
| Read          | .NET 10.0 | .NET 10.0 | 0.4309 ns | 0.0104 ns | 0.0098 ns |
| WriteWithLock | .NET 10.0 | .NET 10.0 | 9.0289 ns | 0.0730 ns | 0.0610 ns |
| Write         | .NET 10.0 | .NET 10.0 | 2.4847 ns | 0.0056 ns | 0.0047 ns |
| ReadWithLock  | .NET 9.0  | .NET 9.0  | 7.5920 ns | 0.0560 ns | 0.0497 ns |
| Read          | .NET 9.0  | .NET 9.0  | 0.4197 ns | 0.0099 ns | 0.0092 ns |
| WriteWithLock | .NET 9.0  | .NET 9.0  | 9.2934 ns | 0.1991 ns | 0.3158 ns |
| Write         | .NET 9.0  | .NET 9.0  | 2.4998 ns | 0.0048 ns | 0.0042 ns |
