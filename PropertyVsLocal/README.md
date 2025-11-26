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
| **PropertyAccess**      | **1**      |      **0.0012 ns** |   **0.0019 ns** |   **0.0016 ns** |      **0.0002 ns** |     **?** |       **?** |      **26 B** |
| LocalVariableAccess | 1      |      0.0047 ns |   0.0054 ns |   0.0051 ns |      0.0018 ns |     ? |       ? |      27 B |
|                     |        |                |             |             |                |       |         |           |
| **PropertyAccess**      | **100000** | **31,250.7910 ns** | **175.5380 ns** | **164.1983 ns** | **31,298.2605 ns** |  **1.00** |    **0.01** |      **26 B** |
| LocalVariableAccess | 100000 | 31,249.4226 ns | 214.2203 ns | 200.3818 ns | 31,381.6589 ns |  1.00 |    0.01 |      27 B |

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

