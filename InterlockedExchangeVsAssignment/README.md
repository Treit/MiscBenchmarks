# Interlocked.CompareExchange vs. Assignment



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Code Size |
|--------------------------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|
| SetToZeroSimpleAssignment        | 0.0006 ns | 0.0013 ns | 0.0011 ns | 0.0000 ns |     ? |       ? |      11 B |
| SetToZeroWithInterlockedExchange | 1.0594 ns | 0.0142 ns | 0.0126 ns | 1.0620 ns |     ? |       ? |      14 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.SetToZeroSimpleAssignment()
       xor       eax,eax
       mov       [rcx+10],rax
       mov       rax,[rcx+10]
       ret
; Total bytes of code 11
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.SetToZeroWithInterlockedExchange()
       lea       rax,[rcx+10]
       xor       edx,edx
       xchg      rdx,[rax]
       mov       rax,[rcx+10]
       ret
; Total bytes of code 14
```

