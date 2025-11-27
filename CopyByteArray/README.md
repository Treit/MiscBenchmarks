# Shallow copy an array of bytes.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Count | Mean       | Error     | StdDev     | Ratio | RatioSD | Code Size |
|------------------------- |---------- |---------- |------ |-----------:|----------:|-----------:|------:|--------:|----------:|
| **CloneWithToArray**         | **.NET 10.0** | **.NET 10.0** | **10**    |   **8.124 ns** | **0.1597 ns** |  **0.1415 ns** |  **1.00** |    **0.02** |   **2,793 B** |
| CloneWithArrayCopy       | .NET 10.0 | .NET 10.0 | 10    |   6.709 ns | 0.1032 ns |  0.0915 ns |  0.83 |    0.02 |   1,588 B |
| CloneWithBufferBlockCopy | .NET 10.0 | .NET 10.0 | 10    |   6.991 ns | 0.1732 ns |  0.1621 ns |  0.86 |    0.02 |     633 B |
| CloneWithAsSpanToArray   | .NET 10.0 | .NET 10.0 | 10    |   6.562 ns | 0.1651 ns |  0.1463 ns |  0.81 |    0.02 |     424 B |
|                          |           |           |       |            |           |            |       |         |           |
| CloneWithToArray         | .NET 9.0  | .NET 9.0  | 10    |   7.887 ns | 0.1281 ns |  0.1198 ns |  1.00 |    0.02 |   2,793 B |
| CloneWithArrayCopy       | .NET 9.0  | .NET 9.0  | 10    |   6.585 ns | 0.1534 ns |  0.1435 ns |  0.84 |    0.02 |   1,588 B |
| CloneWithBufferBlockCopy | .NET 9.0  | .NET 9.0  | 10    |   7.001 ns | 0.1958 ns |  0.1831 ns |  0.89 |    0.03 |     633 B |
| CloneWithAsSpanToArray   | .NET 9.0  | .NET 9.0  | 10    |   6.724 ns | 0.1109 ns |  0.1038 ns |  0.85 |    0.02 |     424 B |
|                          |           |           |       |            |           |            |       |         |           |
| **CloneWithToArray**         | **.NET 10.0** | **.NET 10.0** | **100**   |  **12.657 ns** | **0.3174 ns** |  **0.3655 ns** |  **1.00** |    **0.04** |   **2,786 B** |
| CloneWithArrayCopy       | .NET 10.0 | .NET 10.0 | 100   |  10.865 ns | 0.2658 ns |  0.2610 ns |  0.86 |    0.03 |   1,582 B |
| CloneWithBufferBlockCopy | .NET 10.0 | .NET 10.0 | 100   |  10.968 ns | 0.1378 ns |  0.1151 ns |  0.87 |    0.03 |     626 B |
| CloneWithAsSpanToArray   | .NET 10.0 | .NET 10.0 | 100   |   9.962 ns | 0.2481 ns |  0.2199 ns |  0.79 |    0.03 |     417 B |
|                          |           |           |       |            |           |            |       |         |           |
| CloneWithToArray         | .NET 9.0  | .NET 9.0  | 100   |  12.640 ns | 0.3034 ns |  0.3247 ns |  1.00 |    0.04 |   2,786 B |
| CloneWithArrayCopy       | .NET 9.0  | .NET 9.0  | 100   |  10.784 ns | 0.1761 ns |  0.1647 ns |  0.85 |    0.02 |   1,582 B |
| CloneWithBufferBlockCopy | .NET 9.0  | .NET 9.0  | 100   |  10.870 ns | 0.1568 ns |  0.1309 ns |  0.86 |    0.02 |     626 B |
| CloneWithAsSpanToArray   | .NET 9.0  | .NET 9.0  | 100   |   9.873 ns | 0.1776 ns |  0.1574 ns |  0.78 |    0.02 |     417 B |
|                          |           |           |       |            |           |            |       |         |           |
| **CloneWithToArray**         | **.NET 10.0** | **.NET 10.0** | **10000** | **457.532 ns** | **8.9050 ns** | **11.5790 ns** |  **1.00** |    **0.04** |   **2,797 B** |
| CloneWithArrayCopy       | .NET 10.0 | .NET 10.0 | 10000 | 448.907 ns | 8.8351 ns | 13.2239 ns |  0.98 |    0.04 |   1,634 B |
| CloneWithBufferBlockCopy | .NET 10.0 | .NET 10.0 | 10000 | 439.639 ns | 5.8609 ns |  5.4823 ns |  0.96 |    0.03 |     637 B |
| CloneWithAsSpanToArray   | .NET 10.0 | .NET 10.0 | 10000 | 446.830 ns | 8.7797 ns | 10.7822 ns |  0.98 |    0.03 |     428 B |
|                          |           |           |       |            |           |            |       |         |           |
| CloneWithToArray         | .NET 9.0  | .NET 9.0  | 10000 | 455.569 ns | 8.9782 ns |  9.2199 ns |  1.00 |    0.03 |   2,797 B |
| CloneWithArrayCopy       | .NET 9.0  | .NET 9.0  | 10000 | 410.105 ns | 8.1679 ns | 17.5822 ns |  0.90 |    0.04 |   1,634 B |
| CloneWithBufferBlockCopy | .NET 9.0  | .NET 9.0  | 10000 | 446.289 ns | 8.5795 ns | 10.5364 ns |  0.98 |    0.03 |     637 B |
| CloneWithAsSpanToArray   | .NET 9.0  | .NET 9.0  | 10000 | 404.815 ns | 8.1057 ns | 11.8812 ns |  0.89 |    0.03 |     428 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithToArray()
       push      r15
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       rcx,rbx
       test      rcx,rcx
       je        short M00_L00
       mov       rdx,offset MT_System.Byte[]
       cmp       [rcx],rdx
       jne       near ptr M00_L16
       xor       ecx,ecx
M00_L00:
       test      rcx,rcx
       jne       near ptr M00_L17
       test      rbx,rbx
       je        near ptr M00_L23
       mov       edx,[rbx+8]
       test      edx,edx
       je        near ptr M00_L22
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       edi,[rbx+8]
       mov       rbp,[rbx]
       mov       rax,rbp
       cmp       rax,[rsi]
       je        short M00_L03
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       eax,1
       test      ecx,ecx
       cmove     ecx,eax
       mov       rax,[rsi]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       edx,1
       test      eax,eax
       cmove     eax,edx
       cmp       ecx,eax
       jne       near ptr M00_L18
M00_L01:
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L04
       xor       r14d,r14d
M00_L02:
       test      r14d,r14d
       jle       short M00_L05
       mov       ecx,167
       mov       rdx,7FFAB1D64000
       call      qword ptr [7FFAB20A7738]
       mov       r8,rax
       mov       edx,r14d
       xor       ecx,ecx
       call      qword ptr [7FFAB22D7EA0]
       int       3
M00_L03:
       cmp       dword ptr [rax+4],18
       jne       short M00_L01
       cmp       edi,[rbx+8]
       ja        short M00_L01
       cmp       edi,[rsi+8]
       ja        short M00_L01
       mov       r8d,edi
       movzx     ecx,word ptr [rax]
       imul      r8,rcx
       lea       rdx,[rbx+10]
       lea       rcx,[rsi+10]
       test      dword ptr [rax],1000000
       je        near ptr M00_L15
       call      qword ptr [7FFAB1E257A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L04:
       movsxd    rcx,ecx
       mov       r14d,[rbx+rcx*4+10]
       jmp       short M00_L02
M00_L05:
       neg       r14d
       js        near ptr M00_L19
       lea       ecx,[r14+rdi]
       cmp       ecx,[rbx+8]
       ja        near ptr M00_L19
       mov       rcx,[rsi]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L07
       xor       r15d,r15d
M00_L06:
       test      r15d,r15d
       jle       short M00_L08
       mov       ecx,17F
       mov       rdx,7FFAB1D64000
       call      qword ptr [7FFAB20A7738]
       mov       r8,rax
       mov       edx,r15d
       xor       ecx,ecx
       call      qword ptr [7FFAB22D7EA0]
       int       3
M00_L07:
       movsxd    rcx,ecx
       mov       r15d,[rsi+rcx*4+10]
       jmp       short M00_L06
M00_L08:
       neg       r15d
       js        near ptr M00_L20
       lea       ecx,[r15+rdi]
       cmp       ecx,[rsi+8]
       ja        near ptr M00_L20
       cmp       rbp,[rsi]
       je        short M00_L11
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFAB22D7F48]; System.Array.CanAssignArrayType(System.Array, System.Array)
       test      eax,eax
       je        short M00_L11
       mov       [rsp+20],edi
       mov       [rsp+28],eax
       mov       rcx,rbx
       mov       edx,r14d
       mov       r8,rsi
       mov       r9d,r15d
       call      qword ptr [7FFAB22D7F60]
M00_L09:
       mov       rax,rsi
M00_L10:
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M00_L11:
       movzx     ecx,word ptr [rbp]
       mov       r8d,edi
       imul      r8,rcx
       mov       edx,r14d
       imul      rdx,rcx
       lea       rdx,[rbx+rdx+10]
       mov       eax,r15d
       imul      rcx,rax
       lea       rcx,[rsi+rcx+10]
       test      dword ptr [rbp],1000000
       jne       short M00_L13
       cmp       r8,14
       je        short M00_L12
       call      qword ptr [7FFAB1E25818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L09
M00_L12:
       vmovdqu   xmm0,xmmword ptr [rdx]
       vmovdqu   xmm1,xmmword ptr [rdx+4]
       vmovdqu   xmmword ptr [rcx],xmm0
       vmovdqu   xmmword ptr [rcx+4],xmm1
       jmp       short M00_L09
M00_L13:
       cmp       r8,4000
       jbe       short M00_L14
       call      qword ptr [7FFAB22D7E28]
       jmp       short M00_L09
M00_L14:
       call      00007FFB11A05D60
       cmp       dword ptr [7FFB11D6F778],0
       je        short M00_L09
       jmp       near ptr M00_L21
M00_L15:
       call      qword ptr [7FFAB1E25818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L16:
       mov       rdx,rbx
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.Byte>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rcx,rax
       jmp       near ptr M00_L00
M00_L17:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [rax+30]
M00_L18:
       mov       rcx,offset MT_System.RankException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22D7EE8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB22D7F00]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L19:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       call      qword ptr [7FFAB22D7F18]
       mov       rbx,rax
       mov       ecx,12D
       mov       rdx,7FFAB1D64000
       call      qword ptr [7FFAB20A7738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rsi
       call      qword ptr [7FFAB21F5860]
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
M00_L20:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       call      qword ptr [7FFAB22D7F30]
       mov       rbx,rax
       mov       ecx,145
       mov       rdx,7FFAB1D64000
       call      qword ptr [7FFAB20A7738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rdi
       call      qword ptr [7FFAB21F5860]
       mov       rcx,rdi
       call      CORINFO_HELP_THROW
       int       3
M00_L21:
       call      CORINFO_HELP_POLL_GC
       jmp       near ptr M00_L09
M00_L22:
       mov       rax,1F14A4762A0
       jmp       near ptr M00_L10
M00_L23:
       xor       ecx,ecx
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [7FFAB22D5968]
; Total bytes of code 866
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Array.CanAssignArrayType(System.Array, System.Array)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       rcx,[rax+30]
       mov       rbx,rcx
       mov       rax,[rdx]
       mov       rsi,[rax+30]
       mov       rdi,rsi
       cmp       rbx,rdi
       je        near ptr M02_L32
       mov       eax,ecx
       and       eax,2
       mov       edx,esi
       and       edx,2
       or        eax,edx
       jne       near ptr M02_L28
       mov       rbp,rbx
       mov       r14,rdi
       mov       eax,[rcx]
       and       eax,0C0000
       cmp       eax,40000
       je        near ptr M02_L04
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L05
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rbx
       mov       rax,rdi
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L00:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       near ptr M02_L15
       mov       r9,rdi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L15
       cmp       r10d,[rax]
       jne       near ptr M02_L39
M02_L01:
       test      r9d,r9d
       je        near ptr M02_L16
       cmp       r9d,1
       je        short M02_L02
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L16
M02_L02:
       mov       eax,4
       jmp       near ptr M02_L14
M02_L03:
       test      r10d,r10d
       je        near ptr M02_L40
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L17
       jmp       near ptr M02_L40
M02_L04:
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L23
M02_L05:
       mov       eax,[rcx]
       and       eax,0E0000
       cmp       eax,60000
       jne       short M02_L06
       mov       eax,[rsi]
       and       eax,0E0000
       cmp       eax,60000
       je        near ptr M02_L20
M02_L06:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbp
       rol       r8,20
       xor       r8,r14
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L07:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbp
       jne       near ptr M02_L34
       mov       r9,r14
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L34
       cmp       r10d,[rax]
       jne       near ptr M02_L41
M02_L08:
       test      r9d,r9d
       je        short M02_L09
       cmp       r9d,1
       je        near ptr M02_L32
       mov       rcx,rbp
       mov       rdx,r14
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L32
M02_L09:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,r14
       mov       rax,rbp
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L10:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,r14
       jne       near ptr M02_L35
       mov       r9,rbp
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L35
       cmp       r10d,[rax]
       jne       near ptr M02_L42
M02_L11:
       test      r9d,r9d
       je        short M02_L12
       cmp       r9d,1
       je        short M02_L13
       mov       rcx,r14
       mov       rdx,rbp
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       short M02_L13
M02_L12:
       mov       ecx,[r14]
       and       ecx,0F0000
       cmp       ecx,0C0000
       je        short M02_L13
       mov       ecx,[rbp]
       and       ecx,0F0000
       cmp       ecx,0C0000
       jne       near ptr M02_L19
M02_L13:
       mov       eax,2
M02_L14:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L15:
       test      r10d,r10d
       je        near ptr M02_L39
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L00
       jmp       near ptr M02_L39
M02_L16:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rdi
       mov       rax,rbx
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L17:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rdi
       jne       near ptr M02_L03
       mov       r9,rbx
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L03
       cmp       r10d,[rax]
       jne       near ptr M02_L40
M02_L18:
       test      r9d,r9d
       je        short M02_L19
       cmp       r9d,1
       je        near ptr M02_L02
       mov       rcx,rdi
       mov       rdx,rbx
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L02
M02_L19:
       mov       eax,1
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L20:
       call      qword ptr [7FFB0F303EF0]
       mov       ebx,eax
       mov       rcx,rsi
       call      qword ptr [7FFB0F303EF0]
       mov       esi,eax
       mov       ecx,ebx
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       mov       edi,eax
       mov       ecx,esi
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       cmp       edi,eax
       je        near ptr M02_L32
       cmp       ebx,0E
       jge       short M02_L21
       cmp       ebx,0E
       jae       near ptr M02_L43
       mov       eax,ebx
       lea       rcx,[7FFB0E678348]
       movsx     rax,word ptr [rcx+rax*2]
       bt        eax,esi
       jae       short M02_L19
       jmp       short M02_L22
M02_L21:
       cmp       ebx,esi
       jne       short M02_L19
M02_L22:
       mov       eax,5
       jmp       near ptr M02_L14
M02_L23:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rsi
       add       rdx,10
       mov       rax,rbx
       rol       rax,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L24:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L27
       mov       r9,rsi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        short M02_L27
       cmp       r10d,[rax]
       jne       near ptr M02_L38
M02_L25:
       test      r9d,r9d
       je        near ptr M02_L19
       cmp       r9d,1
       je        short M02_L26
       mov       rcx,rbx
       mov       rdx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L26:
       mov       eax,3
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L27:
       test      r10d,r10d
       je        near ptr M02_L38
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L24
       jmp       near ptr M02_L38
M02_L28:
       mov       rdi,rsi
       test      cl,2
       jne       short M02_L29
       test      sil,2
       jne       near ptr M02_L36
M02_L29:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbx
       rol       r8,20
       xor       r8,rdi
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L30:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L33
       mov       rsi,rdi
       xor       rsi,[rax+10]
       cmp       rsi,1
       ja        short M02_L33
       cmp       r10d,[rax]
       jne       near ptr M02_L37
M02_L31:
       test      esi,esi
       je        near ptr M02_L19
       cmp       esi,1
       je        short M02_L32
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L32:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L33:
       test      r10d,r10d
       je        short M02_L37
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        short M02_L30
       jmp       short M02_L37
M02_L34:
       test      r10d,r10d
       je        short M02_L41
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L07
       jmp       short M02_L41
M02_L35:
       test      r10d,r10d
       je        short M02_L42
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L10
       jmp       short M02_L42
M02_L36:
       xor       esi,esi
       jmp       short M02_L31
M02_L37:
       mov       esi,2
       jmp       near ptr M02_L31
M02_L38:
       mov       r9d,2
       jmp       near ptr M02_L25
M02_L39:
       mov       r9d,2
       jmp       near ptr M02_L01
M02_L40:
       mov       r9d,2
       jmp       near ptr M02_L18
M02_L41:
       mov       r9d,2
       jmp       near ptr M02_L08
M02_L42:
       mov       r9d,2
       jmp       near ptr M02_L11
M02_L43:
       call      qword ptr [7FFB0F2E7FC0]
       int       3
; Total bytes of code 1451
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M03_L09
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M03_L09
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       ja        short M03_L01
       test      r8b,18
       je        short M03_L03
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rax-8]
       mov       [r10-8],rdx
M03_L00:
       vzeroupper
       ret
M03_L01:
       cmp       r8,40
       ja        short M03_L05
M03_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M03_L08
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M03_L08
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M03_L08
M03_L03:
       test      r8b,4
       je        short M03_L04
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M03_L00
M03_L04:
       test      r8,r8
       je        short M03_L00
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M03_L00
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M03_L00
M03_L05:
       cmp       r8,800
       ja        near ptr M03_L10
       cmp       r8,100
       jb        short M03_L06
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M03_L06:
       mov       r9,r8
       shr       r9,6
M03_L07:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M03_L07
       and       r8,3F
       cmp       r8,10
       ja        near ptr M03_L02
M03_L08:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M03_L00
M03_L09:
       cmp       rcx,rdx
       jne       short M03_L10
       cmp       [rdx],dl
       jmp       near ptr M03_L00
M03_L10:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E266E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 332
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       test      rdx,rdx
       je        short M04_L02
       mov       rax,[rdx]
       cmp       rax,rcx
       je        short M04_L02
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
M04_L00:
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       jne       short M04_L03
M04_L01:
       xor       edx,edx
M04_L02:
       mov       rax,rdx
       ret
M04_L03:
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       jmp       short M04_L00
; Total bytes of code 86
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithArrayCopy()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       rdi,rbx
       mov       ebx,[rbx+8]
       test      rdi,rdi
       je        near ptr M00_L12
       mov       rcx,[rdi]
       cmp       rcx,[rsi]
       jne       near ptr M00_L13
       cmp       dword ptr [rcx+4],18
       jne       near ptr M00_L13
       cmp       ebx,[rdi+8]
       ja        near ptr M00_L13
       cmp       ebx,[rsi+8]
       ja        near ptr M00_L13
       mov       r8d,ebx
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rdi+10]
       lea       rax,[rsi+10]
       test      dword ptr [rcx],1000000
       jne       short M00_L01
       mov       rcx,rax
       mov       r10,rdx
       mov       r9,r8
       mov       r11,rcx
       sub       r11,r10
       cmp       r11,r9
       jb        near ptr M00_L10
       mov       r11,r10
       sub       r11,rcx
       cmp       r11,r9
       jb        near ptr M00_L10
       lea       r11,[r10+r9]
       lea       rdi,[rcx+r9]
       cmp       r9,10
       ja        short M00_L02
       test      r8b,18
       je        short M00_L04
       mov       r8,[rdx]
       mov       [rax],r8
       mov       rdx,[r11-8]
       mov       [rdi-8],rdx
M00_L00:
       mov       rax,rsi
       vzeroupper
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L01:
       mov       rcx,rax
       call      qword ptr [7FFAB1E357A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L00
M00_L02:
       cmp       r9,40
       ja        short M00_L06
M00_L03:
       vmovups   xmm0,[r10]
       vmovups   [rcx],xmm0
       cmp       r9,20
       jbe       near ptr M00_L09
       vmovups   xmm0,[r10+10]
       vmovups   [rcx+10],xmm0
       cmp       r9,30
       jbe       near ptr M00_L09
       vmovups   xmm0,[r10+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M00_L09
M00_L04:
       test      r8b,4
       je        short M00_L05
       mov       r9d,[rdx]
       mov       [rax],r9d
       mov       eax,[r11-4]
       mov       [rdi-4],eax
       jmp       short M00_L00
M00_L05:
       test      r8,r8
       je        short M00_L00
       movzx     edx,byte ptr [rdx]
       mov       [rax],dl
       test      r8b,2
       je        short M00_L00
       movsx     rax,word ptr [r11-2]
       mov       [rdi-2],ax
       jmp       near ptr M00_L00
M00_L06:
       cmp       r9,800
       ja        near ptr M00_L11
       cmp       r9,100
       jb        short M00_L07
       mov       r10,rax
       and       r10,3F
       mov       r9,r10
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rax],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rax+20],ymm0
       lea       r10,[rdx+r9]
       lea       rcx,[rax+r9]
       sub       r8,r9
       mov       r9,r8
M00_L07:
       mov       rax,r9
       shr       rax,6
M00_L08:
       vmovdqu   ymm0,ymmword ptr [r10]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [r10+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       r10,40
       dec       rax
       jne       short M00_L08
       and       r9,3F
       cmp       r9,10
       ja        near ptr M00_L03
M00_L09:
       vmovups   xmm0,[r11-10]
       vmovups   [rdi-10],xmm0
       jmp       near ptr M00_L00
M00_L10:
       cmp       rax,rdx
       je        near ptr M00_L00
M00_L11:
       cmp       [rax],al
       mov       rcx,rax
       call      qword ptr [7FFAB1E366E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L00
M00_L12:
       xor       ebp,ebp
       jmp       short M00_L14
M00_L13:
       mov       rcx,rdi
       xor       edx,edx
       call      qword ptr [7FFAB22E7C30]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
M00_L14:
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFAB22E7C30]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],ebx
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rdi
       mov       edx,ebp
       mov       r8,rsi
       call      qword ptr [7FFAB22E7C00]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       jmp       near ptr M00_L00
; Total bytes of code 552
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,0A8
       lea       rbp,[rsp+0E0]
       mov       [rbp-40],rcx
       mov       [rbp-48],rdx
       mov       [rbp-0A8],rcx
       mov       [rbp-0B0],rdx
       mov       [rbp-0B8],r8
       lea       rcx,[rbp-0A0]
       call      qword ptr [7FFB0F2E8018]; CORINFO_HELP_JIT_PINVOKE_BEGIN
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rbp-0A8]
       mov       rdx,[rbp-0B0]
       mov       r8,[rbp-0B8]
       call      qword ptr [rax]
       lea       rcx,[rbp-0A0]
       call      qword ptr [7FFB0F2E8020]; CORINFO_HELP_JIT_PINVOKE_END
       xor       eax,eax
       mov       [rbp-48],rax
       mov       [rbp-40],rax
       add       rsp,0A8
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
; Total bytes of code 142
```
```assembly
; System.Array.GetLowerBound(Int32)
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       r8d,eax
       or        r8d,edx
       je        short M03_L00
       cmp       edx,eax
       jae       short M03_L01
       add       eax,edx
       cdqe
       mov       eax,[rcx+rax*4+10]
       add       rsp,20
       pop       rbx
       ret
