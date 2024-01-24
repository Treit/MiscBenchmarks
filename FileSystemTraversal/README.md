# Traversing the file system


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                             Method | Count |     Mean |     Error |    StdDev |
|--------------------------------------------------- |------ |---------:|----------:|----------:|
|                                  TraverseRecursive | 10000 | 9.938 ms | 0.1951 ms | 0.2735 ms |
|                                  TraverseWithStack | 10000 | 9.627 ms | 0.1470 ms | 0.1375 ms |
|                   TraverseWithGetFileSystemEntries | 10000 | 5.493 ms | 0.1090 ms | 0.1212 ms |
|             TraverseWithEnumerateFileSystemEntries | 10000 | 5.123 ms | 0.1023 ms | 0.1293 ms |
| TraverseWithEnumerateFileSystemEntriesParallelLinq | 10000 | 5.174 ms | 0.1011 ms | 0.1450 ms |
