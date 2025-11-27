# Counting strings using a for loop vs. a foreach loop.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | Count  | Mean          | Error         | StdDev        | Code Size |
|------------------------ |---------- |---------- |------- |--------------:|--------------:|--------------:|----------:|
| **ForLoopCountFieldAccess** | **.NET 10.0** | **.NET 10.0** | **10**     |      **8.876 ns** |     **0.0698 ns** |     **0.0653 ns** |      **75 B** |
| ForLoopCountLocalAccess | .NET 10.0 | .NET 10.0 | 10     |      4.749 ns |     0.0199 ns |     0.0187 ns |      55 B |
| ForEachLoopCount        | .NET 10.0 | .NET 10.0 | 10     |      4.781 ns |     0.0290 ns |     0.0242 ns |      55 B |
| ForLoopCountFieldAccess | .NET 9.0  | .NET 9.0  | 10     |      8.864 ns |     0.0774 ns |     0.0724 ns |      75 B |
| ForLoopCountLocalAccess | .NET 9.0  | .NET 9.0  | 10     |      4.749 ns |     0.0274 ns |     0.0243 ns |      55 B |
| ForEachLoopCount        | .NET 9.0  | .NET 9.0  | 10     |      4.797 ns |     0.0372 ns |     0.0348 ns |      55 B |
| **ForLoopCountFieldAccess** | **.NET 10.0** | **.NET 10.0** | **100**    |     **76.046 ns** |     **0.6979 ns** |     **0.6528 ns** |      **70 B** |
| ForLoopCountLocalAccess | .NET 10.0 | .NET 10.0 | 100    |     52.310 ns |     0.5041 ns |     0.4716 ns |      54 B |
| ForEachLoopCount        | .NET 10.0 | .NET 10.0 | 100    |     54.534 ns |     0.2325 ns |     0.2061 ns |      54 B |
| ForLoopCountFieldAccess | .NET 9.0  | .NET 9.0  | 100    |     77.870 ns |     0.5188 ns |     0.4853 ns |      70 B |
| ForLoopCountLocalAccess | .NET 9.0  | .NET 9.0  | 100    |     52.119 ns |     0.3295 ns |     0.3082 ns |      54 B |
| ForEachLoopCount        | .NET 9.0  | .NET 9.0  | 100    |     52.446 ns |     0.5187 ns |     0.4852 ns |      54 B |
| **ForLoopCountFieldAccess** | **.NET 10.0** | **.NET 10.0** | **100000** | **71,821.401 ns** |   **797.0603 ns** |   **745.5707 ns** |      **70 B** |
| ForLoopCountLocalAccess | .NET 10.0 | .NET 10.0 | 100000 | 55,002.347 ns |   823.3656 ns |   729.8922 ns |      54 B |
| ForEachLoopCount        | .NET 10.0 | .NET 10.0 | 100000 | 55,960.447 ns | 1,090.7877 ns | 1,529.1321 ns |      54 B |
| ForLoopCountFieldAccess | .NET 9.0  | .NET 9.0  | 100000 | 73,427.304 ns |   606.0080 ns |   566.8602 ns |      70 B |
| ForLoopCountLocalAccess | .NET 9.0  | .NET 9.0  | 100000 | 56,071.884 ns | 1,018.1478 ns | 1,728.8923 ns |      54 B |
| ForEachLoopCount        | .NET 9.0  | .NET 9.0  | 100000 | 55,446.028 ns |   941.7954 ns |   967.1546 ns |      55 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax]
M00_L00:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L04
       mov       r8,[r8+rdx*8+10]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 75
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L02
       add       rcx,10
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       add       rcx,8
       dec       edx
       jne       short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 55
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L02
       add       rcx,10
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       add       rcx,8
       dec       edx
       jne       short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 55
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax]
M00_L00:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L04
       mov       r8,[r8+rdx*8+10]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 75
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L02
       add       rcx,10
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       add       rcx,8
       dec       edx
       jne       short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 55
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L02
       add       rcx,10
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       add       rcx,8
       dec       edx
       jne       short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 55
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jg        short M00_L02
M00_L00:
       add       rsp,28
       ret
       nop       word ptr [rax+rax]
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jle       short M00_L00
M00_L02:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L03
       mov       r8,[r8+rdx*8+10]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       inc       eax
       jmp       short M00_L01
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 70
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jg        short M00_L02
M00_L00:
       add       rsp,28
       ret
       nop       word ptr [rax+rax]
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jle       short M00_L00
M00_L02:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L03
       mov       r8,[r8+rdx*8+10]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       inc       eax
       jmp       short M00_L01
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 70
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jg        short M00_L02
M00_L00:
       add       rsp,28
       ret
       nop       word ptr [rax+rax]
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jle       short M00_L00
M00_L02:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L03
       mov       r8,[r8+rdx*8+10]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       inc       eax
       jmp       short M00_L01
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 70
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jg        short M00_L02
M00_L00:
       add       rsp,28
       ret
       nop       word ptr [rax+rax]
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jle       short M00_L00
M00_L02:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L03
       mov       r8,[r8+rdx*8+10]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       inc       eax
       jmp       short M00_L01
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 70
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L03
       add       rcx,10
       jmp       short M00_L02
       nop       dword ptr [rax+rax]
       nop       dword ptr [rax+rax]
M00_L00:
       inc       eax
M00_L01:
       add       rcx,8
       dec       edx
       je        short M00_L03
M00_L02:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       jmp       short M00_L00
M00_L03:
       ret
; Total bytes of code 55
```