M03_L00:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M03_L01:
       call      qword ptr [7FFB0F2F2710]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD950]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC0E0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 88
```
```assembly
; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       test      rbx,rbx
       je        near ptr M04_L07
       test      rsi,rsi
       je        near ptr M04_L06
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L00
       mov       rcx,[rbx]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       edx,1
       test      ecx,ecx
       cmove     ecx,edx
       mov       rdx,[rsi]
       mov       edx,[rdx+4]
       add       edx,0FFFFFFE8
       shr       edx,3
       mov       eax,1
       test      edx,edx
       cmove     edx,eax
       cmp       ecx,edx
       jne       near ptr M04_L08
M04_L00:
       mov       r14d,[rsp+70]
       test      r14d,r14d
       jl        near ptr M04_L09
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       edi,eax
       jge       short M04_L01
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,edi
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L01:
       sub       edi,eax
       js        near ptr M04_L10
       lea       ecx,[rdi+r14]
       cmp       ecx,[rbx+8]
       ja        near ptr M04_L10
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       ebp,eax
       jge       short M04_L02
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,ebp
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L02:
       sub       ebp,eax
       js        near ptr M04_L11
       lea       ecx,[r14+rbp]
       cmp       ecx,[rsi+8]
       ja        near ptr M04_L11
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L03
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFB0F2F9320]
       test      eax,eax
       je        short M04_L03
       cmp       byte ptr [rsp+78],0
       jne       near ptr M04_L16
       mov       [rsp+70],r14d
       mov       [rsp+78],eax
       mov       rcx,rbx
       mov       edx,edi
       mov       r8,rsi
       mov       r9d,ebp
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L03:
       mov       rcx,[rbx]
       movzx     edx,word ptr [rcx]
       mov       r8d,r14d
       imul      r8,rdx
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       mov       r10d,edi
       imul      r10,rdx
       add       r10,rax
       lea       rax,[rsi+8]
       mov       r9,[rsi]
       mov       r9d,[r9+4]
       add       r9,0FFFFFFFFFFFFFFF0
       add       rax,r9
       mov       r9d,ebp
       imul      rdx,r9
       add       rdx,rax
       test      dword ptr [rcx],1000000
       jne       short M04_L04
       cmp       r8,14
       jne       near ptr M04_L15
       jmp       near ptr M04_L14
M04_L04:
       cmp       r8,4000
       ja        near ptr M04_L13
       jmp       near ptr M04_L12
M04_L05:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M04_L06:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L07:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L08:
       call      qword ptr [7FFB0F2F2830]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FDDB8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC818]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L09:
       mov       rdx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rdx,[rdx]
       mov       ecx,r14d
       call      qword ptr [7FFB0F3109B0]
       int       3
M04_L10:
       call      qword ptr [7FFB0F2F25F8]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FCC70]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L11:
       call      qword ptr [7FFB0F2F25F8]
       mov       r14,rax
       call      qword ptr [7FFB0F2FCC68]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,r14
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,r14
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L12:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       je        near ptr M04_L05
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       near ptr M04_L05
M04_L13:
       mov       rcx,rdx
       mov       rdx,r10
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L14:
       movups    xmm0,[r10]
       movups    xmm1,[r10+4]
       movups    [rdx],xmm0
       movups    [rdx+4],xmm1
       jmp       near ptr M04_L05
M04_L15:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2FC988]; Precode of System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M04_L05
M04_L16:
       call      qword ptr [7FFB0F2F2620]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD738]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB2A0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 748
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rsi,offset MT_System.Byte[]
       mov       rcx,rsi
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rbp,rbx
       mov       ebx,[rbx+8]
       test      rbp,rbp
       je        short M00_L02
       mov       r14d,[rbp+8]
       cmp       [rbp],rsi
       jne       short M00_L03
M00_L00:
       mov       rdx,r14
       cmp       rbp,rdi
       je        short M00_L01
       mov       edx,[rdi+8]
M00_L01:
       mov       r8d,ebx
       cmp       r14,r8
       jb        near ptr M00_L05
       cmp       rdx,r8
       jb        near ptr M00_L05
       lea       rcx,[rdi+10]
       lea       rdx,[rbp+10]
       call      qword ptr [7FFAB1E25818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L02:
       mov       ecx,257
       mov       rdx,7FFAB1D64000
       call      qword ptr [7FFAB20A7738]
       mov       rcx,rax
       call      qword ptr [7FFAB22D7C18]
       int       3
M00_L03:
       mov       rcx,rbp
       call      00007FFB119D9B60
       mov       edx,3003FFC
       bt        edx,eax
       jb        short M00_L04
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22D7C30]
       mov       rsi,rax
       mov       ecx,257
       mov       rdx,7FFAB1D64000
       call      qword ptr [7FFAB20A7738]
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbx
       call      qword ptr [7FFAB21F5860]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L04:
       mov       rdx,[rbp]
       movzx     edx,word ptr [rdx]
       imul      r14,rdx
       jmp       near ptr M00_L00
M00_L05:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22D7C48]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB20AF9A8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 301
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L09
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L09
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       ja        short M01_L01
       test      r8b,18
       je        short M01_L03
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rax-8]
       mov       [r10-8],rdx
M01_L00:
       vzeroupper
       ret
M01_L01:
       cmp       r8,40
       ja        short M01_L05
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L08
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L08
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L08
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L00
M01_L04:
       test      r8,r8
       je        short M01_L00
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L00
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L00
M01_L05:
       cmp       r8,800
       ja        near ptr M01_L10
       cmp       r8,100
       jb        short M01_L06
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L06:
       mov       r9,r8
       shr       r9,6
M01_L07:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L07
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L02
M01_L08:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L00
M01_L09:
       cmp       rcx,rdx
       jne       short M01_L10
       cmp       [rdx],dl
       jmp       near ptr M01_L00
M01_L10:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E266E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 332
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       mov       edx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       r8d,esi
       lea       rcx,[rdi+10]
       mov       rdx,rbx
       call      qword ptr [7FFAB1E15818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,2A90FEB62A0
       jmp       short M00_L01
; Total bytes of code 92
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L09
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L09
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       ja        short M01_L01
       test      r8b,18
       je        short M01_L03
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rax-8]
       mov       [r10-8],rdx
M01_L00:
       vzeroupper
       ret
M01_L01:
       cmp       r8,40
       ja        short M01_L05
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L08
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L08
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L08
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L00
M01_L04:
       test      r8,r8
       je        short M01_L00
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L00
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L00
M01_L05:
       cmp       r8,800
       ja        near ptr M01_L10
       cmp       r8,100
       jb        short M01_L06
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L06:
       mov       r9,r8
       shr       r9,6
M01_L07:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L07
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L02
M01_L08:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L00
M01_L09:
       cmp       rcx,rdx
       jne       short M01_L10
       cmp       [rdx],dl
       jmp       near ptr M01_L00
M01_L10:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E166E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 332
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithToArray()
       push      r15
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       rcx,rbx
       test      rcx,rcx
       je        short M00_L00
       mov       rdx,offset MT_System.Byte[]
       cmp       [rcx],rdx
       jne       near ptr M00_L16
       xor       ecx,ecx
M00_L00:
       test      rcx,rcx
       jne       near ptr M00_L17
       test      rbx,rbx
       je        near ptr M00_L23
       mov       edx,[rbx+8]
       test      edx,edx
       je        near ptr M00_L22
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       edi,[rbx+8]
       mov       rbp,[rbx]
       mov       rax,rbp
       cmp       rax,[rsi]
       je        short M00_L03
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       eax,1
       test      ecx,ecx
       cmove     ecx,eax
       mov       rax,[rsi]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       edx,1
       test      eax,eax
       cmove     eax,edx
       cmp       ecx,eax
       jne       near ptr M00_L18
M00_L01:
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L04
       xor       r14d,r14d
M00_L02:
       test      r14d,r14d
       jle       short M00_L05
       mov       ecx,167
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       edx,r14d
       xor       ecx,ecx
       call      qword ptr [7FFAB22B7EA0]
       int       3
M00_L03:
       cmp       dword ptr [rax+4],18
       jne       short M00_L01
       cmp       edi,[rbx+8]
       ja        short M00_L01
       cmp       edi,[rsi+8]
       ja        short M00_L01
       mov       r8d,edi
       movzx     ecx,word ptr [rax]
       imul      r8,rcx
       lea       rdx,[rbx+10]
       lea       rcx,[rsi+10]
       test      dword ptr [rax],1000000
       je        near ptr M00_L15
       call      qword ptr [7FFAB1E057A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L04:
       movsxd    rcx,ecx
       mov       r14d,[rbx+rcx*4+10]
       jmp       short M00_L02
M00_L05:
       neg       r14d
       js        near ptr M00_L19
       lea       ecx,[r14+rdi]
       cmp       ecx,[rbx+8]
       ja        near ptr M00_L19
       mov       rcx,[rsi]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L07
       xor       r15d,r15d
M00_L06:
       test      r15d,r15d
       jle       short M00_L08
       mov       ecx,17F
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       edx,r15d
       xor       ecx,ecx
       call      qword ptr [7FFAB22B7EA0]
       int       3
M00_L07:
       movsxd    rcx,ecx
       mov       r15d,[rsi+rcx*4+10]
       jmp       short M00_L06
M00_L08:
       neg       r15d
       js        near ptr M00_L20
       lea       ecx,[r15+rdi]
       cmp       ecx,[rsi+8]
       ja        near ptr M00_L20
       cmp       rbp,[rsi]
       je        short M00_L11
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFAB22B7F48]; System.Array.CanAssignArrayType(System.Array, System.Array)
       test      eax,eax
       je        short M00_L11
       mov       [rsp+20],edi
       mov       [rsp+28],eax
       mov       rcx,rbx
       mov       edx,r14d
       mov       r8,rsi
       mov       r9d,r15d
       call      qword ptr [7FFAB22B7F60]
M00_L09:
       mov       rax,rsi
M00_L10:
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M00_L11:
       movzx     ecx,word ptr [rbp]
       mov       r8d,edi
       imul      r8,rcx
       mov       edx,r14d
       imul      rdx,rcx
       lea       rdx,[rbx+rdx+10]
       mov       eax,r15d
       imul      rcx,rax
       lea       rcx,[rsi+rcx+10]
       test      dword ptr [rbp],1000000
       jne       short M00_L13
       cmp       r8,14
       je        short M00_L12
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L09
M00_L12:
       vmovdqu   xmm0,xmmword ptr [rdx]
       vmovdqu   xmm1,xmmword ptr [rdx+4]
       vmovdqu   xmmword ptr [rcx],xmm0
       vmovdqu   xmmword ptr [rcx+4],xmm1
       jmp       short M00_L09
M00_L13:
       cmp       r8,4000
       jbe       short M00_L14
       call      qword ptr [7FFAB22B7E28]
       jmp       short M00_L09
M00_L14:
       call      00007FFB11A05D60
       cmp       dword ptr [7FFB11D6F778],0
       je        short M00_L09
       jmp       near ptr M00_L21
M00_L15:
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L16:
       mov       rdx,rbx
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.Byte>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rcx,rax
       jmp       near ptr M00_L00
M00_L17:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [rax+30]
M00_L18:
       mov       rcx,offset MT_System.RankException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22B7EE8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB22B7F00]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L19:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       call      qword ptr [7FFAB22B7F18]
       mov       rbx,rax
       mov       ecx,12D
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rsi
       call      qword ptr [7FFAB21D5860]
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
M00_L20:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       call      qword ptr [7FFAB22B7F30]
       mov       rbx,rax
       mov       ecx,145
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rdi
       call      qword ptr [7FFAB21D5860]
       mov       rcx,rdi
       call      CORINFO_HELP_THROW
       int       3
M00_L21:
       call      CORINFO_HELP_POLL_GC
       jmp       near ptr M00_L09
M00_L22:
       mov       rax,1E84B8862A0
       jmp       near ptr M00_L10
M00_L23:
       xor       ecx,ecx
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [7FFAB22B58A8]
; Total bytes of code 866
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Array.CanAssignArrayType(System.Array, System.Array)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       rcx,[rax+30]
       mov       rbx,rcx
       mov       rax,[rdx]
       mov       rsi,[rax+30]
       mov       rdi,rsi
       cmp       rbx,rdi
       je        near ptr M02_L32
       mov       eax,ecx
       and       eax,2
       mov       edx,esi
       and       edx,2
       or        eax,edx
       jne       near ptr M02_L28
       mov       rbp,rbx
       mov       r14,rdi
       mov       eax,[rcx]
       and       eax,0C0000
       cmp       eax,40000
       je        near ptr M02_L04
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L05
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rbx
       mov       rax,rdi
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L00:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       near ptr M02_L15
       mov       r9,rdi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L15
       cmp       r10d,[rax]
       jne       near ptr M02_L39
M02_L01:
       test      r9d,r9d
       je        near ptr M02_L16
       cmp       r9d,1
       je        short M02_L02
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L16
M02_L02:
       mov       eax,4
       jmp       near ptr M02_L14
M02_L03:
       test      r10d,r10d
       je        near ptr M02_L40
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L17
       jmp       near ptr M02_L40
M02_L04:
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L23
M02_L05:
       mov       eax,[rcx]
       and       eax,0E0000
       cmp       eax,60000
       jne       short M02_L06
       mov       eax,[rsi]
       and       eax,0E0000
       cmp       eax,60000
       je        near ptr M02_L20
M02_L06:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbp
       rol       r8,20
       xor       r8,r14
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L07:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbp
       jne       near ptr M02_L34
       mov       r9,r14
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L34
       cmp       r10d,[rax]
       jne       near ptr M02_L41
M02_L08:
       test      r9d,r9d
       je        short M02_L09
       cmp       r9d,1
       je        near ptr M02_L32
       mov       rcx,rbp
       mov       rdx,r14
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L32
M02_L09:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,r14
       mov       rax,rbp
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L10:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,r14
       jne       near ptr M02_L35
       mov       r9,rbp
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L35
       cmp       r10d,[rax]
       jne       near ptr M02_L42
M02_L11:
       test      r9d,r9d
       je        short M02_L12
       cmp       r9d,1
       je        short M02_L13
       mov       rcx,r14
       mov       rdx,rbp
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       short M02_L13
M02_L12:
       mov       ecx,[r14]
       and       ecx,0F0000
       cmp       ecx,0C0000
       je        short M02_L13
       mov       ecx,[rbp]
       and       ecx,0F0000
       cmp       ecx,0C0000
       jne       near ptr M02_L19
M02_L13:
       mov       eax,2
M02_L14:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L15:
       test      r10d,r10d
       je        near ptr M02_L39
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L00
       jmp       near ptr M02_L39
M02_L16:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rdi
       mov       rax,rbx
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L17:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rdi
       jne       near ptr M02_L03
       mov       r9,rbx
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L03
       cmp       r10d,[rax]
       jne       near ptr M02_L40
M02_L18:
       test      r9d,r9d
       je        short M02_L19
       cmp       r9d,1
       je        near ptr M02_L02
       mov       rcx,rdi
       mov       rdx,rbx
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L02
M02_L19:
       mov       eax,1
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L20:
       call      qword ptr [7FFB0F303EF0]
       mov       ebx,eax
       mov       rcx,rsi
       call      qword ptr [7FFB0F303EF0]
       mov       esi,eax
       mov       ecx,ebx
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       mov       edi,eax
       mov       ecx,esi
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       cmp       edi,eax
       je        near ptr M02_L32
       cmp       ebx,0E
       jge       short M02_L21
       cmp       ebx,0E
       jae       near ptr M02_L43
       mov       eax,ebx
       lea       rcx,[7FFB0E678348]
       movsx     rax,word ptr [rcx+rax*2]
       bt        eax,esi
       jae       short M02_L19
       jmp       short M02_L22
