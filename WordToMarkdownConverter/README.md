# WordToMarkdownConverter


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]   : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  ShortRun : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                            | Mean | Error | Ratio | RatioSD |
|---------------------------------- |-----:|------:|------:|--------:|
| ConvertPandocParallelForEach      |   NA |    NA |     ? |       ? |
| ConvertPandocParallelForEachAsync |   NA |    NA |     ? |       ? |
| ConvertPandocForEach              |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  Benchmark.ConvertPandocParallelForEach: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
  Benchmark.ConvertPandocParallelForEachAsync: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
  Benchmark.ConvertPandocForEach: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
