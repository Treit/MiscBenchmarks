# Property access vs. Local variable access



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Count  | Mean           | Error       | StdDev      | Median         | Ratio | RatioSD | Code Size |
|-------------------- |------- |---------------:|------------:|------------:|---------------:|------:|--------:|----------:|
| **PropertyAccess**      | **1**      |      **0.0011 ns** |   **0.0022 ns** |   **0.0019 ns** |      **0.0001 ns** |     **?** |       **?** |      **26 B** |
| LocalVariableAccess | 1      |      0.0026 ns |   0.0023 ns |   0.0018 ns |      0.0027 ns |     ? |       ? |      27 B |
|                     |        |                |             |             |                |       |         |           |
| **PropertyAccess**      | **100000** | **31,454.7457 ns** | **245.5280 ns** | **229.6671 ns** | **31,613.9893 ns** |  **1.00** |    **0.01** |      **26 B** |
| LocalVariableAccess | 100000 | 31,351.2789 ns | 220.0167 ns | 205.8038 ns | 31,224.0051 ns |  1.00 |    0.01 |      27 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.PropertyAccess()
;         long result = 0;
;         ^^^^^^^^^^^^^^^^
;         for (int i = 0; i < Count; i++)
;              ^^^^^^^^^
;             result += _instance.Data;
;             ^^^^^^^^^^^^^^^^^^^^^^^^^
;         return result;
;         ^^^^^^^^^^^^^^
       xor       eax,eax
       mov       edx,[rcx+10]
       test      edx,edx
       jle       short M00_L01
M00_L00:
       mov       r8,[rcx+8]
       movzx     r8d,byte ptr [r8+8]
       add       rax,r8
       dec       edx
       jne       short M00_L00
M00_L01:
       ret
; Total bytes of code 26
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.LocalVariableAccess()
;         long result = 0;
;         ^^^^^^^^^^^^^^^^
;         var data = _instance.Data;
;         ^^^^^^^^^^^^^^^^^^^^^^^^^^
;         for (int i = 0; i < Count; i++)
;              ^^^^^^^^^
;             result += data;
;             ^^^^^^^^^^^^^^^
;         return result;
;         ^^^^^^^^^^^^^^
       xor       eax,eax
       mov       rdx,[rcx+8]
       movzx     edx,byte ptr [rdx+8]
       mov       ecx,[rcx+10]
       test      ecx,ecx
       jle       short M00_L01
       mov       edx,edx
M00_L00:
       add       rax,rdx
       dec       ecx
       jne       short M00_L00
M00_L01:
       ret
; Total bytes of code 27
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.PropertyAccess()
;         long result = 0;
;         ^^^^^^^^^^^^^^^^
;         for (int i = 0; i < Count; i++)
;              ^^^^^^^^^
;             result += _instance.Data;
;             ^^^^^^^^^^^^^^^^^^^^^^^^^
;         return result;
;         ^^^^^^^^^^^^^^
       xor       eax,eax
       mov       edx,[rcx+10]
       test      edx,edx
       jle       short M00_L01
M00_L00:
       mov       r8,[rcx+8]
       movzx     r8d,byte ptr [r8+8]
       add       rax,r8
       dec       edx
       jne       short M00_L00
M00_L01:
       ret
; Total bytes of code 26
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.LocalVariableAccess()
;         long result = 0;
;         ^^^^^^^^^^^^^^^^
;         var data = _instance.Data;
;         ^^^^^^^^^^^^^^^^^^^^^^^^^^
;         for (int i = 0; i < Count; i++)
;              ^^^^^^^^^
;             result += data;
;             ^^^^^^^^^^^^^^^
;         return result;
;         ^^^^^^^^^^^^^^
       xor       eax,eax
       mov       rdx,[rcx+8]
       movzx     edx,byte ptr [rdx+8]
       mov       ecx,[rcx+10]
       test      ecx,ecx
       jle       short M00_L01
       mov       edx,edx
M00_L00:
       add       rax,rdx
       dec       ecx
       jne       short M00_L00
M00_L01:
       ret
; Total bytes of code 27
```