M02_L21:
       cmp       ebx,esi
       jne       short M02_L19
M02_L22:
       mov       eax,5
       jmp       near ptr M02_L14
M02_L23:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rsi
       add       rdx,10
       mov       rax,rbx
       rol       rax,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L24:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L27
       mov       r9,rsi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        short M02_L27
       cmp       r10d,[rax]
       jne       near ptr M02_L38
M02_L25:
       test      r9d,r9d
       je        near ptr M02_L19
       cmp       r9d,1
       je        short M02_L26
       mov       rcx,rbx
       mov       rdx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L26:
       mov       eax,3
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L27:
       test      r10d,r10d
       je        near ptr M02_L38
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L24
       jmp       near ptr M02_L38
M02_L28:
       mov       rdi,rsi
       test      cl,2
       jne       short M02_L29
       test      sil,2
       jne       near ptr M02_L36
M02_L29:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbx
       rol       r8,20
       xor       r8,rdi
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L30:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L33
       mov       rsi,rdi
       xor       rsi,[rax+10]
       cmp       rsi,1
       ja        short M02_L33
       cmp       r10d,[rax]
       jne       near ptr M02_L37
M02_L31:
       test      esi,esi
       je        near ptr M02_L19
       cmp       esi,1
       je        short M02_L32
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L32:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L33:
       test      r10d,r10d
       je        short M02_L37
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        short M02_L30
       jmp       short M02_L37
M02_L34:
       test      r10d,r10d
       je        short M02_L41
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L07
       jmp       short M02_L41
M02_L35:
       test      r10d,r10d
       je        short M02_L42
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L10
       jmp       short M02_L42
M02_L36:
       xor       esi,esi
       jmp       short M02_L31
M02_L37:
       mov       esi,2
       jmp       near ptr M02_L31
M02_L38:
       mov       r9d,2
       jmp       near ptr M02_L25
M02_L39:
       mov       r9d,2
       jmp       near ptr M02_L01
M02_L40:
       mov       r9d,2
       jmp       near ptr M02_L18
M02_L41:
       mov       r9d,2
       jmp       near ptr M02_L08
M02_L42:
       mov       r9d,2
       jmp       near ptr M02_L11
M02_L43:
       call      qword ptr [7FFB0F2E7FC0]
       int       3
; Total bytes of code 1451
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M03_L09
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M03_L09
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       ja        short M03_L01
       test      r8b,18
       je        short M03_L03
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rax-8]
       mov       [r10-8],rdx
M03_L00:
       vzeroupper
       ret
M03_L01:
       cmp       r8,40
       ja        short M03_L05
M03_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M03_L08
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M03_L08
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M03_L08
M03_L03:
       test      r8b,4
       je        short M03_L04
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M03_L00
M03_L04:
       test      r8,r8
       je        short M03_L00
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M03_L00
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M03_L00
M03_L05:
       cmp       r8,800
       ja        near ptr M03_L10
       cmp       r8,100
       jb        short M03_L06
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M03_L06:
       mov       r9,r8
       shr       r9,6
M03_L07:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M03_L07
       and       r8,3F
       cmp       r8,10
       ja        near ptr M03_L02
M03_L08:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M03_L00
M03_L09:
       cmp       rcx,rdx
       jne       short M03_L10
       cmp       [rdx],dl
       jmp       near ptr M03_L00
M03_L10:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E066E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 332
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       test      rdx,rdx
       je        short M04_L02
       mov       rax,[rdx]
       cmp       rax,rcx
       je        short M04_L02
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
M04_L00:
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       jne       short M04_L03
M04_L01:
       xor       edx,edx
M04_L02:
       mov       rax,rdx
       ret
M04_L03:
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       jmp       short M04_L00
; Total bytes of code 86
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithArrayCopy()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       rdi,rbx
       mov       ebx,[rbx+8]
       test      rdi,rdi
       je        near ptr M00_L12
       mov       rcx,[rdi]
       cmp       rcx,[rsi]
       jne       near ptr M00_L13
       cmp       dword ptr [rcx+4],18
       jne       near ptr M00_L13
       cmp       ebx,[rdi+8]
       ja        near ptr M00_L13
       cmp       ebx,[rsi+8]
       ja        near ptr M00_L13
       mov       r8d,ebx
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rdi+10]
       lea       rax,[rsi+10]
       test      dword ptr [rcx],1000000
       jne       short M00_L01
       mov       rcx,rax
       mov       r10,rdx
       mov       r9,r8
       mov       r11,rcx
       sub       r11,r10
       cmp       r11,r9
       jb        near ptr M00_L10
       mov       r11,r10
       sub       r11,rcx
       cmp       r11,r9
       jb        near ptr M00_L10
       lea       r11,[r10+r9]
       lea       rdi,[rcx+r9]
       cmp       r9,10
       ja        short M00_L02
       test      r8b,18
       je        short M00_L04
       mov       r8,[rdx]
       mov       [rax],r8
       mov       rdx,[r11-8]
       mov       [rdi-8],rdx
M00_L00:
       mov       rax,rsi
       vzeroupper
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L01:
       mov       rcx,rax
       call      qword ptr [7FFAB1E357A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L00
M00_L02:
       cmp       r9,40
       ja        short M00_L06
M00_L03:
       vmovups   xmm0,[r10]
       vmovups   [rcx],xmm0
       cmp       r9,20
       jbe       near ptr M00_L09
       vmovups   xmm0,[r10+10]
       vmovups   [rcx+10],xmm0
       cmp       r9,30
       jbe       near ptr M00_L09
       vmovups   xmm0,[r10+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M00_L09
M00_L04:
       test      r8b,4
       je        short M00_L05
       mov       r9d,[rdx]
       mov       [rax],r9d
       mov       eax,[r11-4]
       mov       [rdi-4],eax
       jmp       short M00_L00
M00_L05:
       test      r8,r8
       je        short M00_L00
       movzx     edx,byte ptr [rdx]
       mov       [rax],dl
       test      r8b,2
       je        short M00_L00
       movsx     rax,word ptr [r11-2]
       mov       [rdi-2],ax
       jmp       near ptr M00_L00
M00_L06:
       cmp       r9,800
       ja        near ptr M00_L11
       cmp       r9,100
       jb        short M00_L07
       mov       r10,rax
       and       r10,3F
       mov       r9,r10
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rax],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rax+20],ymm0
       lea       r10,[rdx+r9]
       lea       rcx,[rax+r9]
       sub       r8,r9
       mov       r9,r8
M00_L07:
       mov       rax,r9
       shr       rax,6
M00_L08:
       vmovdqu   ymm0,ymmword ptr [r10]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [r10+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       r10,40
       dec       rax
       jne       short M00_L08
       and       r9,3F
       cmp       r9,10
       ja        near ptr M00_L03
M00_L09:
       vmovups   xmm0,[r11-10]
       vmovups   [rdi-10],xmm0
       jmp       near ptr M00_L00
M00_L10:
       cmp       rax,rdx
       je        near ptr M00_L00
M00_L11:
       cmp       [rax],al
       mov       rcx,rax
       call      qword ptr [7FFAB1E366E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L00
M00_L12:
       xor       ebp,ebp
       jmp       short M00_L14
M00_L13:
       mov       rcx,rdi
       xor       edx,edx
       call      qword ptr [7FFAB22E7C30]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
M00_L14:
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFAB22E7C30]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],ebx
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rdi
       mov       edx,ebp
       mov       r8,rsi
       call      qword ptr [7FFAB22E7C00]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       jmp       near ptr M00_L00
; Total bytes of code 552
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,0A8
       lea       rbp,[rsp+0E0]
       mov       [rbp-40],rcx
       mov       [rbp-48],rdx
       mov       [rbp-0A8],rcx
       mov       [rbp-0B0],rdx
       mov       [rbp-0B8],r8
       lea       rcx,[rbp-0A0]
       call      qword ptr [7FFB0F2E8018]; CORINFO_HELP_JIT_PINVOKE_BEGIN
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rbp-0A8]
       mov       rdx,[rbp-0B0]
       mov       r8,[rbp-0B8]
       call      qword ptr [rax]
       lea       rcx,[rbp-0A0]
       call      qword ptr [7FFB0F2E8020]; CORINFO_HELP_JIT_PINVOKE_END
       xor       eax,eax
       mov       [rbp-48],rax
       mov       [rbp-40],rax
       add       rsp,0A8
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
; Total bytes of code 142
```
```assembly
; System.Array.GetLowerBound(Int32)
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       r8d,eax
       or        r8d,edx
       je        short M03_L00
       cmp       edx,eax
       jae       short M03_L01
       add       eax,edx
       cdqe
       mov       eax,[rcx+rax*4+10]
       add       rsp,20
       pop       rbx
       ret
M03_L00:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M03_L01:
       call      qword ptr [7FFB0F2F2710]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD950]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC0E0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 88
```
```assembly
; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       test      rbx,rbx
       je        near ptr M04_L07
       test      rsi,rsi
       je        near ptr M04_L06
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L00
       mov       rcx,[rbx]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       edx,1
       test      ecx,ecx
       cmove     ecx,edx
       mov       rdx,[rsi]
       mov       edx,[rdx+4]
       add       edx,0FFFFFFE8
       shr       edx,3
       mov       eax,1
       test      edx,edx
       cmove     edx,eax
       cmp       ecx,edx
       jne       near ptr M04_L08
M04_L00:
       mov       r14d,[rsp+70]
       test      r14d,r14d
       jl        near ptr M04_L09
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       edi,eax
       jge       short M04_L01
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,edi
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L01:
       sub       edi,eax
       js        near ptr M04_L10
       lea       ecx,[rdi+r14]
       cmp       ecx,[rbx+8]
       ja        near ptr M04_L10
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       ebp,eax
       jge       short M04_L02
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,ebp
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L02:
       sub       ebp,eax
       js        near ptr M04_L11
       lea       ecx,[r14+rbp]
       cmp       ecx,[rsi+8]
       ja        near ptr M04_L11
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L03
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFB0F2F9320]
       test      eax,eax
       je        short M04_L03
       cmp       byte ptr [rsp+78],0
       jne       near ptr M04_L16
       mov       [rsp+70],r14d
       mov       [rsp+78],eax
       mov       rcx,rbx
       mov       edx,edi
       mov       r8,rsi
       mov       r9d,ebp
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L03:
       mov       rcx,[rbx]
       movzx     edx,word ptr [rcx]
       mov       r8d,r14d
       imul      r8,rdx
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       mov       r10d,edi
       imul      r10,rdx
       add       r10,rax
       lea       rax,[rsi+8]
       mov       r9,[rsi]
       mov       r9d,[r9+4]
       add       r9,0FFFFFFFFFFFFFFF0
       add       rax,r9
       mov       r9d,ebp
       imul      rdx,r9
       add       rdx,rax
       test      dword ptr [rcx],1000000
       jne       short M04_L04
       cmp       r8,14
       jne       near ptr M04_L15
       jmp       near ptr M04_L14
M04_L04:
       cmp       r8,4000
       ja        near ptr M04_L13
       jmp       near ptr M04_L12
M04_L05:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M04_L06:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L07:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L08:
       call      qword ptr [7FFB0F2F2830]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FDDB8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC818]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L09:
       mov       rdx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rdx,[rdx]
       mov       ecx,r14d
       call      qword ptr [7FFB0F3109B0]
       int       3
M04_L10:
       call      qword ptr [7FFB0F2F25F8]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FCC70]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L11:
       call      qword ptr [7FFB0F2F25F8]
       mov       r14,rax
       call      qword ptr [7FFB0F2FCC68]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,r14
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,r14
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L12:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       je        near ptr M04_L05
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       near ptr M04_L05
M04_L13:
       mov       rcx,rdx
       mov       rdx,r10
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L14:
       movups    xmm0,[r10]
       movups    xmm1,[r10+4]
       movups    [rdx],xmm0
       movups    [rdx+4],xmm1
       jmp       near ptr M04_L05
M04_L15:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2FC988]; Precode of System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M04_L05
M04_L16:
       call      qword ptr [7FFB0F2F2620]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD738]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB2A0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 748
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rsi,offset MT_System.Byte[]
       mov       rcx,rsi
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rbp,rbx
       mov       ebx,[rbx+8]
       test      rbp,rbp
       je        short M00_L02
       mov       r14d,[rbp+8]
       cmp       [rbp],rsi
       jne       short M00_L03
M00_L00:
       mov       rdx,r14
       cmp       rbp,rdi
       je        short M00_L01
       mov       edx,[rdi+8]
M00_L01:
       mov       r8d,ebx
       cmp       r14,r8
       jb        near ptr M00_L05
       cmp       rdx,r8
       jb        near ptr M00_L05
       lea       rcx,[rdi+10]
       lea       rdx,[rbp+10]
       call      qword ptr [7FFAB1E15818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L02:
       mov       ecx,257
       mov       rdx,7FFAB1D54000
       call      qword ptr [7FFAB2097738]
       mov       rcx,rax
       call      qword ptr [7FFAB22C7C30]
       int       3
M00_L03:
       mov       rcx,rbp
       call      00007FFB119D9B60
       mov       edx,3003FFC
       bt        edx,eax
       jb        short M00_L04
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22C7C48]
       mov       rsi,rax
       mov       ecx,257
       mov       rdx,7FFAB1D54000
       call      qword ptr [7FFAB2097738]
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbx
       call      qword ptr [7FFAB21E5860]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L04:
       mov       rdx,[rbp]
       movzx     edx,word ptr [rdx]
       imul      r14,rdx
       jmp       near ptr M00_L00
M00_L05:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22C7C60]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB209F9A8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 301
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L09
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L09
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       ja        short M01_L01
       test      r8b,18
       je        short M01_L03
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rax-8]
       mov       [r10-8],rdx
M01_L00:
       vzeroupper
       ret
M01_L01:
       cmp       r8,40
       ja        short M01_L05
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L08
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L08
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L08
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L00
M01_L04:
       test      r8,r8
       je        short M01_L00
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L00
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L00
M01_L05:
       cmp       r8,800
       ja        near ptr M01_L10
       cmp       r8,100
       jb        short M01_L06
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L06:
       mov       r9,r8
       shr       r9,6
M01_L07:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L07
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L02
M01_L08:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L00
M01_L09:
       cmp       rcx,rdx
       jne       short M01_L10
       cmp       [rdx],dl
       jmp       near ptr M01_L00
M01_L10:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E166E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 332
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       mov       edx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       r8d,esi
       lea       rcx,[rdi+10]
       mov       rdx,rbx
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,128CA4762A0
       jmp       short M00_L01
; Total bytes of code 92
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L09
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L09
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       ja        short M01_L01
       test      r8b,18
       je        short M01_L03
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rax-8]
       mov       [r10-8],rdx
M01_L00:
       vzeroupper
       ret
M01_L01:
       cmp       r8,40
       ja        short M01_L05
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L08
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L08
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L08
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L00
M01_L04:
       test      r8,r8
       je        short M01_L00
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L00
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L00
M01_L05:
       cmp       r8,800
       ja        near ptr M01_L10
       cmp       r8,100
       jb        short M01_L06
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L06:
       mov       r9,r8
       shr       r9,6
M01_L07:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L07
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L02
M01_L08:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L00
M01_L09:
       cmp       rcx,rdx
       jne       short M01_L10
       cmp       [rdx],dl
       jmp       near ptr M01_L00
M01_L10:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E066E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 332
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithToArray()
       push      r15
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       rcx,rbx
       test      rcx,rcx
       je        short M00_L00
       mov       rdx,offset MT_System.Byte[]
       cmp       [rcx],rdx
       jne       near ptr M00_L16
       xor       ecx,ecx
M00_L00:
       test      rcx,rcx
       jne       near ptr M00_L17
       test      rbx,rbx
       je        near ptr M00_L23
       mov       edx,[rbx+8]
       test      edx,edx
       je        near ptr M00_L22
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       edi,[rbx+8]
       mov       rbp,[rbx]
       mov       rax,rbp
       cmp       rax,[rsi]
       je        short M00_L03
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       eax,1
       test      ecx,ecx
       cmove     ecx,eax
       mov       rax,[rsi]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       edx,1
       test      eax,eax
       cmove     eax,edx
       cmp       ecx,eax
       jne       near ptr M00_L18
M00_L01:
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L04
       xor       r14d,r14d
M00_L02:
       test      r14d,r14d
       jle       short M00_L05
       mov       ecx,167
       mov       rdx,7FFAB1D54000
       call      qword ptr [7FFAB2097738]
       mov       r8,rax
       mov       edx,r14d
       xor       ecx,ecx
       call      qword ptr [7FFAB22C7EA0]
       int       3
M00_L03:
       cmp       dword ptr [rax+4],18
       jne       short M00_L01
       cmp       edi,[rbx+8]
       ja        short M00_L01
       cmp       edi,[rsi+8]
       ja        short M00_L01
       mov       r8d,edi
       movzx     ecx,word ptr [rax]
       imul      r8,rcx
       lea       rdx,[rbx+10]
       lea       rcx,[rsi+10]
       test      dword ptr [rax],1000000
       je        near ptr M00_L15
       call      qword ptr [7FFAB1E157A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L04:
       movsxd    rcx,ecx
       mov       r14d,[rbx+rcx*4+10]
       jmp       short M00_L02
M00_L05:
       neg       r14d
       js        near ptr M00_L19
       lea       ecx,[r14+rdi]
       cmp       ecx,[rbx+8]
       ja        near ptr M00_L19
       mov       rcx,[rsi]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L07
       xor       r15d,r15d
M00_L06:
       test      r15d,r15d
       jle       short M00_L08
       mov       ecx,17F
       mov       rdx,7FFAB1D54000
       call      qword ptr [7FFAB2097738]
       mov       r8,rax
       mov       edx,r15d
       xor       ecx,ecx
       call      qword ptr [7FFAB22C7EA0]
       int       3
M00_L07:
       movsxd    rcx,ecx
       mov       r15d,[rsi+rcx*4+10]
       jmp       short M00_L06
M00_L08:
       neg       r15d
       js        near ptr M00_L20
       lea       ecx,[r15+rdi]
       cmp       ecx,[rsi+8]
       ja        near ptr M00_L20
       cmp       rbp,[rsi]
       je        short M00_L11
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFAB22C7F48]; System.Array.CanAssignArrayType(System.Array, System.Array)
       test      eax,eax
       je        short M00_L11
       mov       [rsp+20],edi
       mov       [rsp+28],eax
       mov       rcx,rbx
       mov       edx,r14d
       mov       r8,rsi
       mov       r9d,r15d
       call      qword ptr [7FFAB22C7F60]
M00_L09:
       mov       rax,rsi
