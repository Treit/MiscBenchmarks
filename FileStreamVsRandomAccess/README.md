## FileStream vs. RandomAccess for reading random portions of a file.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22468
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 6.0.0 (CoreCLR 6.0.21.37719, CoreFX 6.0.21.37719), X64 RyuJIT
  ShortRun : .NET Core 6.0.0 (CoreCLR 6.0.21.37719, CoreFX 6.0.21.37719), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                                        Method |      Count |      Mean |     Error |   StdDev | Ratio | RatioSD |
|---------------------------------------------- |----------- |----------:|----------:|---------:|------:|--------:|
|         **HashFileLocationsUsingFileStreamCrc32** |    **3145728** | **174.31 ms** |  **78.80 ms** | **4.319 ms** |  **1.00** |    **0.00** |
|       HashFileLocationsUsingRandomAccessCrc32 |    3145728 | 169.93 ms | 106.28 ms | 5.826 ms |  0.98 |    0.06 |
|    HashFileLocationsUsingFileStreamMurmurHash |    3145728 |  51.57 ms | 108.80 ms | 5.964 ms |  0.30 |    0.03 |
|  HashFileLocationsUsingRandomAccessMurmurHash |    3145728 |  40.88 ms |  26.08 ms | 1.430 ms |  0.23 |    0.01 |
|   HashFileLocationsUsingFileStreamJenkinsHash |    3145728 |  97.18 ms |  32.95 ms | 1.806 ms |  0.56 |    0.01 |
| HashFileLocationsUsingRandomAccessJenkinsHash |    3145728 | 102.20 ms |  21.39 ms | 1.172 ms |  0.59 |    0.01 |
|                                               |            |           |           |          |       |         |
|         **HashFileLocationsUsingFileStreamCrc32** | **1073741824** | **172.26 ms** |  **73.83 ms** | **4.047 ms** |  **1.00** |    **0.00** |
|       HashFileLocationsUsingRandomAccessCrc32 | 1073741824 | 177.39 ms |  56.13 ms | 3.077 ms |  1.03 |    0.04 |
|    HashFileLocationsUsingFileStreamMurmurHash | 1073741824 |  50.55 ms |  56.62 ms | 3.103 ms |  0.29 |    0.02 |
|  HashFileLocationsUsingRandomAccessMurmurHash | 1073741824 |  54.21 ms |  76.74 ms | 4.206 ms |  0.32 |    0.03 |
|   HashFileLocationsUsingFileStreamJenkinsHash | 1073741824 |  99.29 ms |  98.66 ms | 5.408 ms |  0.58 |    0.03 |
| HashFileLocationsUsingRandomAccessJenkinsHash | 1073741824 | 101.77 ms |  43.42 ms | 2.380 ms |  0.59 |    0.03 |
