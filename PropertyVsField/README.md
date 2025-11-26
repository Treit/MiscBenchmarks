# Properties vs. Fields




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Mean     | Error   | StdDev  | Code Size |
|------------------------------ |---------:|--------:|--------:|----------:|
| GetProperty                   | 381.0 ns | 1.86 ns | 1.74 ns |      42 B |
| GetPropertyAggressiveInlining | 380.1 ns | 1.25 ns | 1.17 ns |      42 B |
| GetField                      | 380.7 ns | 2.02 ns | 1.89 ns |      42 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.GetProperty()
       xor       eax,eax
       xor       r8d,r8d
       mov       r10d,[rcx+10]
       test      r10d,r10d
       jle       short M00_L01
M00_L00:
       mov       rax,[rcx+8]
       mov       r8,[rax+10]
       mov       rax,[rax+8]
       dec       r10d
       jne       short M00_L00
M00_L01:
       mov       [rdx],rax
       mov       [rdx+8],r8
       mov       rax,rdx
       ret
; Total bytes of code 42
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.GetPropertyAggressiveInlining()
       xor       eax,eax
       xor       r8d,r8d
       mov       r10d,[rcx+10]
       test      r10d,r10d
       jle       short M00_L01
M00_L00:
       mov       rax,[rcx+8]
       mov       r8,[rax+10]
       mov       rax,[rax+8]
       dec       r10d
       jne       short M00_L00
M00_L01:
       mov       [rdx],rax
       mov       [rdx+8],r8
       mov       rax,rdx
       ret
; Total bytes of code 42
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.GetField()
       xor       eax,eax
       xor       r8d,r8d
       mov       r10d,[rcx+10]
       test      r10d,r10d
       jle       short M00_L01
M00_L00:
       mov       rax,[rcx+8]
       mov       r8,[rax+10]
       mov       rax,[rax+8]
       dec       r10d
       jne       short M00_L00
M00_L01:
       mov       [rdx],rax
       mov       [rdx+8],r8
       mov       rax,rdx
       ret
; Total bytes of code 42
```

