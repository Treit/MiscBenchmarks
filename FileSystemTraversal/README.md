# Traversing the file system



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                             | Count | Mean      | Error     | StdDev    | Median    |
|--------------------------------------------------- |------ |----------:|----------:|----------:|----------:|
| TraverseRecursive                                  | 10000 |  9.485 ms | 0.1893 ms | 0.1771 ms |  9.556 ms |
| TraverseWithStack                                  | 10000 | 10.710 ms | 0.2116 ms | 0.3477 ms | 10.843 ms |
| TraverseWithGetFileSystemEntries                   | 10000 |  5.846 ms | 0.1157 ms | 0.2390 ms |  5.961 ms |
| TraverseWithEnumerateFileSystemEntries             | 10000 |  5.581 ms | 0.0863 ms | 0.0807 ms |  5.594 ms |
| TraverseWithEnumerateFileSystemEntriesParallelLinq | 10000 |  5.568 ms | 0.1054 ms | 0.1128 ms |  5.600 ms |
