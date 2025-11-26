# Traversing the file system




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                             | Count | Mean      | Error     | StdDev    |
|--------------------------------------------------- |------ |----------:|----------:|----------:|
| TraverseRecursive                                  | 10000 | 10.731 ms | 0.2138 ms | 0.3328 ms |
| TraverseWithStack                                  | 10000 | 10.943 ms | 0.1071 ms | 0.1002 ms |
| TraverseWithGetFileSystemEntries                   | 10000 |  6.201 ms | 0.1212 ms | 0.1488 ms |
| TraverseWithEnumerateFileSystemEntries             | 10000 |  5.597 ms | 0.1094 ms | 0.1384 ms |
| TraverseWithEnumerateFileSystemEntriesParallelLinq | 10000 |  5.620 ms | 0.0565 ms | 0.0501 ms |
