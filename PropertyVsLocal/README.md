# Property access vs. Local variable access


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|              Method |  Count |           Mean |       Error |      StdDev |         Median | Ratio | RatioSD | Code Size |
|-------------------- |------- |---------------:|------------:|------------:|---------------:|------:|--------:|----------:|
|      **PropertyAccess** |      **1** |      **0.0000 ns** |   **0.0000 ns** |   **0.0000 ns** |      **0.0000 ns** |     **?** |       **?** |      **32 B** |
| LocalVariableAccess |      1 |      0.0019 ns |   0.0033 ns |   0.0029 ns |      0.0000 ns |     ? |       ? |      34 B |
|                     |        |                |             |             |                |       |         |           |
|      **PropertyAccess** | **100000** | **30,968.6646 ns** |  **25.5553 ns** |  **21.3398 ns** | **30,961.7737 ns** |  **1.00** |    **0.00** |      **32 B** |
| LocalVariableAccess | 100000 | 31,048.7701 ns | 164.0543 ns | 145.4298 ns | 30,987.4512 ns |  1.00 |    0.00 |      44 B |

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
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

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
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
M00_L00:
       add       rax,rdx
       inc       r8d
       cmp       r8d,ecx
       jl        short M00_L00
M00_L01:
       ret
; Total bytes of code 34
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
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

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
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