M00_L10:
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M00_L11:
       movzx     ecx,word ptr [rbp]
       mov       r8d,edi
       imul      r8,rcx
       mov       edx,r14d
       imul      rdx,rcx
       lea       rdx,[rbx+rdx+10]
       mov       eax,r15d
       imul      rcx,rax
       lea       rcx,[rsi+rcx+10]
       test      dword ptr [rbp],1000000
       jne       short M00_L13
       cmp       r8,14
       je        short M00_L12
       call      qword ptr [7FFAB1E15818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L09
M00_L12:
       vmovdqu   xmm0,xmmword ptr [rdx]
       vmovdqu   xmm1,xmmword ptr [rdx+4]
       vmovdqu   xmmword ptr [rcx],xmm0
       vmovdqu   xmmword ptr [rcx+4],xmm1
       jmp       short M00_L09
M00_L13:
       cmp       r8,4000
       jbe       short M00_L14
       call      qword ptr [7FFAB22C7E28]
       jmp       short M00_L09
M00_L14:
       call      00007FFB11A05D60
       cmp       dword ptr [7FFB11D6F778],0
       je        short M00_L09
       jmp       near ptr M00_L21
M00_L15:
       call      qword ptr [7FFAB1E15818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L16:
       mov       rdx,rbx
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.Byte>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rcx,rax
       jmp       near ptr M00_L00
M00_L17:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [rax+30]
M00_L18:
       mov       rcx,offset MT_System.RankException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22C7EE8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB22C7F00]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L19:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       call      qword ptr [7FFAB22C7F18]
       mov       rbx,rax
       mov       ecx,12D
       mov       rdx,7FFAB1D54000
       call      qword ptr [7FFAB2097738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rsi
       call      qword ptr [7FFAB21E5860]
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
M00_L20:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       call      qword ptr [7FFAB22C7F30]
       mov       rbx,rax
       mov       ecx,145
       mov       rdx,7FFAB1D54000
       call      qword ptr [7FFAB2097738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rdi
       call      qword ptr [7FFAB21E5860]
       mov       rcx,rdi
       call      CORINFO_HELP_THROW
       int       3
M00_L21:
       call      CORINFO_HELP_POLL_GC
       jmp       near ptr M00_L09
M00_L22:
       mov       rax,2F6DD7E62A0
       jmp       near ptr M00_L10
M00_L23:
       xor       ecx,ecx
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [7FFAB22C5950]
; Total bytes of code 866
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Array.CanAssignArrayType(System.Array, System.Array)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       rcx,[rax+30]
       mov       rbx,rcx
       mov       rax,[rdx]
       mov       rsi,[rax+30]
       mov       rdi,rsi
       cmp       rbx,rdi
       je        near ptr M02_L32
       mov       eax,ecx
       and       eax,2
       mov       edx,esi
       and       edx,2
       or        eax,edx
       jne       near ptr M02_L28
       mov       rbp,rbx
       mov       r14,rdi
       mov       eax,[rcx]
       and       eax,0C0000
       cmp       eax,40000
       je        near ptr M02_L04
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L05
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rbx
       mov       rax,rdi
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L00:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       near ptr M02_L15
       mov       r9,rdi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L15
       cmp       r10d,[rax]
       jne       near ptr M02_L39
M02_L01:
       test      r9d,r9d
       je        near ptr M02_L16
       cmp       r9d,1
       je        short M02_L02
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L16
M02_L02:
       mov       eax,4
       jmp       near ptr M02_L14
M02_L03:
       test      r10d,r10d
       je        near ptr M02_L40
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L17
       jmp       near ptr M02_L40
M02_L04:
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L23
M02_L05:
       mov       eax,[rcx]
       and       eax,0E0000
       cmp       eax,60000
       jne       short M02_L06
       mov       eax,[rsi]
       and       eax,0E0000
       cmp       eax,60000
       je        near ptr M02_L20
M02_L06:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbp
       rol       r8,20
       xor       r8,r14
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L07:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbp
       jne       near ptr M02_L34
       mov       r9,r14
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L34
       cmp       r10d,[rax]
       jne       near ptr M02_L41
M02_L08:
       test      r9d,r9d
       je        short M02_L09
       cmp       r9d,1
       je        near ptr M02_L32
       mov       rcx,rbp
       mov       rdx,r14
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L32
M02_L09:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,r14
       mov       rax,rbp
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L10:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,r14
       jne       near ptr M02_L35
       mov       r9,rbp
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L35
       cmp       r10d,[rax]
       jne       near ptr M02_L42
M02_L11:
       test      r9d,r9d
       je        short M02_L12
       cmp       r9d,1
       je        short M02_L13
       mov       rcx,r14
       mov       rdx,rbp
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       short M02_L13
M02_L12:
       mov       ecx,[r14]
       and       ecx,0F0000
       cmp       ecx,0C0000
       je        short M02_L13
       mov       ecx,[rbp]
       and       ecx,0F0000
       cmp       ecx,0C0000
       jne       near ptr M02_L19
M02_L13:
       mov       eax,2
M02_L14:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L15:
       test      r10d,r10d
       je        near ptr M02_L39
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L00
       jmp       near ptr M02_L39
M02_L16:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rdi
       mov       rax,rbx
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L17:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rdi
       jne       near ptr M02_L03
       mov       r9,rbx
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L03
       cmp       r10d,[rax]
       jne       near ptr M02_L40
M02_L18:
       test      r9d,r9d
       je        short M02_L19
       cmp       r9d,1
       je        near ptr M02_L02
       mov       rcx,rdi
       mov       rdx,rbx
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L02
M02_L19:
       mov       eax,1
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L20:
       call      qword ptr [7FFB0F303EF0]
       mov       ebx,eax
       mov       rcx,rsi
       call      qword ptr [7FFB0F303EF0]
       mov       esi,eax
       mov       ecx,ebx
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       mov       edi,eax
       mov       ecx,esi
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       cmp       edi,eax
       je        near ptr M02_L32
       cmp       ebx,0E
       jge       short M02_L21
       cmp       ebx,0E
       jae       near ptr M02_L43
       mov       eax,ebx
       lea       rcx,[7FFB0E678348]
       movsx     rax,word ptr [rcx+rax*2]
       bt        eax,esi
       jae       short M02_L19
       jmp       short M02_L22
M02_L21:
       cmp       ebx,esi
       jne       short M02_L19
M02_L22:
       mov       eax,5
       jmp       near ptr M02_L14
M02_L23:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rsi
       add       rdx,10
       mov       rax,rbx
       rol       rax,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L24:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L27
       mov       r9,rsi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        short M02_L27
       cmp       r10d,[rax]
       jne       near ptr M02_L38
M02_L25:
       test      r9d,r9d
       je        near ptr M02_L19
       cmp       r9d,1
       je        short M02_L26
       mov       rcx,rbx
       mov       rdx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L26:
       mov       eax,3
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L27:
       test      r10d,r10d
       je        near ptr M02_L38
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L24
       jmp       near ptr M02_L38
M02_L28:
       mov       rdi,rsi
       test      cl,2
       jne       short M02_L29
       test      sil,2
       jne       near ptr M02_L36
M02_L29:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbx
       rol       r8,20
       xor       r8,rdi
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L30:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L33
       mov       rsi,rdi
       xor       rsi,[rax+10]
       cmp       rsi,1
       ja        short M02_L33
       cmp       r10d,[rax]
       jne       near ptr M02_L37
M02_L31:
       test      esi,esi
       je        near ptr M02_L19
       cmp       esi,1
       je        short M02_L32
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L32:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L33:
       test      r10d,r10d
       je        short M02_L37
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        short M02_L30
       jmp       short M02_L37
M02_L34:
       test      r10d,r10d
       je        short M02_L41
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L07
       jmp       short M02_L41
M02_L35:
       test      r10d,r10d
       je        short M02_L42
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L10
       jmp       short M02_L42
M02_L36:
       xor       esi,esi
       jmp       short M02_L31
M02_L37:
       mov       esi,2
       jmp       near ptr M02_L31
M02_L38:
       mov       r9d,2
       jmp       near ptr M02_L25
M02_L39:
       mov       r9d,2
       jmp       near ptr M02_L01
M02_L40:
       mov       r9d,2
       jmp       near ptr M02_L18
M02_L41:
       mov       r9d,2
       jmp       near ptr M02_L08
M02_L42:
       mov       r9d,2
       jmp       near ptr M02_L11
M02_L43:
       call      qword ptr [7FFB0F2E7FC0]
       int       3
; Total bytes of code 1451
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M03_L10
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M03_L10
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       near ptr M03_L06
       cmp       r8,40
       jbe       short M03_L02
       cmp       r8,800
       ja        near ptr M03_L11
       cmp       r8,100
       jae       near ptr M03_L09
M03_L00:
       mov       r9,r8
       shr       r9,6
M03_L01:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M03_L01
       and       r8,3F
       cmp       r8,10
       jbe       short M03_L03
M03_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M03_L03
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       ja        short M03_L05
M03_L03:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
M03_L04:
       vzeroupper
       ret
M03_L05:
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       short M03_L03
M03_L06:
       test      r8b,18
       je        short M03_L07
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M03_L04
M03_L07:
       test      r8b,4
       je        short M03_L08
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M03_L04
M03_L08:
       test      r8,r8
       je        short M03_L04
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M03_L04
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M03_L04
M03_L09:
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
       jmp       near ptr M03_L00
M03_L10:
       cmp       rcx,rdx
       jne       short M03_L11
       cmp       [rdx],dl
       jmp       near ptr M03_L04
M03_L11:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E166E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 325
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       test      rdx,rdx
       je        short M04_L02
       mov       rax,[rdx]
       cmp       rax,rcx
       je        short M04_L02
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
M04_L00:
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       jne       short M04_L03
M04_L01:
       xor       edx,edx
M04_L02:
       mov       rax,rdx
       ret
M04_L03:
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       jmp       short M04_L00
; Total bytes of code 86
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithArrayCopy()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       rdi,rbx
       mov       ebx,[rbx+8]
       test      rdi,rdi
       je        near ptr M00_L13
       mov       rcx,[rdi]
       cmp       rcx,[rsi]
       jne       near ptr M00_L14
       cmp       dword ptr [rcx+4],18
       jne       near ptr M00_L14
       cmp       ebx,[rdi+8]
       ja        near ptr M00_L14
       cmp       ebx,[rsi+8]
       ja        near ptr M00_L14
       mov       r8d,ebx
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rdi+10]
       lea       rax,[rsi+10]
       test      dword ptr [rcx],1000000
       jne       near ptr M00_L05
       mov       rcx,rax
       mov       r10,rdx
       mov       r9,r8
       mov       r11,rcx
       sub       r11,r10
       cmp       r11,r9
       jb        near ptr M00_L11
       mov       r11,r10
       sub       r11,rcx
       cmp       r11,r9
       jb        near ptr M00_L11
       lea       r11,[r10+r9]
       lea       rdi,[rcx+r9]
       cmp       r9,10
       jbe       near ptr M00_L07
       cmp       r9,40
       jbe       short M00_L02
       cmp       r9,800
       ja        near ptr M00_L12
       cmp       r9,100
       jae       near ptr M00_L10
M00_L00:
       mov       rdx,r9
       shr       rdx,6
M00_L01:
       vmovdqu   ymm0,ymmword ptr [r10]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [r10+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       r10,40
       dec       rdx
       jne       short M00_L01
       and       r9,3F
       cmp       r9,10
       jbe       short M00_L03
M00_L02:
       vmovups   xmm0,[r10]
       vmovups   [rcx],xmm0
       cmp       r9,20
       jbe       short M00_L03
       vmovups   xmm0,[r10+10]
       vmovups   [rcx+10],xmm0
       cmp       r9,30
       ja        short M00_L06
M00_L03:
       vmovups   xmm0,[r11-10]
       vmovups   [rdi-10],xmm0
M00_L04:
       mov       rax,rsi
       vzeroupper
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L05:
       mov       rcx,rax
       call      qword ptr [7FFAB1E157A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L04
M00_L06:
       vmovups   xmm0,[r10+20]
       vmovups   [rcx+20],xmm0
       jmp       short M00_L03
M00_L07:
       test      r8b,18
       je        short M00_L08
       mov       rdx,[rdx]
       mov       [rax],rdx
       mov       rax,[r11-8]
       mov       [rdi-8],rax
       jmp       short M00_L04
M00_L08:
       test      r8b,4
       je        short M00_L09
       mov       edx,[rdx]
       mov       [rax],edx
       mov       eax,[r11-4]
       mov       [rdi-4],eax
       jmp       short M00_L04
M00_L09:
       test      r8,r8
       je        short M00_L04
       movzx     edx,byte ptr [rdx]
       mov       [rax],dl
       test      r8b,2
       je        short M00_L04
       movsx     rax,word ptr [r11-2]
       mov       [rdi-2],ax
       jmp       short M00_L04
M00_L10:
       mov       r10,rax
       and       r10,3F
       mov       r9,r10
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rax],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rax+20],ymm0
       lea       r10,[rdx+r9]
       lea       rcx,[rax+r9]
       sub       r8,r9
       mov       r9,r8
       jmp       near ptr M00_L00
M00_L11:
       cmp       rax,rdx
       je        near ptr M00_L04
M00_L12:
       cmp       [rax],al
       mov       rcx,rax
       call      qword ptr [7FFAB1E166E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L04
M00_L13:
       xor       ebp,ebp
       jmp       short M00_L15
M00_L14:
       mov       rcx,rdi
       xor       edx,edx
       call      qword ptr [7FFAB22C7C18]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
M00_L15:
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFAB22C7C18]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],ebx
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rdi
       mov       edx,ebp
       mov       r8,rsi
       call      qword ptr [7FFAB22C7BE8]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       jmp       near ptr M00_L04
; Total bytes of code 546
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,0A8
       lea       rbp,[rsp+0E0]
       mov       [rbp-40],rcx
       mov       [rbp-48],rdx
       mov       [rbp-0A8],rcx
       mov       [rbp-0B0],rdx
       mov       [rbp-0B8],r8
       lea       rcx,[rbp-0A0]
       call      qword ptr [7FFB0F2E8018]; CORINFO_HELP_JIT_PINVOKE_BEGIN
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rbp-0A8]
       mov       rdx,[rbp-0B0]
       mov       r8,[rbp-0B8]
       call      qword ptr [rax]
       lea       rcx,[rbp-0A0]
       call      qword ptr [7FFB0F2E8020]; CORINFO_HELP_JIT_PINVOKE_END
       xor       eax,eax
       mov       [rbp-48],rax
       mov       [rbp-40],rax
       add       rsp,0A8
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
; Total bytes of code 142
```
```assembly
; System.Array.GetLowerBound(Int32)
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       r8d,eax
       or        r8d,edx
       je        short M03_L00
       cmp       edx,eax
       jae       short M03_L01
       add       eax,edx
       cdqe
       mov       eax,[rcx+rax*4+10]
       add       rsp,20
       pop       rbx
       ret
M03_L00:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M03_L01:
       call      qword ptr [7FFB0F2F2710]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD950]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC0E0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 88
```
```assembly
; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       test      rbx,rbx
       je        near ptr M04_L07
       test      rsi,rsi
       je        near ptr M04_L06
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L00
       mov       rcx,[rbx]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       edx,1
       test      ecx,ecx
       cmove     ecx,edx
       mov       rdx,[rsi]
       mov       edx,[rdx+4]
       add       edx,0FFFFFFE8
       shr       edx,3
       mov       eax,1
       test      edx,edx
       cmove     edx,eax
       cmp       ecx,edx
       jne       near ptr M04_L08
M04_L00:
       mov       r14d,[rsp+70]
       test      r14d,r14d
       jl        near ptr M04_L09
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       edi,eax
       jge       short M04_L01
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,edi
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L01:
       sub       edi,eax
       js        near ptr M04_L10
       lea       ecx,[rdi+r14]
       cmp       ecx,[rbx+8]
       ja        near ptr M04_L10
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       ebp,eax
       jge       short M04_L02
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,ebp
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L02:
       sub       ebp,eax
       js        near ptr M04_L11
       lea       ecx,[r14+rbp]
       cmp       ecx,[rsi+8]
       ja        near ptr M04_L11
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L03
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFB0F2F9320]
       test      eax,eax
       je        short M04_L03
       cmp       byte ptr [rsp+78],0
       jne       near ptr M04_L16
       mov       [rsp+70],r14d
       mov       [rsp+78],eax
       mov       rcx,rbx
       mov       edx,edi
       mov       r8,rsi
       mov       r9d,ebp
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L03:
       mov       rcx,[rbx]
       movzx     edx,word ptr [rcx]
       mov       r8d,r14d
       imul      r8,rdx
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       mov       r10d,edi
       imul      r10,rdx
       add       r10,rax
       lea       rax,[rsi+8]
       mov       r9,[rsi]
       mov       r9d,[r9+4]
       add       r9,0FFFFFFFFFFFFFFF0
       add       rax,r9
       mov       r9d,ebp
       imul      rdx,r9
       add       rdx,rax
       test      dword ptr [rcx],1000000
       jne       short M04_L04
       cmp       r8,14
       jne       near ptr M04_L15
       jmp       near ptr M04_L14
M04_L04:
       cmp       r8,4000
       ja        near ptr M04_L13
       jmp       near ptr M04_L12
M04_L05:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M04_L06:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L07:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L08:
       call      qword ptr [7FFB0F2F2830]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FDDB8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC818]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L09:
       mov       rdx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rdx,[rdx]
       mov       ecx,r14d
       call      qword ptr [7FFB0F3109B0]
       int       3
M04_L10:
       call      qword ptr [7FFB0F2F25F8]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FCC70]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L11:
       call      qword ptr [7FFB0F2F25F8]
       mov       r14,rax
       call      qword ptr [7FFB0F2FCC68]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,r14
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,r14
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L12:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       je        near ptr M04_L05
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       near ptr M04_L05
M04_L13:
       mov       rcx,rdx
       mov       rdx,r10
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L14:
       movups    xmm0,[r10]
       movups    xmm1,[r10+4]
       movups    [rdx],xmm0
       movups    [rdx+4],xmm1
       jmp       near ptr M04_L05
M04_L15:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2FC988]; Precode of System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M04_L05
M04_L16:
       call      qword ptr [7FFB0F2F2620]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD738]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB2A0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 748
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rsi,offset MT_System.Byte[]
       mov       rcx,rsi
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rbp,rbx
       mov       ebx,[rbx+8]
       test      rbp,rbp
       je        short M00_L02
       mov       r14d,[rbp+8]
       cmp       [rbp],rsi
       jne       short M00_L03
M00_L00:
       mov       rdx,r14
       cmp       rbp,rdi
       je        short M00_L01
       mov       edx,[rdi+8]
M00_L01:
       mov       r8d,ebx
       cmp       r14,r8
       jb        near ptr M00_L05
       cmp       rdx,r8
       jb        near ptr M00_L05
       lea       rcx,[rdi+10]
       lea       rdx,[rbp+10]
       call      qword ptr [7FFAB1E35818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L02:
       mov       ecx,257
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       rcx,rax
       call      qword ptr [7FFAB22E7C48]
       int       3
M00_L03:
       mov       rcx,rbp
       call      00007FFB119D9B60
       mov       edx,3003FFC
       bt        edx,eax
       jb        short M00_L04
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22E7C60]
       mov       rsi,rax
       mov       ecx,257
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbx
       call      qword ptr [7FFAB2205860]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L04:
       mov       rdx,[rbp]
       movzx     edx,word ptr [rdx]
       imul      r14,rdx
       jmp       near ptr M00_L00
M00_L05:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22E7C78]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB20BF9A8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 301
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L10
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L10
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       near ptr M01_L06
       cmp       r8,40
       jbe       short M01_L02
       cmp       r8,800
       ja        near ptr M01_L11
       cmp       r8,100
       jae       near ptr M01_L09
M01_L00:
       mov       r9,r8
       shr       r9,6
M01_L01:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L01
       and       r8,3F
       cmp       r8,10
       jbe       short M01_L03
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M01_L03
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       ja        short M01_L05
M01_L03:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
M01_L04:
       vzeroupper
       ret
M01_L05:
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       short M01_L03
M01_L06:
       test      r8b,18
       je        short M01_L07
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L04
M01_L07:
       test      r8b,4
       je        short M01_L08
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L04
M01_L08:
       test      r8,r8
       je        short M01_L04
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L04
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L04
M01_L09:
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
       jmp       near ptr M01_L00
M01_L10:
       cmp       rcx,rdx
       jne       short M01_L11
       cmp       [rdx],dl
       jmp       near ptr M01_L04
