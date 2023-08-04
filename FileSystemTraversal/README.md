# Traversing the file system

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25921.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2


```
|                                             Method | Count |      Mean |     Error |    StdDev |
|--------------------------------------------------- |------ |----------:|----------:|----------:|
|                                  TraverseRecursive | 10000 | 14.768 ms | 0.2037 ms | 0.1806 ms |
|                                  TraverseWithStack | 10000 | 15.417 ms | 0.3046 ms | 0.6359 ms |
|                   TraverseWithGetFileSystemEntries | 10000 |  8.697 ms | 0.1440 ms | 0.1276 ms |
|             TraverseWithEnumerateFileSystemEntries | 10000 |  8.065 ms | 0.1105 ms | 0.0922 ms |
| TraverseWithEnumerateFileSystemEntriesParallelLinq | 10000 |  8.161 ms | 0.1628 ms | 0.2851 ms |
