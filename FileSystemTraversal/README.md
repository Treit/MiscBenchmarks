# Traversing the file system





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                             | Job       | Runtime   | Count | Mean      | Error     | StdDev    |
|--------------------------------------------------- |---------- |---------- |------ |----------:|----------:|----------:|
| TraverseRecursive                                  | .NET 10.0 | .NET 10.0 | 10000 |  8.820 ms | 0.1422 ms | 0.1187 ms |
| TraverseWithStack                                  | .NET 10.0 | .NET 10.0 | 10000 |  9.824 ms | 0.1907 ms | 0.3080 ms |
| TraverseWithGetFileSystemEntries                   | .NET 10.0 | .NET 10.0 | 10000 |  5.579 ms | 0.1048 ms | 0.0929 ms |
| TraverseWithEnumerateFileSystemEntries             | .NET 10.0 | .NET 10.0 | 10000 |  5.142 ms | 0.0828 ms | 0.0774 ms |
| TraverseWithEnumerateFileSystemEntriesParallelLinq | .NET 10.0 | .NET 10.0 | 10000 |  4.519 ms | 0.0589 ms | 0.0492 ms |
| TraverseRecursive                                  | .NET 9.0  | .NET 9.0  | 10000 |  9.880 ms | 0.1193 ms | 0.1058 ms |
| TraverseWithStack                                  | .NET 9.0  | .NET 9.0  | 10000 | 10.054 ms | 0.1691 ms | 0.1661 ms |
| TraverseWithGetFileSystemEntries                   | .NET 9.0  | .NET 9.0  | 10000 |  5.566 ms | 0.1046 ms | 0.0978 ms |
| TraverseWithEnumerateFileSystemEntries             | .NET 9.0  | .NET 9.0  | 10000 |  5.184 ms | 0.0865 ms | 0.0722 ms |
| TraverseWithEnumerateFileSystemEntriesParallelLinq | .NET 9.0  | .NET 9.0  | 10000 |  5.136 ms | 0.0711 ms | 0.0594 ms |