M01_L11:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E366E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 325
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       mov       edx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       r8d,esi
       lea       rcx,[rdi+10]
       mov       rdx,rbx
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,1BE724D62A0
       jmp       short M00_L01
; Total bytes of code 92
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L10
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L10
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       near ptr M01_L06
       cmp       r8,40
       jbe       short M01_L02
       cmp       r8,800
       ja        near ptr M01_L11
       cmp       r8,100
       jae       near ptr M01_L09
M01_L00:
       mov       r9,r8
       shr       r9,6
M01_L01:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L01
       and       r8,3F
       cmp       r8,10
       jbe       short M01_L03
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M01_L03
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       ja        short M01_L05
M01_L03:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
M01_L04:
       vzeroupper
       ret
M01_L05:
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       short M01_L03
M01_L06:
       test      r8b,18
       je        short M01_L07
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L04
M01_L07:
       test      r8b,4
       je        short M01_L08
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L04
M01_L08:
       test      r8,r8
       je        short M01_L04
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L04
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L04
M01_L09:
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
       jmp       near ptr M01_L00
M01_L10:
       cmp       rcx,rdx
       jne       short M01_L11
       cmp       [rdx],dl
       jmp       near ptr M01_L04
M01_L11:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E066E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 325
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithToArray()
       push      r15
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       rcx,rbx
       test      rcx,rcx
       je        short M00_L00
       mov       rdx,offset MT_System.Byte[]
       cmp       [rcx],rdx
       jne       near ptr M00_L16
       xor       ecx,ecx
M00_L00:
       test      rcx,rcx
       jne       near ptr M00_L17
       test      rbx,rbx
       je        near ptr M00_L23
       mov       edx,[rbx+8]
       test      edx,edx
       je        near ptr M00_L22
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       edi,[rbx+8]
       mov       rbp,[rbx]
       mov       rax,rbp
       cmp       rax,[rsi]
       je        short M00_L03
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       eax,1
       test      ecx,ecx
       cmove     ecx,eax
       mov       rax,[rsi]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       edx,1
       test      eax,eax
       cmove     eax,edx
       cmp       ecx,eax
       jne       near ptr M00_L18
M00_L01:
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L04
       xor       r14d,r14d
M00_L02:
       test      r14d,r14d
       jle       short M00_L05
       mov       ecx,167
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       edx,r14d
       xor       ecx,ecx
       call      qword ptr [7FFAB22B7EB8]
       int       3
M00_L03:
       cmp       dword ptr [rax+4],18
       jne       short M00_L01
       cmp       edi,[rbx+8]
       ja        short M00_L01
       cmp       edi,[rsi+8]
       ja        short M00_L01
       mov       r8d,edi
       movzx     ecx,word ptr [rax]
       imul      r8,rcx
       lea       rdx,[rbx+10]
       lea       rcx,[rsi+10]
       test      dword ptr [rax],1000000
       je        near ptr M00_L15
       call      qword ptr [7FFAB1E057A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L04:
       movsxd    rcx,ecx
       mov       r14d,[rbx+rcx*4+10]
       jmp       short M00_L02
M00_L05:
       neg       r14d
       js        near ptr M00_L19
       lea       ecx,[r14+rdi]
       cmp       ecx,[rbx+8]
       ja        near ptr M00_L19
       mov       rcx,[rsi]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L07
       xor       r15d,r15d
M00_L06:
       test      r15d,r15d
       jle       short M00_L08
       mov       ecx,17F
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       edx,r15d
       xor       ecx,ecx
       call      qword ptr [7FFAB22B7EB8]
       int       3
M00_L07:
       movsxd    rcx,ecx
       mov       r15d,[rsi+rcx*4+10]
       jmp       short M00_L06
M00_L08:
       neg       r15d
       js        near ptr M00_L20
       lea       ecx,[r15+rdi]
       cmp       ecx,[rsi+8]
       ja        near ptr M00_L20
       cmp       rbp,[rsi]
       je        short M00_L11
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFAB22B7F60]; System.Array.CanAssignArrayType(System.Array, System.Array)
       test      eax,eax
       je        short M00_L11
       mov       [rsp+20],edi
       mov       [rsp+28],eax
       mov       rcx,rbx
       mov       edx,r14d
       mov       r8,rsi
       mov       r9d,r15d
       call      qword ptr [7FFAB22B7F78]
M00_L09:
       mov       rax,rsi
M00_L10:
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M00_L11:
       movzx     ecx,word ptr [rbp]
       mov       r8d,edi
       imul      r8,rcx
       mov       edx,r14d
       imul      rdx,rcx
       lea       rdx,[rbx+rdx+10]
       mov       eax,r15d
       imul      rcx,rax
       lea       rcx,[rsi+rcx+10]
       test      dword ptr [rbp],1000000
       jne       short M00_L13
       cmp       r8,14
       je        short M00_L12
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L09
M00_L12:
       vmovdqu   xmm0,xmmword ptr [rdx]
       vmovdqu   xmm1,xmmword ptr [rdx+4]
       vmovdqu   xmmword ptr [rcx],xmm0
       vmovdqu   xmmword ptr [rcx+4],xmm1
       jmp       short M00_L09
M00_L13:
       cmp       r8,4000
       jbe       short M00_L14
       call      qword ptr [7FFAB22B7E40]
       jmp       short M00_L09
M00_L14:
       call      00007FFB11A05D60
       cmp       dword ptr [7FFB11D6F778],0
       je        short M00_L09
       jmp       near ptr M00_L21
M00_L15:
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L16:
       mov       rdx,rbx
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.Byte>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rcx,rax
       jmp       near ptr M00_L00
M00_L17:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [rax+30]
M00_L18:
       mov       rcx,offset MT_System.RankException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22B7F00]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB22B7F18]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L19:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       call      qword ptr [7FFAB22B7F30]
       mov       rbx,rax
       mov       ecx,12D
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rsi
       call      qword ptr [7FFAB21D5860]
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
M00_L20:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       call      qword ptr [7FFAB22B7F48]
       mov       rbx,rax
       mov       ecx,145
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rdi
       call      qword ptr [7FFAB21D5860]
       mov       rcx,rdi
       call      CORINFO_HELP_THROW
       int       3
M00_L21:
       call      CORINFO_HELP_POLL_GC
       jmp       near ptr M00_L09
M00_L22:
       mov       rax,20669DB62A0
       jmp       near ptr M00_L10
M00_L23:
       xor       ecx,ecx
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [7FFAB22B5980]
; Total bytes of code 866
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Array.CanAssignArrayType(System.Array, System.Array)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       rcx,[rax+30]
       mov       rbx,rcx
       mov       rax,[rdx]
       mov       rsi,[rax+30]
       mov       rdi,rsi
       cmp       rbx,rdi
       je        near ptr M02_L32
       mov       eax,ecx
       and       eax,2
       mov       edx,esi
       and       edx,2
       or        eax,edx
       jne       near ptr M02_L28
       mov       rbp,rbx
       mov       r14,rdi
       mov       eax,[rcx]
       and       eax,0C0000
       cmp       eax,40000
       je        near ptr M02_L04
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L05
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rbx
       mov       rax,rdi
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L00:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       near ptr M02_L15
       mov       r9,rdi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L15
       cmp       r10d,[rax]
       jne       near ptr M02_L39
M02_L01:
       test      r9d,r9d
       je        near ptr M02_L16
       cmp       r9d,1
       je        short M02_L02
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L16
M02_L02:
       mov       eax,4
       jmp       near ptr M02_L14
M02_L03:
       test      r10d,r10d
       je        near ptr M02_L40
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L17
       jmp       near ptr M02_L40
M02_L04:
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L23
M02_L05:
       mov       eax,[rcx]
       and       eax,0E0000
       cmp       eax,60000
       jne       short M02_L06
       mov       eax,[rsi]
       and       eax,0E0000
       cmp       eax,60000
       je        near ptr M02_L20
M02_L06:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbp
       rol       r8,20
       xor       r8,r14
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L07:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbp
       jne       near ptr M02_L34
       mov       r9,r14
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L34
       cmp       r10d,[rax]
       jne       near ptr M02_L41
M02_L08:
       test      r9d,r9d
       je        short M02_L09
       cmp       r9d,1
       je        near ptr M02_L32
       mov       rcx,rbp
       mov       rdx,r14
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L32
M02_L09:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,r14
       mov       rax,rbp
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L10:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,r14
       jne       near ptr M02_L35
       mov       r9,rbp
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L35
       cmp       r10d,[rax]
       jne       near ptr M02_L42
M02_L11:
       test      r9d,r9d
       je        short M02_L12
       cmp       r9d,1
       je        short M02_L13
       mov       rcx,r14
       mov       rdx,rbp
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       short M02_L13
M02_L12:
       mov       ecx,[r14]
       and       ecx,0F0000
       cmp       ecx,0C0000
       je        short M02_L13
       mov       ecx,[rbp]
       and       ecx,0F0000
       cmp       ecx,0C0000
       jne       near ptr M02_L19
M02_L13:
       mov       eax,2
M02_L14:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L15:
       test      r10d,r10d
       je        near ptr M02_L39
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L00
       jmp       near ptr M02_L39
M02_L16:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rdi
       mov       rax,rbx
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L17:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rdi
       jne       near ptr M02_L03
       mov       r9,rbx
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L03
       cmp       r10d,[rax]
       jne       near ptr M02_L40
M02_L18:
       test      r9d,r9d
       je        short M02_L19
       cmp       r9d,1
       je        near ptr M02_L02
       mov       rcx,rdi
       mov       rdx,rbx
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L02
M02_L19:
       mov       eax,1
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L20:
       call      qword ptr [7FFB0F303EF0]
       mov       ebx,eax
       mov       rcx,rsi
       call      qword ptr [7FFB0F303EF0]
       mov       esi,eax
       mov       ecx,ebx
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       mov       edi,eax
       mov       ecx,esi
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       cmp       edi,eax
       je        near ptr M02_L32
       cmp       ebx,0E
       jge       short M02_L21
       cmp       ebx,0E
       jae       near ptr M02_L43
       mov       eax,ebx
       lea       rcx,[7FFB0E678348]
       movsx     rax,word ptr [rcx+rax*2]
       bt        eax,esi
       jae       short M02_L19
       jmp       short M02_L22
M02_L21:
       cmp       ebx,esi
       jne       short M02_L19
M02_L22:
       mov       eax,5
       jmp       near ptr M02_L14
M02_L23:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rsi
       add       rdx,10
       mov       rax,rbx
       rol       rax,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L24:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L27
       mov       r9,rsi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        short M02_L27
       cmp       r10d,[rax]
       jne       near ptr M02_L38
M02_L25:
       test      r9d,r9d
       je        near ptr M02_L19
       cmp       r9d,1
       je        short M02_L26
       mov       rcx,rbx
       mov       rdx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L26:
       mov       eax,3
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L27:
       test      r10d,r10d
       je        near ptr M02_L38
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L24
       jmp       near ptr M02_L38
M02_L28:
       mov       rdi,rsi
       test      cl,2
       jne       short M02_L29
       test      sil,2
       jne       near ptr M02_L36
M02_L29:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbx
       rol       r8,20
       xor       r8,rdi
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L30:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L33
       mov       rsi,rdi
       xor       rsi,[rax+10]
       cmp       rsi,1
       ja        short M02_L33
       cmp       r10d,[rax]
       jne       near ptr M02_L37
M02_L31:
       test      esi,esi
       je        near ptr M02_L19
       cmp       esi,1
       je        short M02_L32
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L32:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L33:
       test      r10d,r10d
       je        short M02_L37
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        short M02_L30
       jmp       short M02_L37
M02_L34:
       test      r10d,r10d
       je        short M02_L41
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L07
       jmp       short M02_L41
M02_L35:
       test      r10d,r10d
       je        short M02_L42
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L10
       jmp       short M02_L42
M02_L36:
       xor       esi,esi
       jmp       short M02_L31
M02_L37:
       mov       esi,2
       jmp       near ptr M02_L31
M02_L38:
       mov       r9d,2
       jmp       near ptr M02_L25
M02_L39:
       mov       r9d,2
       jmp       near ptr M02_L01
M02_L40:
       mov       r9d,2
       jmp       near ptr M02_L18
M02_L41:
       mov       r9d,2
       jmp       near ptr M02_L08
M02_L42:
       mov       r9d,2
       jmp       near ptr M02_L11
M02_L43:
       call      qword ptr [7FFB0F2E7FC0]
       int       3
; Total bytes of code 1451
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M03_L10
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M03_L10
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       near ptr M03_L06
       cmp       r8,40
       jbe       short M03_L02
       cmp       r8,800
       ja        near ptr M03_L11
       cmp       r8,100
       jae       near ptr M03_L09
M03_L00:
       mov       r9,r8
       shr       r9,6
M03_L01:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M03_L01
       and       r8,3F
       cmp       r8,10
       jbe       short M03_L03
M03_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M03_L03
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       ja        short M03_L05
M03_L03:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
M03_L04:
       vzeroupper
       ret
M03_L05:
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       short M03_L03
M03_L06:
       test      r8b,18
       je        short M03_L07
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M03_L04
M03_L07:
       test      r8b,4
       je        short M03_L08
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M03_L04
M03_L08:
       test      r8,r8
       je        short M03_L04
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M03_L04
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M03_L04
M03_L09:
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
       jmp       near ptr M03_L00
M03_L10:
       cmp       rcx,rdx
       jne       short M03_L11
       cmp       [rdx],dl
       jmp       near ptr M03_L04
M03_L11:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E066E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 325
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       test      rdx,rdx
       je        short M04_L02
       mov       rax,[rdx]
       cmp       rax,rcx
       je        short M04_L02
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
M04_L00:
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       jne       short M04_L03
M04_L01:
       xor       edx,edx
M04_L02:
       mov       rax,rdx
       ret
M04_L03:
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       jmp       short M04_L00
; Total bytes of code 86
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithArrayCopy()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       rdi,rbx
       mov       ebx,[rbx+8]
       test      rdi,rdi
       je        near ptr M00_L13
       mov       rcx,[rdi]
       cmp       rcx,[rsi]
       jne       near ptr M00_L14
       cmp       dword ptr [rcx+4],18
       jne       near ptr M00_L14
       cmp       ebx,[rdi+8]
       ja        near ptr M00_L14
       cmp       ebx,[rsi+8]
       ja        near ptr M00_L14
       mov       r8d,ebx
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rdi+10]
       lea       rax,[rsi+10]
       test      dword ptr [rcx],1000000
       jne       near ptr M00_L05
       mov       rcx,rax
       mov       r10,rdx
       mov       r9,r8
       mov       r11,rcx
       sub       r11,r10
       cmp       r11,r9
       jb        near ptr M00_L11
       mov       r11,r10
       sub       r11,rcx
       cmp       r11,r9
       jb        near ptr M00_L11
       lea       r11,[r10+r9]
       lea       rdi,[rcx+r9]
       cmp       r9,10
       jbe       near ptr M00_L07
       cmp       r9,40
       jbe       short M00_L02
       cmp       r9,800
       ja        near ptr M00_L12
       cmp       r9,100
       jae       near ptr M00_L10
M00_L00:
       mov       rdx,r9
       shr       rdx,6
M00_L01:
       vmovdqu   ymm0,ymmword ptr [r10]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [r10+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       r10,40
       dec       rdx
       jne       short M00_L01
       and       r9,3F
       cmp       r9,10
       jbe       short M00_L03
M00_L02:
       vmovups   xmm0,[r10]
       vmovups   [rcx],xmm0
       cmp       r9,20
       jbe       short M00_L03
       vmovups   xmm0,[r10+10]
       vmovups   [rcx+10],xmm0
       cmp       r9,30
       ja        short M00_L06
M00_L03:
       vmovups   xmm0,[r11-10]
       vmovups   [rdi-10],xmm0
M00_L04:
       mov       rax,rsi
       vzeroupper
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L05:
       mov       rcx,rax
       call      qword ptr [7FFAB1E257A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L04
M00_L06:
       vmovups   xmm0,[r10+20]
       vmovups   [rcx+20],xmm0
       jmp       short M00_L03
M00_L07:
       test      r8b,18
       je        short M00_L08
       mov       rdx,[rdx]
       mov       [rax],rdx
       mov       rax,[r11-8]
       mov       [rdi-8],rax
       jmp       short M00_L04
M00_L08:
       test      r8b,4
       je        short M00_L09
       mov       edx,[rdx]
       mov       [rax],edx
       mov       eax,[r11-4]
       mov       [rdi-4],eax
       jmp       short M00_L04
M00_L09:
       test      r8,r8
       je        short M00_L04
       movzx     edx,byte ptr [rdx]
       mov       [rax],dl
       test      r8b,2
       je        short M00_L04
       movsx     rax,word ptr [r11-2]
       mov       [rdi-2],ax
       jmp       short M00_L04
M00_L10:
       mov       r10,rax
       and       r10,3F
       mov       r9,r10
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rax],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rax+20],ymm0
       lea       r10,[rdx+r9]
       lea       rcx,[rax+r9]
       sub       r8,r9
       mov       r9,r8
       jmp       near ptr M00_L00
M00_L11:
       cmp       rax,rdx
       je        near ptr M00_L04
M00_L12:
       cmp       [rax],al
       mov       rcx,rax
       call      qword ptr [7FFAB1E266E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L04
M00_L13:
       xor       ebp,ebp
       jmp       short M00_L15
M00_L14:
       mov       rcx,rdi
       xor       edx,edx
       call      qword ptr [7FFAB22D7C00]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
M00_L15:
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFAB22D7C00]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],ebx
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rdi
       mov       edx,ebp
       mov       r8,rsi
       call      qword ptr [7FFAB22D7BD0]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       jmp       near ptr M00_L04
; Total bytes of code 546
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,0A8
       lea       rbp,[rsp+0E0]
       mov       [rbp-40],rcx
       mov       [rbp-48],rdx
       mov       [rbp-0A8],rcx
       mov       [rbp-0B0],rdx
       mov       [rbp-0B8],r8
       lea       rcx,[rbp-0A0]
       call      qword ptr [7FFB0F2E8018]; CORINFO_HELP_JIT_PINVOKE_BEGIN
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rbp-0A8]
       mov       rdx,[rbp-0B0]
       mov       r8,[rbp-0B8]
       call      qword ptr [rax]
       lea       rcx,[rbp-0A0]
       call      qword ptr [7FFB0F2E8020]; CORINFO_HELP_JIT_PINVOKE_END
       xor       eax,eax
       mov       [rbp-48],rax
       mov       [rbp-40],rax
       add       rsp,0A8
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
; Total bytes of code 142
```
```assembly
; System.Array.GetLowerBound(Int32)
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       r8d,eax
       or        r8d,edx
       je        short M03_L00
       cmp       edx,eax
       jae       short M03_L01
       add       eax,edx
       cdqe
       mov       eax,[rcx+rax*4+10]
       add       rsp,20
       pop       rbx
       ret
M03_L00:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M03_L01:
       call      qword ptr [7FFB0F2F2710]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD950]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC0E0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 88
```
```assembly
; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       test      rbx,rbx
       je        near ptr M04_L07
       test      rsi,rsi
       je        near ptr M04_L06
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L00
       mov       rcx,[rbx]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       edx,1
       test      ecx,ecx
       cmove     ecx,edx
       mov       rdx,[rsi]
       mov       edx,[rdx+4]
       add       edx,0FFFFFFE8
       shr       edx,3
       mov       eax,1
       test      edx,edx
       cmove     edx,eax
       cmp       ecx,edx
       jne       near ptr M04_L08
