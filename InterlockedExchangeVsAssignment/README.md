# Interlocked.CompareExchange vs. Assignment


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26058.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                           | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Code Size |
|--------------------------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|
| SetToZeroSimpleAssignment        | 0.0101 ns | 0.0128 ns | 0.0309 ns | 0.0000 ns |     ? |       ? |      11 B |
| SetToZeroWithInterlockedExchange | 7.9281 ns | 0.1069 ns | 0.0892 ns | 7.9132 ns |     ? |       ? |      16 B |

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.SetToZeroSimpleAssignment()
       xor       eax,eax
       mov       [rcx+10],rax
       mov       rax,[rcx+10]
       ret
; Total bytes of code 11
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.SetToZeroWithInterlockedExchange()
       cmp       [rcx],cl
       lea       rax,[rcx+10]
       xor       edx,edx
       xchg      rdx,[rax]
       mov       rax,[rcx+10]
       ret
; Total bytes of code 16
```

