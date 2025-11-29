# Property access vs. Local variable access





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | Count  | Mean           | Error       | StdDev      | Median         | Ratio | RatioSD | Code Size |
|-------------------- |---------- |---------- |------- |---------------:|------------:|------------:|---------------:|------:|--------:|----------:|
| **PropertyAccess**      | **.NET 10.0** | **.NET 10.0** | **1**      |      **0.0009 ns** |   **0.0014 ns** |   **0.0013 ns** |      **0.0003 ns** |     **?** |       **?** |      **26 B** |
| LocalVariableAccess | .NET 10.0 | .NET 10.0 | 1      |      0.0009 ns |   0.0013 ns |   0.0010 ns |      0.0004 ns |     ? |       ? |      27 B |
|                     |           |           |        |                |             |             |                |       |         |           |
| PropertyAccess      | .NET 9.0  | .NET 9.0  | 1      |      0.0041 ns |   0.0046 ns |   0.0041 ns |      0.0026 ns |     ? |       ? |      26 B |
| LocalVariableAccess | .NET 9.0  | .NET 9.0  | 1      |      0.0027 ns |   0.0035 ns |   0.0033 ns |      0.0010 ns |     ? |       ? |      27 B |
|                     |           |           |        |                |             |             |                |       |         |           |
| **PropertyAccess**      | **.NET 10.0** | **.NET 10.0** | **100000** | **32,037.8752 ns** | **347.1823 ns** | **324.7545 ns** | **32,041.4368 ns** |  **1.03** |    **0.01** |      **26 B** |
| LocalVariableAccess | .NET 10.0 | .NET 10.0 | 100000 | 31,202.3991 ns | 170.8584 ns | 159.8211 ns | 31,182.2449 ns |  1.00 |    0.01 |      27 B |
|                     |           |           |        |                |             |             |                |       |         |           |
| PropertyAccess      | .NET 9.0  | .NET 9.0  | 100000 | 31,769.9181 ns | 332.6869 ns | 277.8086 ns | 31,774.1028 ns |  1.02 |    0.01 |      26 B |
| LocalVariableAccess | .NET 9.0  | .NET 9.0  | 100000 | 31,058.1562 ns | 100.9138 ns |  84.2676 ns | 31,027.6672 ns |  1.00 |    0.00 |      27 B |

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