M04_L00:
       mov       r14d,[rsp+70]
       test      r14d,r14d
       jl        near ptr M04_L09
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       edi,eax
       jge       short M04_L01
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,edi
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L01:
       sub       edi,eax
       js        near ptr M04_L10
       lea       ecx,[rdi+r14]
       cmp       ecx,[rbx+8]
       ja        near ptr M04_L10
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       ebp,eax
       jge       short M04_L02
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,ebp
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L02:
       sub       ebp,eax
       js        near ptr M04_L11
       lea       ecx,[r14+rbp]
       cmp       ecx,[rsi+8]
       ja        near ptr M04_L11
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L03
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFB0F2F9320]
       test      eax,eax
       je        short M04_L03
       cmp       byte ptr [rsp+78],0
       jne       near ptr M04_L16
       mov       [rsp+70],r14d
       mov       [rsp+78],eax
       mov       rcx,rbx
       mov       edx,edi
       mov       r8,rsi
       mov       r9d,ebp
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L03:
       mov       rcx,[rbx]
       movzx     edx,word ptr [rcx]
       mov       r8d,r14d
       imul      r8,rdx
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       mov       r10d,edi
       imul      r10,rdx
       add       r10,rax
       lea       rax,[rsi+8]
       mov       r9,[rsi]
       mov       r9d,[r9+4]
       add       r9,0FFFFFFFFFFFFFFF0
       add       rax,r9
       mov       r9d,ebp
       imul      rdx,r9
       add       rdx,rax
       test      dword ptr [rcx],1000000
       jne       short M04_L04
       cmp       r8,14
       jne       near ptr M04_L15
       jmp       near ptr M04_L14
M04_L04:
       cmp       r8,4000
       ja        near ptr M04_L13
       jmp       near ptr M04_L12
M04_L05:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M04_L06:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L07:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L08:
       call      qword ptr [7FFB0F2F2830]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FDDB8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC818]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L09:
       mov       rdx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rdx,[rdx]
       mov       ecx,r14d
       call      qword ptr [7FFB0F3109B0]
       int       3
M04_L10:
       call      qword ptr [7FFB0F2F25F8]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FCC70]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L11:
       call      qword ptr [7FFB0F2F25F8]
       mov       r14,rax
       call      qword ptr [7FFB0F2FCC68]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,r14
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,r14
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L12:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       je        near ptr M04_L05
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       near ptr M04_L05
M04_L13:
       mov       rcx,rdx
       mov       rdx,r10
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L14:
       movups    xmm0,[r10]
       movups    xmm1,[r10+4]
       movups    [rdx],xmm0
       movups    [rdx+4],xmm1
       jmp       near ptr M04_L05
M04_L15:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2FC988]; Precode of System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M04_L05
M04_L16:
       call      qword ptr [7FFB0F2F2620]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD738]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB2A0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 748
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rsi,offset MT_System.Byte[]
       mov       rcx,rsi
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rbp,rbx
       mov       ebx,[rbx+8]
       test      rbp,rbp
       je        short M00_L02
       mov       r14d,[rbp+8]
       cmp       [rbp],rsi
       jne       short M00_L03
M00_L00:
       mov       rdx,r14
       cmp       rbp,rdi
       je        short M00_L01
       mov       edx,[rdi+8]
M00_L01:
       mov       r8d,ebx
       cmp       r14,r8
       jb        near ptr M00_L05
       cmp       rdx,r8
       jb        near ptr M00_L05
       lea       rcx,[rdi+10]
       lea       rdx,[rbp+10]
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L02:
       mov       ecx,257
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       rcx,rax
       call      qword ptr [7FFAB22B7C60]
       int       3
M00_L03:
       mov       rcx,rbp
       call      00007FFB119D9B60
       mov       edx,3003FFC
       bt        edx,eax
       jb        short M00_L04
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22B7C78]
       mov       rsi,rax
       mov       ecx,257
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbx
       call      qword ptr [7FFAB21D5860]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L04:
       mov       rdx,[rbp]
       movzx     edx,word ptr [rdx]
       imul      r14,rdx
       jmp       near ptr M00_L00
M00_L05:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22B7C90]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB208F9A8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 301
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L10
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L10
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       near ptr M01_L06
       cmp       r8,40
       jbe       short M01_L02
       cmp       r8,800
       ja        near ptr M01_L11
       cmp       r8,100
       jae       near ptr M01_L09
M01_L00:
       mov       r9,r8
       shr       r9,6
M01_L01:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L01
       and       r8,3F
       cmp       r8,10
       jbe       short M01_L03
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M01_L03
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       ja        short M01_L05
M01_L03:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
M01_L04:
       vzeroupper
       ret
M01_L05:
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       short M01_L03
M01_L06:
       test      r8b,18
       je        short M01_L07
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L04
M01_L07:
       test      r8b,4
       je        short M01_L08
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L04
M01_L08:
       test      r8,r8
       je        short M01_L04
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L04
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L04
M01_L09:
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
       jmp       near ptr M01_L00
M01_L10:
       cmp       rcx,rdx
       jne       short M01_L11
       cmp       [rdx],dl
       jmp       near ptr M01_L04
M01_L11:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E066E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 325
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       mov       edx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       r8d,esi
       lea       rcx,[rdi+10]
       mov       rdx,rbx
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,194CA5662A0
       jmp       short M00_L01
; Total bytes of code 92
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L10
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L10
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       near ptr M01_L06
       cmp       r8,40
       jbe       short M01_L02
       cmp       r8,800
       ja        near ptr M01_L11
       cmp       r8,100
       jae       near ptr M01_L09
M01_L00:
       mov       r9,r8
       shr       r9,6
M01_L01:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L01
       and       r8,3F
       cmp       r8,10
       jbe       short M01_L03
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M01_L03
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       ja        short M01_L05
M01_L03:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
M01_L04:
       vzeroupper
       ret
M01_L05:
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       short M01_L03
M01_L06:
       test      r8b,18
       je        short M01_L07
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L04
M01_L07:
       test      r8b,4
       je        short M01_L08
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L04
M01_L08:
       test      r8,r8
       je        short M01_L04
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L04
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L04
M01_L09:
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
       jmp       near ptr M01_L00
M01_L10:
       cmp       rcx,rdx
       jne       short M01_L11
       cmp       [rdx],dl
       jmp       near ptr M01_L04
M01_L11:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E066E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 325
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithToArray()
       push      r15
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       rcx,rbx
       test      rcx,rcx
       je        short M00_L00
       mov       rdx,offset MT_System.Byte[]
       cmp       [rcx],rdx
       jne       near ptr M00_L16
       xor       ecx,ecx
M00_L00:
       test      rcx,rcx
       jne       near ptr M00_L17
       test      rbx,rbx
       je        near ptr M00_L23
       mov       edx,[rbx+8]
       test      edx,edx
       je        near ptr M00_L22
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       edi,[rbx+8]
       mov       rbp,[rbx]
       mov       rax,rbp
       cmp       rax,[rsi]
       je        short M00_L03
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       eax,1
       test      ecx,ecx
       cmove     ecx,eax
       mov       rax,[rsi]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       edx,1
       test      eax,eax
       cmove     eax,edx
       cmp       ecx,eax
       jne       near ptr M00_L18
M00_L01:
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L04
       xor       r14d,r14d
M00_L02:
       test      r14d,r14d
       jle       short M00_L05
       mov       ecx,167
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       edx,r14d
       xor       ecx,ecx
       call      qword ptr [7FFAB22B7E88]
       int       3
M00_L03:
       cmp       dword ptr [rax+4],18
       jne       short M00_L01
       cmp       edi,[rbx+8]
       ja        short M00_L01
       cmp       edi,[rsi+8]
       ja        short M00_L01
       mov       r8d,edi
       movzx     ecx,word ptr [rax]
       imul      r8,rcx
       lea       rdx,[rbx+10]
       lea       rcx,[rsi+10]
       test      dword ptr [rax],1000000
       je        near ptr M00_L15
       call      qword ptr [7FFAB1E057A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L04:
       movsxd    rcx,ecx
       mov       r14d,[rbx+rcx*4+10]
       jmp       short M00_L02
M00_L05:
       neg       r14d
       js        near ptr M00_L19
       lea       ecx,[r14+rdi]
       cmp       ecx,[rbx+8]
       ja        near ptr M00_L19
       mov       rcx,[rsi]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L07
       xor       r15d,r15d
M00_L06:
       test      r15d,r15d
       jle       short M00_L08
       mov       ecx,17F
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       edx,r15d
       xor       ecx,ecx
       call      qword ptr [7FFAB22B7E88]
       int       3
M00_L07:
       movsxd    rcx,ecx
       mov       r15d,[rsi+rcx*4+10]
       jmp       short M00_L06
M00_L08:
       neg       r15d
       js        near ptr M00_L20
       lea       ecx,[r15+rdi]
       cmp       ecx,[rsi+8]
       ja        near ptr M00_L20
       cmp       rbp,[rsi]
       je        short M00_L11
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFAB22B7F30]; System.Array.CanAssignArrayType(System.Array, System.Array)
       test      eax,eax
       je        short M00_L11
       mov       [rsp+20],edi
       mov       [rsp+28],eax
       mov       rcx,rbx
       mov       edx,r14d
       mov       r8,rsi
       mov       r9d,r15d
       call      qword ptr [7FFAB22B7F48]
M00_L09:
       mov       rax,rsi
M00_L10:
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M00_L11:
       movzx     ecx,word ptr [rbp]
       mov       r8d,edi
       imul      r8,rcx
       mov       edx,r14d
       imul      rdx,rcx
       lea       rdx,[rbx+rdx+10]
       mov       eax,r15d
       imul      rcx,rax
       lea       rcx,[rsi+rcx+10]
       test      dword ptr [rbp],1000000
       jne       short M00_L13
       cmp       r8,14
       je        short M00_L12
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L09
M00_L12:
       vmovdqu   xmm0,xmmword ptr [rdx]
       vmovdqu   xmm1,xmmword ptr [rdx+4]
       vmovdqu   xmmword ptr [rcx],xmm0
       vmovdqu   xmmword ptr [rcx+4],xmm1
       jmp       short M00_L09
M00_L13:
       cmp       r8,4000
       jbe       short M00_L14
       call      qword ptr [7FFAB22B7E10]
       jmp       short M00_L09
M00_L14:
       call      00007FFB11A05D60
       cmp       dword ptr [7FFB11D6F778],0
       je        short M00_L09
       jmp       near ptr M00_L21
M00_L15:
       call      qword ptr [7FFAB1E05818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L16:
       mov       rdx,rbx
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.Byte>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rcx,rax
       jmp       near ptr M00_L00
M00_L17:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [rax+30]
M00_L18:
       mov       rcx,offset MT_System.RankException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22B7ED0]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB22B7EE8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L19:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       call      qword ptr [7FFAB22B7F00]
       mov       rbx,rax
       mov       ecx,12D
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rsi
       call      qword ptr [7FFAB21D5860]
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
M00_L20:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       call      qword ptr [7FFAB22B7F18]
       mov       rbx,rax
       mov       ecx,145
       mov       rdx,7FFAB1D44000
       call      qword ptr [7FFAB2087738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rdi
       call      qword ptr [7FFAB21D5860]
       mov       rcx,rdi
       call      CORINFO_HELP_THROW
       int       3
M00_L21:
       call      CORINFO_HELP_POLL_GC
       jmp       near ptr M00_L09
M00_L22:
       mov       rax,219CA4662A0
       jmp       near ptr M00_L10
M00_L23:
       xor       ecx,ecx
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [7FFAB22B58A8]
; Total bytes of code 866
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Array.CanAssignArrayType(System.Array, System.Array)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       rcx,[rax+30]
       mov       rbx,rcx
       mov       rax,[rdx]
       mov       rsi,[rax+30]
       mov       rdi,rsi
       cmp       rbx,rdi
       je        near ptr M02_L32
       mov       eax,ecx
       and       eax,2
       mov       edx,esi
       and       edx,2
       or        eax,edx
       jne       near ptr M02_L28
       mov       rbp,rbx
       mov       r14,rdi
       mov       eax,[rcx]
       and       eax,0C0000
       cmp       eax,40000
       je        near ptr M02_L04
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L05
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rbx
       mov       rax,rdi
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L00:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       near ptr M02_L15
       mov       r9,rdi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L15
       cmp       r10d,[rax]
       jne       near ptr M02_L39
M02_L01:
       test      r9d,r9d
       je        near ptr M02_L16
       cmp       r9d,1
       je        short M02_L02
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L16
M02_L02:
       mov       eax,4
       jmp       near ptr M02_L14
M02_L03:
       test      r10d,r10d
       je        near ptr M02_L40
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L17
       jmp       near ptr M02_L40
M02_L04:
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L23
M02_L05:
       mov       eax,[rcx]
       and       eax,0E0000
       cmp       eax,60000
       jne       short M02_L06
       mov       eax,[rsi]
       and       eax,0E0000
       cmp       eax,60000
       je        near ptr M02_L20
M02_L06:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbp
       rol       r8,20
       xor       r8,r14
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L07:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbp
       jne       near ptr M02_L34
       mov       r9,r14
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L34
       cmp       r10d,[rax]
       jne       near ptr M02_L41
M02_L08:
       test      r9d,r9d
       je        short M02_L09
       cmp       r9d,1
       je        near ptr M02_L32
       mov       rcx,rbp
       mov       rdx,r14
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L32
M02_L09:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,r14
       mov       rax,rbp
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L10:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,r14
       jne       near ptr M02_L35
       mov       r9,rbp
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L35
       cmp       r10d,[rax]
       jne       near ptr M02_L42
M02_L11:
       test      r9d,r9d
       je        short M02_L12
       cmp       r9d,1
       je        short M02_L13
       mov       rcx,r14
       mov       rdx,rbp
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       short M02_L13
M02_L12:
       mov       ecx,[r14]
       and       ecx,0F0000
       cmp       ecx,0C0000
       je        short M02_L13
       mov       ecx,[rbp]
       and       ecx,0F0000
       cmp       ecx,0C0000
       jne       near ptr M02_L19
M02_L13:
       mov       eax,2
M02_L14:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L15:
       test      r10d,r10d
       je        near ptr M02_L39
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L00
       jmp       near ptr M02_L39
M02_L16:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rdi
       mov       rax,rbx
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L17:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rdi
       jne       near ptr M02_L03
       mov       r9,rbx
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L03
       cmp       r10d,[rax]
       jne       near ptr M02_L40
M02_L18:
       test      r9d,r9d
       je        short M02_L19
       cmp       r9d,1
       je        near ptr M02_L02
       mov       rcx,rdi
       mov       rdx,rbx
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L02
M02_L19:
       mov       eax,1
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L20:
       call      qword ptr [7FFB0F303EF0]
       mov       ebx,eax
       mov       rcx,rsi
       call      qword ptr [7FFB0F303EF0]
       mov       esi,eax
       mov       ecx,ebx
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       mov       edi,eax
       mov       ecx,esi
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       cmp       edi,eax
       je        near ptr M02_L32
       cmp       ebx,0E
       jge       short M02_L21
       cmp       ebx,0E
       jae       near ptr M02_L43
       mov       eax,ebx
       lea       rcx,[7FFB0E678348]
       movsx     rax,word ptr [rcx+rax*2]
       bt        eax,esi
       jae       short M02_L19
       jmp       short M02_L22
M02_L21:
       cmp       ebx,esi
       jne       short M02_L19
M02_L22:
       mov       eax,5
       jmp       near ptr M02_L14
M02_L23:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rsi
       add       rdx,10
       mov       rax,rbx
       rol       rax,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L24:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L27
       mov       r9,rsi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        short M02_L27
       cmp       r10d,[rax]
       jne       near ptr M02_L38
M02_L25:
       test      r9d,r9d
       je        near ptr M02_L19
       cmp       r9d,1
       je        short M02_L26
       mov       rcx,rbx
       mov       rdx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L26:
       mov       eax,3
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L27:
       test      r10d,r10d
       je        near ptr M02_L38
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L24
       jmp       near ptr M02_L38
M02_L28:
       mov       rdi,rsi
       test      cl,2
       jne       short M02_L29
       test      sil,2
       jne       near ptr M02_L36
M02_L29:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbx
       rol       r8,20
       xor       r8,rdi
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L30:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L33
       mov       rsi,rdi
       xor       rsi,[rax+10]
       cmp       rsi,1
       ja        short M02_L33
       cmp       r10d,[rax]
       jne       near ptr M02_L37
M02_L31:
       test      esi,esi
       je        near ptr M02_L19
       cmp       esi,1
       je        short M02_L32
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L32:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L33:
       test      r10d,r10d
       je        short M02_L37
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        short M02_L30
       jmp       short M02_L37
M02_L34:
       test      r10d,r10d
       je        short M02_L41
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L07
       jmp       short M02_L41
M02_L35:
       test      r10d,r10d
       je        short M02_L42
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L10
       jmp       short M02_L42
M02_L36:
       xor       esi,esi
       jmp       short M02_L31
M02_L37:
       mov       esi,2
       jmp       near ptr M02_L31
M02_L38:
       mov       r9d,2
       jmp       near ptr M02_L25
M02_L39:
       mov       r9d,2
       jmp       near ptr M02_L01
M02_L40:
       mov       r9d,2
       jmp       near ptr M02_L18
M02_L41:
       mov       r9d,2
       jmp       near ptr M02_L08
M02_L42:
       mov       r9d,2
       jmp       near ptr M02_L11
M02_L43:
       call      qword ptr [7FFB0F2E7FC0]
       int       3
; Total bytes of code 1451
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M03_L11
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M03_L11
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       short M03_L02
       cmp       r8,40
       jbe       short M03_L01
       cmp       r8,800
       jbe       near ptr M03_L07
M03_L00:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E066E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M03_L01:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M03_L10
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M03_L10
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M03_L10
M03_L02:
       test      r8b,18
       je        short M03_L03
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M03_L05
M03_L03:
       test      r8b,4
       je        short M03_L04
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M03_L05
M03_L04:
       test      r8,r8
       jne       short M03_L06
M03_L05:
       vzeroupper
       ret
M03_L06:
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M03_L05
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M03_L05
M03_L07:
       cmp       r8,100
       jb        short M03_L08
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M03_L08:
       mov       r9,r8
       shr       r9,6
M03_L09:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M03_L09
       and       r8,3F
       cmp       r8,10
       ja        near ptr M03_L01
M03_L10:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M03_L05
M03_L11:
       cmp       rcx,rdx
       jne       near ptr M03_L00
       cmp       [rdx],dl
       jmp       near ptr M03_L05
; Total bytes of code 336
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       test      rdx,rdx
       je        short M04_L02
       mov       rax,[rdx]
       cmp       rax,rcx
       je        short M04_L02
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
M04_L00:
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       jne       short M04_L03
M04_L01:
       xor       edx,edx
M04_L02:
       mov       rax,rdx
       ret
M04_L03:
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       jmp       short M04_L00
; Total bytes of code 86
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithArrayCopy()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       rdi,rbx
       mov       ebx,[rbx+8]
       test      rdi,rdi
       je        near ptr M00_L12
       mov       rcx,[rdi]
       cmp       rcx,[rsi]
       jne       near ptr M00_L13
       cmp       dword ptr [rcx+4],18
       jne       near ptr M00_L13
       cmp       ebx,[rdi+8]
       ja        near ptr M00_L13
       cmp       ebx,[rsi+8]
       ja        near ptr M00_L13
       mov       r8d,ebx
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rdi+10]
       lea       rax,[rsi+10]
       test      dword ptr [rcx],1000000
       jne       short M00_L02
       mov       rcx,rax
       mov       r10,rdx
       mov       r9,r8
       mov       r11,rcx
       sub       r11,r10
       cmp       r11,r9
       jb        near ptr M00_L11
       mov       r11,r10
       sub       r11,rcx
       cmp       r11,r9
       jb        near ptr M00_L11
       lea       r11,[r10+r9]
       lea       rdi,[rcx+r9]
       cmp       r9,10
       jbe       short M00_L04
       cmp       r9,40
       jbe       short M00_L03
       cmp       r9,800
       jbe       near ptr M00_L07
