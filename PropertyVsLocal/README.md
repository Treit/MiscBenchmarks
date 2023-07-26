# Property access vs. Local variable access

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|              Method |  Count |           Mean |       Error |      StdDev | Ratio | RatioSD | Code Size |
|-------------------- |------- |---------------:|------------:|------------:|------:|--------:|----------:|
|      **PropertyAccess** |      **1** |      **0.2306 ns** |   **0.0307 ns** |   **0.0354 ns** |  **0.83** |    **0.16** |      **32 B** |
| LocalVariableAccess |      1 |      0.2826 ns |   0.0198 ns |   0.0185 ns |  1.00 |    0.00 |      44 B |
|                     |        |                |             |             |       |         |           |
|      **PropertyAccess** | **100000** | **27,932.9821 ns** | **312.2310 ns** | **276.7847 ns** |  **1.01** |    **0.01** |      **32 B** |
| LocalVariableAccess | 100000 | 27,740.4292 ns | 167.6411 ns | 139.9879 ns |  1.00 |    0.00 |      44 B |


## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.PropertyAccess()
;             long result = 0;
;             ^^^^^^^^^^^^^^^^
;             for (int i = 0; i < Count; i++)
;                  ^^^^^^^^^
;                 result += _instance.Data;
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^
;             return result;
;             ^^^^^^^^^^^^^^
       xor       eax,eax
       xor       edx,edx
       mov       r8d,[rcx+10]
       test      r8d,r8d
       jle       short M00_L01
       mov       rcx,[rcx+8]
       movzx     ecx,byte ptr [rcx+8]
M00_L00:
       add       rax,rcx
       inc       edx
       cmp       edx,r8d
       jl        short M00_L00
M00_L01:
       ret
; Total bytes of code 32
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.LocalVariableAccess()
;             long result = 0;
;             ^^^^^^^^^^^^^^^^
;             var data = _instance.Data;
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^
;             for (int i = 0; i < Count; i++)
;                  ^^^^^^^^^
;                 result += data;
;                 ^^^^^^^^^^^^^^^
;             return result;
;             ^^^^^^^^^^^^^^
       xor       eax,eax
       mov       rdx,[rcx+8]
       movzx     edx,byte ptr [rdx+8]
       xor       r8d,r8d
       mov       ecx,[rcx+10]
       test      ecx,ecx
       jle       short M00_L01
       mov       edx,edx
       nop       word ptr [rax+rax]
M00_L00:
       add       rax,rdx
       inc       r8d
       cmp       r8d,ecx
       jl        short M00_L00
M00_L01:
       ret
; Total bytes of code 44
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.PropertyAccess()
;             long result = 0;
;             ^^^^^^^^^^^^^^^^
;             for (int i = 0; i < Count; i++)
;                  ^^^^^^^^^
;                 result += _instance.Data;
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^
;             return result;
;             ^^^^^^^^^^^^^^
       xor       eax,eax
       xor       edx,edx
       mov       r8d,[rcx+10]
       test      r8d,r8d
       jle       short M00_L01
       mov       rcx,[rcx+8]
       movzx     ecx,byte ptr [rcx+8]
M00_L00:
       add       rax,rcx
       inc       edx
       cmp       edx,r8d
       jl        short M00_L00
M00_L01:
       ret
; Total bytes of code 32
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.LocalVariableAccess()
;             long result = 0;
;             ^^^^^^^^^^^^^^^^
;             var data = _instance.Data;
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^
;             for (int i = 0; i < Count; i++)
;                  ^^^^^^^^^
;                 result += data;
;                 ^^^^^^^^^^^^^^^
;             return result;
;             ^^^^^^^^^^^^^^
       xor       eax,eax
       mov       rdx,[rcx+8]
       movzx     edx,byte ptr [rdx+8]
       xor       r8d,r8d
       mov       ecx,[rcx+10]
       test      ecx,ecx
       jle       short M00_L01
       mov       edx,edx
       nop       word ptr [rax+rax]
M00_L00:
       add       rax,rdx
       inc       r8d
       cmp       r8d,ecx
       jl        short M00_L00
M00_L01:
       ret
; Total bytes of code 44
```