M00_L00:
       cmp       [rax],al
       mov       rcx,rax
       call      qword ptr [7FFAB1E366E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M00_L01:
       mov       rax,rsi
       vzeroupper
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       rcx,rax
       call      qword ptr [7FFAB1E357A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L01
M00_L03:
       vmovups   xmm0,[r10]
       vmovups   [rcx],xmm0
       cmp       r9,20
       jbe       near ptr M00_L10
       vmovups   xmm0,[r10+10]
       vmovups   [rcx+10],xmm0
       cmp       r9,30
       jbe       near ptr M00_L10
       vmovups   xmm0,[r10+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M00_L10
M00_L04:
       test      r8b,18
       je        short M00_L05
       mov       rdx,[rdx]
       mov       [rax],rdx
       mov       rax,[r11-8]
       mov       [rdi-8],rax
       jmp       short M00_L01
M00_L05:
       test      r8b,4
       je        short M00_L06
       mov       edx,[rdx]
       mov       [rax],edx
       mov       eax,[r11-4]
       mov       [rdi-4],eax
       jmp       short M00_L01
M00_L06:
       test      r8,r8
       je        short M00_L01
       movzx     edx,byte ptr [rdx]
       mov       [rax],dl
       test      r8b,2
       je        near ptr M00_L01
       movsx     rax,word ptr [r11-2]
       mov       [rdi-2],ax
       jmp       near ptr M00_L01
M00_L07:
       cmp       r9,100
       jb        short M00_L08
       mov       r10,rax
       and       r10,3F
       mov       r9,r10
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rax],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rax+20],ymm0
       lea       r10,[rdx+r9]
       lea       rcx,[rax+r9]
       sub       r8,r9
       mov       r9,r8
M00_L08:
       mov       rdx,r9
       shr       rdx,6
M00_L09:
       vmovdqu   ymm0,ymmword ptr [r10]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [r10+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       r10,40
       dec       rdx
       jne       short M00_L09
       and       r9,3F
       cmp       r9,10
       ja        near ptr M00_L03
M00_L10:
       vmovups   xmm0,[r11-10]
       vmovups   [rdi-10],xmm0
       jmp       near ptr M00_L01
M00_L11:
       cmp       rax,rdx
       je        near ptr M00_L01
       jmp       near ptr M00_L00
M00_L12:
       xor       ebp,ebp
       jmp       short M00_L14
M00_L13:
       mov       rcx,rdi
       xor       edx,edx
       call      qword ptr [7FFAB22E7C00]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
M00_L14:
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFAB22E7C00]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],ebx
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rdi
       mov       edx,ebp
       mov       r8,rsi
       call      qword ptr [7FFAB22E7BD0]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       jmp       near ptr M00_L01
; Total bytes of code 556
```
```assembly
; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,68
       vzeroupper
       lea       rbp,[rsp+0A0]
       mov       rbx,rcx
       mov       rsi,rdx
       mov       rdi,r8
       lea       rcx,[rbp-80]
       call      CORINFO_HELP_INIT_PINVOKE_FRAME
       mov       r14,rax
       mov       rcx,rsp
       mov       [rbp-68],rcx
       mov       rcx,rbp
       mov       [rbp-58],rcx
       mov       [rbp-40],rbx
       mov       [rbp-48],rsi
       mov       rcx,rbx
       mov       rdx,rsi
       mov       r8,rdi
       mov       rax,7FFAB1EA2518
       mov       [rbp-70],rax
       lea       rax,[M01_L00]
       mov       [rbp-60],rax
       lea       rax,[rbp-80]
       mov       [r14+8],rax
       mov       byte ptr [r14+4],0
       mov       rax,7FFB11A27E70
       call      rax
M01_L00:
       mov       byte ptr [r14+4],1
       cmp       dword ptr [7FFB11D6F778],0
       je        short M01_L01
       call      qword ptr [7FFB11D5D608]; CORINFO_HELP_STOP_FOR_GC
M01_L01:
       mov       rax,[rbp-78]
       mov       [r14+8],rax
       xor       eax,eax
       mov       [rbp-48],rax
       mov       [rbp-40],rax
       add       rsp,68
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
; Total bytes of code 184
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M02_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M02_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M02_L02
M02_L01:
       add       rsp,28
       ret
M02_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M02_L01
; Total bytes of code 58
```
```assembly
; System.Array.GetLowerBound(Int32)
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       r8d,eax
       or        r8d,edx
       je        short M03_L00
       cmp       edx,eax
       jae       short M03_L01
       add       eax,edx
       cdqe
       mov       eax,[rcx+rax*4+10]
       add       rsp,20
       pop       rbx
       ret
M03_L00:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M03_L01:
       call      qword ptr [7FFB0F2F2710]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD950]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC0E0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 88
```
```assembly
; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       test      rbx,rbx
       je        near ptr M04_L07
       test      rsi,rsi
       je        near ptr M04_L06
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L00
       mov       rcx,[rbx]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       edx,1
       test      ecx,ecx
       cmove     ecx,edx
       mov       rdx,[rsi]
       mov       edx,[rdx+4]
       add       edx,0FFFFFFE8
       shr       edx,3
       mov       eax,1
       test      edx,edx
       cmove     edx,eax
       cmp       ecx,edx
       jne       near ptr M04_L08
M04_L00:
       mov       r14d,[rsp+70]
       test      r14d,r14d
       jl        near ptr M04_L09
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       edi,eax
       jge       short M04_L01
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,edi
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L01:
       sub       edi,eax
       js        near ptr M04_L10
       lea       ecx,[rdi+r14]
       cmp       ecx,[rbx+8]
       ja        near ptr M04_L10
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       ebp,eax
       jge       short M04_L02
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,ebp
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L02:
       sub       ebp,eax
       js        near ptr M04_L11
       lea       ecx,[r14+rbp]
       cmp       ecx,[rsi+8]
       ja        near ptr M04_L11
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L03
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFB0F2F9320]
       test      eax,eax
       je        short M04_L03
       cmp       byte ptr [rsp+78],0
       jne       near ptr M04_L16
       mov       [rsp+70],r14d
       mov       [rsp+78],eax
       mov       rcx,rbx
       mov       edx,edi
       mov       r8,rsi
       mov       r9d,ebp
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L03:
       mov       rcx,[rbx]
       movzx     edx,word ptr [rcx]
       mov       r8d,r14d
       imul      r8,rdx
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       mov       r10d,edi
       imul      r10,rdx
       add       r10,rax
       lea       rax,[rsi+8]
       mov       r9,[rsi]
       mov       r9d,[r9+4]
       add       r9,0FFFFFFFFFFFFFFF0
       add       rax,r9
       mov       r9d,ebp
       imul      rdx,r9
       add       rdx,rax
       test      dword ptr [rcx],1000000
       jne       short M04_L04
       cmp       r8,14
       jne       near ptr M04_L15
       jmp       near ptr M04_L14
M04_L04:
       cmp       r8,4000
       ja        near ptr M04_L13
       jmp       near ptr M04_L12
M04_L05:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M04_L06:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L07:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L08:
       call      qword ptr [7FFB0F2F2830]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FDDB8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC818]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L09:
       mov       rdx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rdx,[rdx]
       mov       ecx,r14d
       call      qword ptr [7FFB0F3109B0]
       int       3
M04_L10:
       call      qword ptr [7FFB0F2F25F8]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FCC70]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L11:
       call      qword ptr [7FFB0F2F25F8]
       mov       r14,rax
       call      qword ptr [7FFB0F2FCC68]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,r14
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,r14
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L12:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       je        near ptr M04_L05
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       near ptr M04_L05
M04_L13:
       mov       rcx,rdx
       mov       rdx,r10
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L14:
       movups    xmm0,[r10]
       movups    xmm1,[r10+4]
       movups    [rdx],xmm0
       movups    [rdx+4],xmm1
       jmp       near ptr M04_L05
M04_L15:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2FC988]; Precode of System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M04_L05
M04_L16:
       call      qword ptr [7FFB0F2F2620]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD738]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB2A0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 748
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rsi,offset MT_System.Byte[]
       mov       rcx,rsi
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rbp,rbx
       mov       ebx,[rbx+8]
       test      rbp,rbp
       je        short M00_L02
       mov       r14d,[rbp+8]
       cmp       [rbp],rsi
       jne       short M00_L03
M00_L00:
       mov       rdx,r14
       cmp       rbp,rdi
       je        short M00_L01
       mov       edx,[rdi+8]
M00_L01:
       mov       r8d,ebx
       cmp       r14,r8
       jb        near ptr M00_L05
       cmp       rdx,r8
       jb        near ptr M00_L05
       lea       rcx,[rdi+10]
       lea       rdx,[rbp+10]
       call      qword ptr [7FFAB1E35818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L02:
       mov       ecx,257
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       rcx,rax
       call      qword ptr [7FFAB22E7C18]
       int       3
M00_L03:
       mov       rcx,rbp
       call      00007FFB119D9B60
       mov       edx,3003FFC
       bt        edx,eax
       jb        short M00_L04
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22E7C30]
       mov       rsi,rax
       mov       ecx,257
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbx
       call      qword ptr [7FFAB2205860]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L04:
       mov       rdx,[rbp]
       movzx     edx,word ptr [rdx]
       imul      r14,rdx
       jmp       near ptr M00_L00
M00_L05:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22E7C48]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB20BF9A8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 301
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L11
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L11
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       short M01_L02
       cmp       r8,40
       jbe       short M01_L01
       cmp       r8,800
       jbe       near ptr M01_L07
M01_L00:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E366E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M01_L01:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L10
M01_L02:
       test      r8b,18
       je        short M01_L03
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L05
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L05
M01_L04:
       test      r8,r8
       jne       short M01_L06
M01_L05:
       vzeroupper
       ret
M01_L06:
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L05
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L05
M01_L07:
       cmp       r8,100
       jb        short M01_L08
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L08:
       mov       r9,r8
       shr       r9,6
M01_L09:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L09
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L01
M01_L10:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L05
M01_L11:
       cmp       rcx,rdx
       jne       near ptr M01_L00
       cmp       [rdx],dl
       jmp       near ptr M01_L05
; Total bytes of code 336
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       mov       edx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       r8d,esi
       lea       rcx,[rdi+10]
       mov       rdx,rbx
       call      qword ptr [7FFAB1E25818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,1AC4A4762A0
       jmp       short M00_L01
; Total bytes of code 92
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L11
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L11
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       short M01_L02
       cmp       r8,40
       jbe       short M01_L01
       cmp       r8,800
       jbe       near ptr M01_L07
M01_L00:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E266E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M01_L01:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L10
M01_L02:
       test      r8b,18
       je        short M01_L03
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L05
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L05
M01_L04:
       test      r8,r8
       jne       short M01_L06
M01_L05:
       vzeroupper
       ret
M01_L06:
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L05
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L05
M01_L07:
       cmp       r8,100
       jb        short M01_L08
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L08:
       mov       r9,r8
       shr       r9,6
M01_L09:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L09
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L01
M01_L10:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L05
M01_L11:
       cmp       rcx,rdx
       jne       near ptr M01_L00
       cmp       [rdx],dl
       jmp       near ptr M01_L05
; Total bytes of code 336
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithToArray()
       push      r15
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       rcx,rbx
       test      rcx,rcx
       je        short M00_L00
       mov       rdx,offset MT_System.Byte[]
       cmp       [rcx],rdx
       jne       near ptr M00_L16
       xor       ecx,ecx
M00_L00:
       test      rcx,rcx
       jne       near ptr M00_L17
       test      rbx,rbx
       je        near ptr M00_L23
       mov       edx,[rbx+8]
       test      edx,edx
       je        near ptr M00_L22
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       edi,[rbx+8]
       mov       rbp,[rbx]
       mov       rax,rbp
       cmp       rax,[rsi]
       je        short M00_L03
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       eax,1
       test      ecx,ecx
       cmove     ecx,eax
       mov       rax,[rsi]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       edx,1
       test      eax,eax
       cmove     eax,edx
       cmp       ecx,eax
       jne       near ptr M00_L18
M00_L01:
       mov       rcx,rbp
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L04
       xor       r14d,r14d
M00_L02:
       test      r14d,r14d
       jle       short M00_L05
       mov       ecx,167
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       r8,rax
       mov       edx,r14d
       xor       ecx,ecx
       call      qword ptr [7FFAB22E7E88]
       int       3
M00_L03:
       cmp       dword ptr [rax+4],18
       jne       short M00_L01
       cmp       edi,[rbx+8]
       ja        short M00_L01
       cmp       edi,[rsi+8]
       ja        short M00_L01
       mov       r8d,edi
       movzx     ecx,word ptr [rax]
       imul      r8,rcx
       lea       rdx,[rbx+10]
       lea       rcx,[rsi+10]
       test      dword ptr [rax],1000000
       je        near ptr M00_L15
       call      qword ptr [7FFAB1E357A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L04:
       movsxd    rcx,ecx
       mov       r14d,[rbx+rcx*4+10]
       jmp       short M00_L02
M00_L05:
       neg       r14d
       js        near ptr M00_L19
       lea       ecx,[r14+rdi]
       cmp       ecx,[rbx+8]
       ja        near ptr M00_L19
       mov       rcx,[rsi]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       jne       short M00_L07
       xor       r15d,r15d
M00_L06:
       test      r15d,r15d
       jle       short M00_L08
       mov       ecx,17F
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       r8,rax
       mov       edx,r15d
       xor       ecx,ecx
       call      qword ptr [7FFAB22E7E88]
       int       3
M00_L07:
       movsxd    rcx,ecx
       mov       r15d,[rsi+rcx*4+10]
       jmp       short M00_L06
M00_L08:
       neg       r15d
       js        near ptr M00_L20
       lea       ecx,[r15+rdi]
       cmp       ecx,[rsi+8]
       ja        near ptr M00_L20
       cmp       rbp,[rsi]
       je        short M00_L11
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFAB22E7F30]; System.Array.CanAssignArrayType(System.Array, System.Array)
       test      eax,eax
       je        short M00_L11
       mov       [rsp+20],edi
       mov       [rsp+28],eax
       mov       rcx,rbx
       mov       edx,r14d
       mov       r8,rsi
       mov       r9d,r15d
       call      qword ptr [7FFAB22E7F48]
M00_L09:
       mov       rax,rsi
M00_L10:
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M00_L11:
       movzx     ecx,word ptr [rbp]
       mov       r8d,edi
       imul      r8,rcx
       mov       edx,r14d
       imul      rdx,rcx
       lea       rdx,[rbx+rdx+10]
       mov       eax,r15d
       imul      rcx,rax
       lea       rcx,[rsi+rcx+10]
       test      dword ptr [rbp],1000000
       jne       short M00_L13
       cmp       r8,14
       je        short M00_L12
       call      qword ptr [7FFAB1E35818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L09
M00_L12:
       vmovdqu   xmm0,xmmword ptr [rdx]
       vmovdqu   xmm1,xmmword ptr [rdx+4]
       vmovdqu   xmmword ptr [rcx],xmm0
       vmovdqu   xmmword ptr [rcx+4],xmm1
       jmp       short M00_L09
M00_L13:
       cmp       r8,4000
       jbe       short M00_L14
       call      qword ptr [7FFAB22E7E10]
       jmp       short M00_L09
M00_L14:
       call      00007FFB11A05D60
       cmp       dword ptr [7FFB11D6F778],0
       je        short M00_L09
       jmp       near ptr M00_L21
M00_L15:
       call      qword ptr [7FFAB1E35818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M00_L09
M00_L16:
       mov       rdx,rbx
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.Byte>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rcx,rax
       jmp       near ptr M00_L00
M00_L17:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [rax+30]
M00_L18:
       mov       rcx,offset MT_System.RankException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22E7ED0]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB22E7EE8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L19:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       call      qword ptr [7FFAB22E7F00]
       mov       rbx,rax
       mov       ecx,12D
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rsi
       call      qword ptr [7FFAB2205860]
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
M00_L20:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       call      qword ptr [7FFAB22E7F18]
       mov       rbx,rax
       mov       ecx,145
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,rdi
       call      qword ptr [7FFAB2205860]
       mov       rcx,rdi
       call      CORINFO_HELP_THROW
       int       3
M00_L21:
       call      CORINFO_HELP_POLL_GC
       jmp       near ptr M00_L09
M00_L22:
       mov       rax,2CECA4762A0
       jmp       near ptr M00_L10
M00_L23:
       xor       ecx,ecx
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       jmp       qword ptr [7FFAB22E5980]
; Total bytes of code 866
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M01_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M01_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M01_L02
M01_L01:
       add       rsp,28
       ret
M01_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M01_L01
; Total bytes of code 58
```
```assembly
; System.Array.CanAssignArrayType(System.Array, System.Array)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       rcx,[rax+30]
       mov       rbx,rcx
       mov       rax,[rdx]
       mov       rsi,[rax+30]
       mov       rdi,rsi
       cmp       rbx,rdi
       je        near ptr M02_L32
       mov       eax,ecx
       and       eax,2
       mov       edx,esi
       and       edx,2
       or        eax,edx
       jne       near ptr M02_L28
       mov       rbp,rbx
       mov       r14,rdi
       mov       eax,[rcx]
       and       eax,0C0000
       cmp       eax,40000
       je        near ptr M02_L04
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L05
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rbx
       mov       rax,rdi
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L00:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       near ptr M02_L15
       mov       r9,rdi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L15
       cmp       r10d,[rax]
       jne       near ptr M02_L39
M02_L01:
       test      r9d,r9d
       je        near ptr M02_L16
       cmp       r9d,1
       je        short M02_L02
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L16
M02_L02:
       mov       eax,4
       jmp       near ptr M02_L14
M02_L03:
       test      r10d,r10d
       je        near ptr M02_L40
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L17
       jmp       near ptr M02_L40
M02_L04:
       mov       eax,[rsi]
       and       eax,0C0000
       cmp       eax,40000
       jne       near ptr M02_L23
M02_L05:
       mov       eax,[rcx]
       and       eax,0E0000
       cmp       eax,60000
       jne       short M02_L06
       mov       eax,[rsi]
       and       eax,0E0000
       cmp       eax,60000
       je        near ptr M02_L20
M02_L06:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbp
       rol       r8,20
       xor       r8,r14
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L07:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbp
       jne       near ptr M02_L34
       mov       r9,r14
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L34
       cmp       r10d,[rax]
       jne       near ptr M02_L41
M02_L08:
       test      r9d,r9d
       je        short M02_L09
       cmp       r9d,1
       je        near ptr M02_L32
       mov       rcx,rbp
       mov       rdx,r14
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L32
M02_L09:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,r14
       mov       rax,rbp
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L10:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,r14
       jne       near ptr M02_L35
       mov       r9,rbp
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L35
       cmp       r10d,[rax]
       jne       near ptr M02_L42
M02_L11:
       test      r9d,r9d
       je        short M02_L12
       cmp       r9d,1
       je        short M02_L13
       mov       rcx,r14
       mov       rdx,rbp
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       short M02_L13
M02_L12:
       mov       ecx,[r14]
       and       ecx,0F0000
       cmp       ecx,0C0000
       je        short M02_L13
       mov       ecx,[rbp]
       and       ecx,0F0000
       cmp       ecx,0C0000
       jne       near ptr M02_L19
M02_L13:
       mov       eax,2
M02_L14:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L15:
       test      r10d,r10d
       je        near ptr M02_L39
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L00
       jmp       near ptr M02_L39
M02_L16:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rdi
       mov       rax,rbx
       add       rdx,10
       rol       r8,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L17:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rdi
       jne       near ptr M02_L03
       mov       r9,rbx
       xor       r9,[rax+10]
       cmp       r9,1
       ja        near ptr M02_L03
       cmp       r10d,[rax]
       jne       near ptr M02_L40
M02_L18:
       test      r9d,r9d
       je        short M02_L19
       cmp       r9d,1
       je        near ptr M02_L02
       mov       rcx,rdi
       mov       rdx,rbx
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       jne       near ptr M02_L02
M02_L19:
       mov       eax,1
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L20:
       call      qword ptr [7FFB0F303EF0]
       mov       ebx,eax
       mov       rcx,rsi
       call      qword ptr [7FFB0F303EF0]
       mov       esi,eax
       mov       ecx,ebx
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       mov       edi,eax
       mov       ecx,esi
       call      qword ptr [7FFB0F2F9318]; Precode of System.Array.GetNormalizedIntegralArrayElementType(System.Reflection.CorElementType)
       cmp       edi,eax
       je        near ptr M02_L32
       cmp       ebx,0E
       jge       short M02_L21
       cmp       ebx,0E
       jae       near ptr M02_L43
       mov       eax,ebx
       lea       rcx,[7FFB0E678348]
       movsx     rax,word ptr [rcx+rax*2]
       bt        eax,esi
       jae       short M02_L19
       jmp       short M02_L22
M02_L21:
       cmp       ebx,esi
       jne       short M02_L19
M02_L22:
       mov       eax,5
       jmp       near ptr M02_L14
M02_L23:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       mov       r8,rsi
       add       rdx,10
       mov       rax,rbx
       rol       rax,20
       xor       r8,rax
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L24:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L27
       mov       r9,rsi
       xor       r9,[rax+10]
       cmp       r9,1
       ja        short M02_L27
       cmp       r10d,[rax]
       jne       near ptr M02_L38
M02_L25:
       test      r9d,r9d
       je        near ptr M02_L19
       cmp       r9d,1
       je        short M02_L26
       mov       rcx,rbx
       mov       rdx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L26:
       mov       eax,3
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L27:
       test      r10d,r10d
       je        near ptr M02_L38
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L24
       jmp       near ptr M02_L38
M02_L28:
       mov       rdi,rsi
       test      cl,2
       jne       short M02_L29
       test      sil,2
       jne       near ptr M02_L36
M02_L29:
       call      qword ptr [7FFB0F2E8C00]
       mov       rdx,[rax]
       add       rdx,10
       mov       r8,rbx
       rol       r8,20
       xor       r8,rdi
       mov       rax,9E3779B97F4A7C15
       imul      r8,rax
       mov       ecx,[rdx]
       shr       r8,cl
       xor       ecx,ecx
M02_L30:
       lea       eax,[r8+1]
       cdqe
       lea       rax,[rax+rax*2]
       lea       rax,[rdx+rax*8]
       mov       r10d,[rax]
       mov       r9,[rax+8]
       and       r10d,0FFFFFFFE
       cmp       r9,rbx
       jne       short M02_L33
       mov       rsi,rdi
       xor       rsi,[rax+10]
       cmp       rsi,1
       ja        short M02_L33
       cmp       r10d,[rax]
       jne       near ptr M02_L37
M02_L31:
       test      esi,esi
       je        near ptr M02_L19
       cmp       esi,1
       je        short M02_L32
       mov       rcx,rbx
       mov       rdx,rdi
       xor       r8d,r8d
       call      qword ptr [7FFB0F303F10]; Precode of System.Runtime.CompilerServices.TypeHandle.CanCastToWorker(System.Runtime.CompilerServices.TypeHandle, System.Runtime.CompilerServices.TypeHandle, Boolean)
       test      eax,eax
       je        near ptr M02_L19
M02_L32:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M02_L33:
       test      r10d,r10d
       je        short M02_L37
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        short M02_L30
       jmp       short M02_L37
M02_L34:
       test      r10d,r10d
       je        short M02_L41
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L07
       jmp       short M02_L41
M02_L35:
       test      r10d,r10d
       je        short M02_L42
       inc       ecx
       add       r8d,ecx
       and       r8d,[rdx+4]
       cmp       ecx,8
       jl        near ptr M02_L10
       jmp       short M02_L42
M02_L36:
       xor       esi,esi
       jmp       short M02_L31
M02_L37:
       mov       esi,2
       jmp       near ptr M02_L31
M02_L38:
       mov       r9d,2
       jmp       near ptr M02_L25
M02_L39:
       mov       r9d,2
       jmp       near ptr M02_L01
M02_L40:
       mov       r9d,2
       jmp       near ptr M02_L18
M02_L41:
       mov       r9d,2
       jmp       near ptr M02_L08
M02_L42:
       mov       r9d,2
       jmp       near ptr M02_L11
M02_L43:
       call      qword ptr [7FFB0F2E7FC0]
       int       3
; Total bytes of code 1451
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M03_L11
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M03_L11
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       short M03_L02
       cmp       r8,40
       jbe       short M03_L01
       cmp       r8,800
       jbe       near ptr M03_L07
M03_L00:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E366E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M03_L01:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M03_L10
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M03_L10
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M03_L10
M03_L02:
       test      r8b,18
       je        short M03_L03
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M03_L05
M03_L03:
       test      r8b,4
       je        short M03_L04
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M03_L05
M03_L04:
       test      r8,r8
       jne       short M03_L06
M03_L05:
       vzeroupper
       ret
M03_L06:
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M03_L05
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M03_L05
M03_L07:
       cmp       r8,100
       jb        short M03_L08
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M03_L08:
       mov       r9,r8
       shr       r9,6
M03_L09:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M03_L09
       and       r8,3F
       cmp       r8,10
       ja        near ptr M03_L01
M03_L10:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M03_L05
M03_L11:
       cmp       rcx,rdx
       jne       near ptr M03_L00
       cmp       [rdx],dl
       jmp       near ptr M03_L05
; Total bytes of code 336
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       test      rdx,rdx
       je        short M04_L02
       mov       rax,[rdx]
       cmp       rax,rcx
       je        short M04_L02
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
M04_L00:
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       jne       short M04_L03
M04_L01:
       xor       edx,edx
M04_L02:
       mov       rax,rdx
       ret
M04_L03:
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       test      rax,rax
       je        short M04_L01
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M04_L02
       jmp       short M04_L00
; Total bytes of code 86
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithArrayCopy()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       rdi,rbx
       mov       ebx,[rbx+8]
       test      rdi,rdi
       je        near ptr M00_L12
       mov       rcx,[rdi]
       cmp       rcx,[rsi]
       jne       near ptr M00_L13
       cmp       dword ptr [rcx+4],18
       jne       near ptr M00_L13
       cmp       ebx,[rdi+8]
       ja        near ptr M00_L13
       cmp       ebx,[rsi+8]
       ja        near ptr M00_L13
       mov       r8d,ebx
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rdi+10]
       lea       rax,[rsi+10]
       test      dword ptr [rcx],1000000
       jne       short M00_L02
       mov       rcx,rax
       mov       r10,rdx
       mov       r9,r8
       mov       r11,rcx
       sub       r11,r10
       cmp       r11,r9
       jb        near ptr M00_L11
       mov       r11,r10
       sub       r11,rcx
       cmp       r11,r9
       jb        near ptr M00_L11
       lea       r11,[r10+r9]
       lea       rdi,[rcx+r9]
       cmp       r9,10
       jbe       short M00_L04
       cmp       r9,40
       jbe       short M00_L03
       cmp       r9,800
       jbe       near ptr M00_L07
M00_L00:
       cmp       [rax],al
       mov       rcx,rax
       call      qword ptr [7FFAB1E266E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M00_L01:
       mov       rax,rsi
       vzeroupper
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       rcx,rax
       call      qword ptr [7FFAB1E257A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L01
M00_L03:
       vmovups   xmm0,[r10]
       vmovups   [rcx],xmm0
       cmp       r9,20
       jbe       near ptr M00_L10
       vmovups   xmm0,[r10+10]
       vmovups   [rcx+10],xmm0
       cmp       r9,30
       jbe       near ptr M00_L10
       vmovups   xmm0,[r10+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M00_L10
M00_L04:
       test      r8b,18
       je        short M00_L05
       mov       rdx,[rdx]
       mov       [rax],rdx
       mov       rax,[r11-8]
       mov       [rdi-8],rax
       jmp       short M00_L01
M00_L05:
       test      r8b,4
       je        short M00_L06
       mov       edx,[rdx]
       mov       [rax],edx
       mov       eax,[r11-4]
       mov       [rdi-4],eax
       jmp       short M00_L01
M00_L06:
       test      r8,r8
       je        short M00_L01
       movzx     edx,byte ptr [rdx]
       mov       [rax],dl
       test      r8b,2
       je        near ptr M00_L01
       movsx     rax,word ptr [r11-2]
       mov       [rdi-2],ax
       jmp       near ptr M00_L01
M00_L07:
       cmp       r9,100
       jb        short M00_L08
       mov       r10,rax
       and       r10,3F
       mov       r9,r10
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rax],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rax+20],ymm0
       lea       r10,[rdx+r9]
       lea       rcx,[rax+r9]
       sub       r8,r9
       mov       r9,r8
M00_L08:
       mov       rdx,r9
       shr       rdx,6
M00_L09:
       vmovdqu   ymm0,ymmword ptr [r10]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [r10+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       r10,40
       dec       rdx
       jne       short M00_L09
       and       r9,3F
       cmp       r9,10
       ja        near ptr M00_L03
M00_L10:
       vmovups   xmm0,[r11-10]
       vmovups   [rdi-10],xmm0
       jmp       near ptr M00_L01
M00_L11:
       cmp       rax,rdx
       je        near ptr M00_L01
       jmp       near ptr M00_L00
M00_L12:
       xor       ebp,ebp
       jmp       short M00_L14
M00_L13:
       mov       rcx,rdi
       xor       edx,edx
       call      qword ptr [7FFAB22D7C00]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
M00_L14:
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFAB22D7C00]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],ebx
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rdi
       mov       edx,ebp
       mov       r8,rsi
       call      qword ptr [7FFAB22D7BD0]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       jmp       near ptr M00_L01
; Total bytes of code 556
```
```assembly
; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,68
       vzeroupper
       lea       rbp,[rsp+0A0]
       mov       rbx,rcx
       mov       rsi,rdx
       mov       rdi,r8
       lea       rcx,[rbp-80]
       call      CORINFO_HELP_INIT_PINVOKE_FRAME
       mov       r14,rax
       mov       rcx,rsp
       mov       [rbp-68],rcx
       mov       rcx,rbp
       mov       [rbp-58],rcx
       mov       [rbp-40],rbx
       mov       [rbp-48],rsi
       mov       rcx,rbx
       mov       rdx,rsi
       mov       r8,rdi
       mov       rax,7FFAB1E92518
       mov       [rbp-70],rax
       lea       rax,[M01_L00]
       mov       [rbp-60],rax
       lea       rax,[rbp-80]
       mov       [r14+8],rax
       mov       byte ptr [r14+4],0
       mov       rax,7FFB11A27E70
       call      rax
M01_L00:
       mov       byte ptr [r14+4],1
       cmp       dword ptr [7FFB11D6F778],0
       je        short M01_L01
       call      qword ptr [7FFB11D5D608]; CORINFO_HELP_STOP_FOR_GC
M01_L01:
       mov       rax,[rbp-78]
       mov       [r14+8],rax
       xor       eax,eax
       mov       [rbp-48],rax
       mov       [rbp-40],rax
       add       rsp,68
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
; Total bytes of code 184
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M02_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M02_L00:
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M02_L02
M02_L01:
       add       rsp,28
       ret
M02_L02:
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       short M02_L01
; Total bytes of code 58
```
```assembly
; System.Array.GetLowerBound(Int32)
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       r8d,eax
       or        r8d,edx
       je        short M03_L00
       cmp       edx,eax
       jae       short M03_L01
       add       eax,edx
       cdqe
       mov       eax,[rcx+rax*4+10]
       add       rsp,20
       pop       rbx
       ret
M03_L00:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M03_L01:
       call      qword ptr [7FFB0F2F2710]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD950]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC0E0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 88
```
```assembly
; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       test      rbx,rbx
       je        near ptr M04_L07
       test      rsi,rsi
       je        near ptr M04_L06
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L00
       mov       rcx,[rbx]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       edx,1
       test      ecx,ecx
       cmove     ecx,edx
       mov       rdx,[rsi]
       mov       edx,[rdx+4]
       add       edx,0FFFFFFE8
       shr       edx,3
       mov       eax,1
       test      edx,edx
       cmove     edx,eax
       cmp       ecx,edx
       jne       near ptr M04_L08
M04_L00:
       mov       r14d,[rsp+70]
       test      r14d,r14d
       jl        near ptr M04_L09
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       edi,eax
       jge       short M04_L01
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,edi
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L01:
       sub       edi,eax
       js        near ptr M04_L10
       lea       ecx,[rdi+r14]
       cmp       ecx,[rbx+8]
       ja        near ptr M04_L10
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFB0F2F9400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       ebp,eax
       jge       short M04_L02
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,ebp
       mov       edx,eax
       call      qword ptr [7FFB0F3109C8]
       int       3
M04_L02:
       sub       ebp,eax
       js        near ptr M04_L11
       lea       ecx,[r14+rbp]
       cmp       ecx,[rsi+8]
       ja        near ptr M04_L11
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L03
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFB0F2F9320]
       test      eax,eax
       je        short M04_L03
       cmp       byte ptr [rsp+78],0
       jne       near ptr M04_L16
       mov       [rsp+70],r14d
       mov       [rsp+78],eax
       mov       rcx,rbx
       mov       edx,edi
       mov       r8,rsi
       mov       r9d,ebp
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L03:
       mov       rcx,[rbx]
       movzx     edx,word ptr [rcx]
       mov       r8d,r14d
       imul      r8,rdx
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       mov       r10d,edi
       imul      r10,rdx
       add       r10,rax
       lea       rax,[rsi+8]
       mov       r9,[rsi]
       mov       r9d,[r9+4]
       add       r9,0FFFFFFFFFFFFFFF0
       add       rax,r9
       mov       r9d,ebp
       imul      rdx,r9
       add       rdx,rax
       test      dword ptr [rcx],1000000
       jne       short M04_L04
       cmp       r8,14
       jne       near ptr M04_L15
       jmp       near ptr M04_L14
M04_L04:
       cmp       r8,4000
       ja        near ptr M04_L13
       jmp       near ptr M04_L12
M04_L05:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M04_L06:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L07:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFB0F2FB270]
       int       3
M04_L08:
       call      qword ptr [7FFB0F2F2830]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FDDB8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FC818]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L09:
       mov       rdx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rdx,[rdx]
       mov       ecx,r14d
       call      qword ptr [7FFB0F3109B0]
       int       3
M04_L10:
       call      qword ptr [7FFB0F2F25F8]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FCC70]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L11:
       call      qword ptr [7FFB0F2F25F8]
       mov       r14,rax
       call      qword ptr [7FFB0F2FCC68]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,r14
       call      qword ptr [7FFB0F2FB220]
       mov       rcx,r14
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
M04_L12:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2F96A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       je        near ptr M04_L05
       call      qword ptr [7FFB0F2E8028]; CORINFO_HELP_POLL_GC
       jmp       near ptr M04_L05
M04_L13:
       mov       rcx,rdx
       mov       rdx,r10
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L14:
       movups    xmm0,[r10]
       movups    xmm1,[r10+4]
       movups    [rdx],xmm0
       movups    [rdx+4],xmm1
       jmp       near ptr M04_L05
M04_L15:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFB0F2FC988]; Precode of System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M04_L05
M04_L16:
       call      qword ptr [7FFB0F2F2620]
       mov       rbx,rax
       call      qword ptr [7FFB0F2FD738]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB0F2FB2A0]
       mov       rcx,rbx
       call      qword ptr [7FFB0F2E7FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 748
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rsi,offset MT_System.Byte[]
       mov       rcx,rsi
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rbp,rbx
       mov       ebx,[rbx+8]
       test      rbp,rbp
       je        short M00_L02
       mov       r14d,[rbp+8]
       cmp       [rbp],rsi
       jne       short M00_L03
M00_L00:
       mov       rdx,r14
       cmp       rbp,rdi
       je        short M00_L01
       mov       edx,[rdi+8]
M00_L01:
       mov       r8d,ebx
       cmp       r14,r8
       jb        near ptr M00_L05
       cmp       rdx,r8
       jb        near ptr M00_L05
       lea       rcx,[rdi+10]
       lea       rdx,[rbp+10]
       call      qword ptr [7FFAB1E35818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L02:
       mov       ecx,257
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       rcx,rax
       call      qword ptr [7FFAB22E7C18]
       int       3
M00_L03:
       mov       rcx,rbp
       call      00007FFB119D9B60
       mov       edx,3003FFC
       bt        edx,eax
       jb        short M00_L04
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22E7C30]
       mov       rsi,rax
       mov       ecx,257
       mov       rdx,7FFAB1D74000
       call      qword ptr [7FFAB20B7738]
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbx
       call      qword ptr [7FFAB2205860]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L04:
       mov       rdx,[rbp]
       movzx     edx,word ptr [rdx]
       imul      r14,rdx
       jmp       near ptr M00_L00
M00_L05:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFAB22E7C48]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFAB20BF9A8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 301
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L11
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L11
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       short M01_L02
       cmp       r8,40
       jbe       short M01_L01
       cmp       r8,800
       jbe       near ptr M01_L07
M01_L00:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E366E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M01_L01:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L10
M01_L02:
       test      r8b,18
       je        short M01_L03
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L05
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L05
M01_L04:
       test      r8,r8
       jne       short M01_L06
M01_L05:
       vzeroupper
       ret
M01_L06:
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L05
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L05
M01_L07:
       cmp       r8,100
       jb        short M01_L08
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L08:
       mov       r9,r8
       shr       r9,6
M01_L09:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L09
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L01
M01_L10:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L05
M01_L11:
       cmp       rcx,rdx
       jne       near ptr M01_L00
       cmp       [rdx],dl
       jmp       near ptr M01_L05
; Total bytes of code 336
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       mov       edx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       r8d,esi
       lea       rcx,[rdi+10]
       mov       rdx,rbx
       call      qword ptr [7FFAB1E15818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,2F8DB0262A0
       jmp       short M00_L01
; Total bytes of code 92
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L11
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L11
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       short M01_L02
       cmp       r8,40
       jbe       short M01_L01
       cmp       r8,800
       jbe       near ptr M01_L07
M01_L00:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFAB1E166E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M01_L01:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L10
M01_L02:
       test      r8b,18
       je        short M01_L03
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L05
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L05
M01_L04:
       test      r8,r8
       jne       short M01_L06
M01_L05:
       vzeroupper
       ret
M01_L06:
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L05
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L05
M01_L07:
       cmp       r8,100
       jb        short M01_L08
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L08:
       mov       r9,r8
       shr       r9,6
M01_L09:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L09
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L01
M01_L10:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L05
M01_L11:
       cmp       rcx,rdx
       jne       near ptr M01_L00
       cmp       [rdx],dl
       jmp       near ptr M01_L05
; Total bytes of code 336
```

