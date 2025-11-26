# Ordinal vs OrdinalIgnoreCase




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Count | Mean       | Error    | StdDev   | Ratio | RatioSD | Code Size |
|----------------------------- |------ |-----------:|---------:|---------:|------:|--------:|----------:|
| Ordinal                      | 1000  | 4,469.4 ns | 83.05 ns | 77.69 ns |  1.00 |    0.02 |     967 B |
| OrdinalIgnoreCase            | 1000  |   793.9 ns |  4.62 ns |  4.32 ns |  0.18 |    0.00 |   1,162 B |
| OrdinalLongStrings           | 1000  | 9,485.8 ns | 80.18 ns | 66.95 ns |  2.12 |    0.04 |     975 B |
| OrdinalIgnoreCaseLongStrings | 1000  | 6,300.4 ns | 35.02 ns | 32.76 ns |  1.41 |    0.02 |   1,242 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Ordinal()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       xor       esi,esi
       mov       edi,[rbx+8]
       test      edi,edi
       jle       short M00_L01
M00_L00:
       mov       rcx,[rbx+rsi*8+10]
       mov       edx,[rcx+8]
       add       rcx,0C
       mov       r8,21B0552ACE4
       mov       r9d,7
       call      qword ptr [7FFB0B5159F8]; System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       test      eax,eax
       jge       short M00_L02
       inc       esi
       cmp       edi,esi
       jg        short M00_L00
M00_L01:
       mov       eax,0FFFFFFFF
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       eax,esi
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 87
```
```assembly
; System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,78
       vmovaps   [rsp+60],xmm6
       vmovaps   [rsp+50],xmm7
       vmovaps   [rsp+40],xmm8
       vmovaps   [rsp+30],xmm9
       mov       rdi,rcx
       mov       rsi,r8
       mov       r8d,edx
       mov       ebx,r9d
       test      ebx,ebx
       je        short M01_L01
       lea       ebp,[rbx-1]
       test      ebp,ebp
       je        near ptr M01_L02
       xor       r14d,r14d
       movzx     r15d,word ptr [rsi]
       mov       r13d,r8d
       sub       r13d,ebp
       cmp       r13d,8
       jge       near ptr M01_L06
       add       rsi,2
       test      r13d,r13d
       jg        near ptr M01_L04
M01_L00:
       mov       eax,0FFFFFFFF
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L01:
       xor       eax,eax
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L02:
       movsx     rdx,word ptr [rsi]
       movzx     ecx,dx
       dec       ecx
       cmp       ecx,0FE
       jae       short M01_L03
       mov       rcx,rdi
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       jmp       qword ptr [7FFB0B207738]; System.PackedSpanHelpers.IndexOf[[System.SpanHelpers+DontNegate`1[[System.Int16, System.Private.CoreLib]], System.Private.CoreLib],[System.PackedSpanHelpers+NopTransform, System.Private.CoreLib]](Int16 ByRef, Int16, Int32)
M01_L03:
       mov       rcx,rdi
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       jmp       qword ptr [7FFB0B2E4AB0]; System.SpanHelpers.NonPackedIndexOfValueType[[System.Int16, System.Private.CoreLib],[System.SpanHelpers+DontNegate`1[[System.Int16, System.Private.CoreLib]], System.Private.CoreLib]](Int16 ByRef, Int16, Int32)
M01_L04:
       lea       rcx,[rdi+r14*2]
       movsx     rdx,r15w
       mov       r8d,r13d
       call      qword ptr [7FFB0B2E4AB0]; System.SpanHelpers.NonPackedIndexOfValueType[[System.Int16, System.Private.CoreLib],[System.SpanHelpers+DontNegate`1[[System.Int16, System.Private.CoreLib]], System.Private.CoreLib]](Int16 ByRef, Int16, Int32)
       test      eax,eax
       jl        near ptr M01_L00
       sub       r13d,eax
       mov       ecx,eax
       add       r14,rcx
       test      r13d,r13d
       jle       near ptr M01_L00
       lea       rcx,[rdi+r14*2+2]
       mov       r8d,ebp
       add       r8,r8
       mov       rdx,rsi
       call      qword ptr [7FFB0B06FB70]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       jne       short M01_L05
       dec       r13d
       inc       r14
       test      r13d,r13d
       jg        short M01_L04
       jmp       near ptr M01_L00
M01_L05:
       mov       eax,r14d
       jmp       near ptr M01_L28
M01_L06:
       lea       ecx,[r13-10]
       test      ecx,ecx
       jl        near ptr M01_L18
       movsxd    r12,ebp
       movzx     ecx,word ptr [rsi+r12*2]
       jmp       short M01_L08
M01_L07:
       dec       r12
       movzx     ecx,word ptr [rsi+r12*2]
M01_L08:
       cmp       ecx,r15d
       jne       short M01_L09
       cmp       r12,1
       jg        short M01_L07
M01_L09:
       vmovd     xmm6,r15d
       vpbroadcastw ymm6,xmm6
       vmovd     xmm7,ecx
       vpbroadcastw ymm7,xmm7
       mov       ebp,r13d
       add       rbp,0FFFFFFFFFFFFFFF0
M01_L10:
       vpcmpeqw  ymm0,ymm6,[rdi+r14*2]
       lea       rcx,[r14+r12]
       vpcmpeqw  ymm1,ymm7,[rdi+rcx*2]
       vpand     ymm0,ymm1,ymm0
       vptest    ymm0,ymm0
       jne       short M01_L12
       jmp       short M01_L16
M01_L11:
       cmp       r14,rbp
       jle       short M01_L10
       mov       r14,rbp
       jmp       short M01_L10
M01_L12:
       vpmovmskb r15d,ymm0
       xor       ecx,ecx
       tzcnt     ecx,r15d
       shr       ecx,1
       mov       eax,ecx
       cmp       ebx,2
       je        short M01_L17
M01_L13:
       mov       [rsp+28],rax
       lea       rcx,[r14+rax]
       lea       rcx,[rdi+rcx*2]
       mov       r8d,ebx
       add       r8,r8
       mov       rdx,rsi
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFB0B06FB70]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
       mov       rax,[rsp+28]
       je        short M01_L15
       jmp       short M01_L17
M01_L14:
       xor       ecx,ecx
       tzcnt     ecx,r15d
       shr       ecx,1
       mov       eax,ecx
       jmp       short M01_L13
M01_L15:
       blsr      ecx,r15d
       blsr      r15d,ecx
       jne       short M01_L14
M01_L16:
       add       r14,10
       mov       eax,r13d
       cmp       r14,rax
       je        near ptr M01_L00
       jmp       near ptr M01_L11
M01_L17:
       add       eax,r14d
       jmp       near ptr M01_L28
M01_L18:
       movsxd    r12,ebp
       movzx     ecx,word ptr [rsi+r12*2]
       mov       rbp,r12
       jmp       short M01_L20
M01_L19:
       dec       rbp
       movzx     ecx,word ptr [rsi+rbp*2]
M01_L20:
       cmp       ecx,r15d
       jne       short M01_L21
       cmp       rbp,1
       jg        short M01_L19
M01_L21:
       vmovd     xmm6,r15d
       vpbroadcastw xmm6,xmm6
       vmovd     xmm7,ecx
       vpbroadcastw xmm7,xmm7
       mov       r15d,r13d
       add       r15,0FFFFFFFFFFFFFFF8
M01_L22:
       vpcmpeqw  xmm0,xmm6,[rdi+r14*2]
       lea       rcx,[r14+rbp]
       vpcmpeqw  xmm1,xmm7,[rdi+rcx*2]
       vpand     xmm0,xmm1,xmm0
       vptest    xmm0,xmm0
       jne       short M01_L24
       jmp       short M01_L26
M01_L23:
       cmp       r14,r15
       jle       short M01_L22
       mov       r14,r15
       jmp       short M01_L22
M01_L24:
       vpmovmskb r12d,xmm0
M01_L25:
       xor       ecx,ecx
       tzcnt     ecx,r12d
       shr       ecx,1
       mov       eax,ecx
       mov       [rsp+20],rax
       cmp       ebx,2
       je        short M01_L27
       lea       rcx,[r14+rax]
       lea       rcx,[rdi+rcx*2]
       mov       r8d,ebx
       add       r8,r8
       mov       rdx,rsi
       call      qword ptr [7FFB0B06FB70]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       mov       rax,[rsp+20]
       jne       short M01_L27
       blsr      eax,r12d
       blsr      r12d,eax
       jne       short M01_L25
M01_L26:
       add       r14,8
       mov       eax,r13d
       cmp       r14,rax
       je        near ptr M01_L00
       jmp       short M01_L23
M01_L27:
       add       eax,r14d
M01_L28:
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 880
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.OrdinalIgnoreCase()
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,88
       vmovaps   [rsp+70],xmm6
       vmovaps   [rsp+60],xmm7
       vmovaps   [rsp+50],xmm8
       vmovaps   [rsp+40],xmm9
       mov       rbx,[rcx+8]
       xor       esi,esi
       mov       edi,[rbx+8]
       cmp       edi,esi
       jle       short M00_L02
M00_L00:
       mov       rdi,[rbx+rsi*8+10]
       mov       ebp,[rdi+8]
       add       rdi,0C
       mov       r14,2724A56ACE4
       cmp       ebp,7
       jge       short M00_L03
M00_L01:
       inc       esi
       mov       edi,[rbx+8]
       cmp       edi,esi
       jg        short M00_L00
M00_L02:
       mov       eax,0FFFFFFFF
       vzeroupper
       vmovaps   xmm6,[rsp+70]
       vmovaps   xmm7,[rsp+60]
       vmovaps   xmm8,[rsp+50]
       vmovaps   xmm9,[rsp+40]
       add       rsp,88
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M00_L03:
       add       ebp,0FFFFFFFA
       xor       r15d,r15d
       cmp       ebp,8
       jl        near ptr M00_L09
       mov       eax,65
       mov       r13d,6
M00_L04:
       cmp       eax,66
       je        near ptr M00_L12
M00_L05:
       lea       ecx,[rbp-10]
       test      ecx,ecx
       jl        near ptr M00_L16
       vbroadcastss ymm6,dword ptr [7FFB0B13BCA0]
       vmovd     xmm7,eax
       vpbroadcastw ymm7,xmm7
       movsxd    r12,ebp
       add       r12,0FFFFFFFFFFFFFFF0
M00_L06:
       vmovups   ymm0,[rdi+r15*2]
       vpor      ymm0,ymm0,[7FFB0B13BCC0]
       vpcmpeqw  ymm0,ymm0,ymm6
       lea       rcx,[r15+r13]
       vmovups   ymm1,[rdi+rcx*2]
       vpor      ymm1,ymm1,[7FFB0B13BCC0]
       vpcmpeqw  ymm1,ymm1,ymm7
       vpand     ymm0,ymm1,ymm0
       vptest    ymm0,ymm0
       je        near ptr M00_L15
       vpmovmskb eax,ymm0
M00_L07:
       mov       [rsp+2C],eax
       xor       ecx,ecx
       tzcnt     ecx,eax
       shr       ecx,1
       mov       r10d,ecx
       mov       [rsp+20],r10
       lea       rcx,[r15+r10]
       lea       rcx,[rdi+rcx*2]
       mov       rdx,r14
       mov       r8d,7
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFB0B545A10]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
       je        near ptr M00_L14
       mov       r12d,r15d
       add       r12d,[rsp+20]
M00_L08:
       test      r12d,r12d
       jl        near ptr M00_L01
       jmp       near ptr M00_L23
M00_L09:
       lea       rcx,[rdi+r15*2]
       mov       edx,66
       mov       r8d,ebp
       call      qword ptr [7FFB0B547F18]
       test      eax,eax
       jl        near ptr M00_L01
       sub       ebp,eax
       test      ebp,ebp
       jle       near ptr M00_L01
       mov       ecx,eax
       add       r15,rcx
       lea       rcx,[rdi+r15*2+2]
       lea       rdx,[r14+2]
       mov       r8d,6
       call      qword ptr [7FFB0B545A10]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       test      eax,eax
       jne       short M00_L10
       dec       ebp
       inc       r15
       test      ebp,ebp
       jg        short M00_L09
       jmp       near ptr M00_L01
M00_L10:
       mov       r12d,r15d
       test      r12d,r12d
       jl        near ptr M00_L01
       jmp       near ptr M00_L23
M00_L11:
       movzx     ecx,word ptr [r14+r13*2-2]
       cmp       ecx,7F
       jg        near ptr M00_L05
       dec       r13
       or        ecx,20
       movzx     eax,cx
       jmp       near ptr M00_L04
M00_L12:
       cmp       r13,1
       jg        short M00_L11
       jmp       near ptr M00_L05
M00_L13:
       cmp       r15,r12
       jle       near ptr M00_L06
       mov       r15,r12
       jmp       near ptr M00_L06
M00_L14:
       blsr      ecx,[rsp+2C]
       blsr      eax,ecx
       mov       ecx,eax
       test      ecx,ecx
       mov       eax,ecx
       jne       near ptr M00_L07
M00_L15:
       add       r15,10
       movsxd    rcx,ebp
       cmp       r15,rcx
       je        near ptr M00_L01
       jmp       short M00_L13
M00_L16:
       vbroadcastss xmm6,dword ptr [7FFB0B13BCA0]
       vmovd     xmm7,eax
       vpbroadcastw xmm7,xmm7
       movsxd    r12,ebp
       add       r12,0FFFFFFFFFFFFFFF8
M00_L17:
       vmovups   xmm0,[rdi+r15*2]
       vpor      xmm0,xmm0,[7FFB0B13BCC0]
       vpcmpeqw  xmm0,xmm0,xmm6
       lea       rcx,[r15+r13]
       vmovups   xmm1,[rdi+rcx*2]
       vpor      xmm1,xmm1,[7FFB0B13BCC0]
       vpcmpeqw  xmm1,xmm1,xmm7
       vpand     xmm0,xmm1,xmm0
       vptest    xmm0,xmm0
       jne       short M00_L19
       jmp       short M00_L21
M00_L18:
       cmp       r15,r12
       jle       short M00_L17
       mov       r15,r12
       jmp       short M00_L17
M00_L19:
       vpmovmskb eax,xmm0
M00_L20:
       mov       [rsp+3C],eax
       xor       ecx,ecx
       tzcnt     ecx,eax
       shr       ecx,1
       mov       r10d,ecx
       mov       [rsp+30],r10
       lea       rcx,[r15+r10]
       lea       rcx,[rdi+rcx*2]
       mov       rdx,r14
       mov       r8d,7
       call      qword ptr [7FFB0B545A10]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       test      eax,eax
       jne       short M00_L22
       blsr      ecx,[rsp+3C]
       blsr      eax,ecx
       mov       ecx,eax
       test      ecx,ecx
       mov       eax,ecx
       jne       short M00_L20
M00_L21:
       add       r15,8
       movsxd    rcx,ebp
       cmp       r15,rcx
       je        near ptr M00_L01
       jmp       short M00_L18
M00_L22:
       mov       r12d,r15d
       add       r12d,[rsp+30]
       jmp       near ptr M00_L08
M00_L23:
       mov       eax,esi
       vzeroupper
       vmovaps   xmm6,[rsp+70]
       vmovaps   xmm7,[rsp+60]
       vmovaps   xmm8,[rsp+50]
       vmovaps   xmm9,[rsp+40]
       add       rsp,88
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 804
```
```assembly
; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       push      rbx
       sub       rsp,20
       mov       r9d,r8d
       xor       r8d,r8d
       cmp       r9d,4
       jb        short M01_L01
M01_L00:
       mov       r10,[rcx+r8]
       mov       r11,[rdx+r8]
       mov       rax,r10
       or        rax,r11
       mov       rbx,rax
       shr       rbx,20
       or        ebx,eax
       test      ebx,0FF80FF80
       jne       near ptr M01_L07
       xor       r11,r10
       shl       r11,2
       mov       rax,5000500050005
       add       rax,r10
       mov       r10,0A000A000A000A0
       or        rax,r10
       mov       r10,1A001A001A001A
       add       rax,r10
       mov       r10,0FF7FFF7FFF7FFF7F
       or        rax,r10
       test      rax,r11
       jne       near ptr M01_L06
       add       r8,8
       add       r9d,0FFFFFFFC
       cmp       r9d,4
       jae       short M01_L00
M01_L01:
       cmp       r9d,2
       jb        short M01_L02
       mov       eax,[rcx+r8]
       mov       r10d,[rdx+r8]
       mov       r11d,eax
       or        r11d,r10d
       test      r11d,0FF80FF80
       jne       short M01_L05
       xor       r10d,eax
       shl       r10d,2
       add       eax,50005
       or        eax,0A000A0
       add       eax,1A001A
       or        eax,0FF7FFF7F
       test      eax,r10d
       jne       short M01_L06
       add       r8,4
       add       r9d,0FFFFFFFE
M01_L02:
       test      r9d,r9d
       je        short M01_L03
       movzx     eax,word ptr [rcx+r8]
       movzx     r10d,word ptr [rdx+r8]
       mov       r11d,eax
       or        r11d,r10d
       cmp       r11d,7F
       ja        short M01_L05
       cmp       eax,r10d
       jne       short M01_L04
M01_L03:
       mov       eax,1
       add       rsp,20
       pop       rbx
       ret
M01_L04:
       or        eax,20
       lea       ecx,[rax-61]
       cmp       ecx,19
       ja        short M01_L06
       or        r10d,20
       cmp       eax,r10d
       sete      bl
       movzx     ebx,bl
       jmp       short M01_L09
M01_L05:
       test      eax,0FF80FF80
       je        short M01_L06
       test      r10d,0FF80FF80
       jne       short M01_L08
M01_L06:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M01_L07:
       mov       rax,0FF80FF80FF80FF80
       test      rax,r10
       je        short M01_L06
       mov       rax,0FF80FF80FF80FF80
       test      rax,r11
       je        short M01_L06
M01_L08:
       add       rcx,r8
       add       r8,rdx
       mov       edx,r9d
       call      qword ptr [7FFB0B54C1C8]
       test      eax,eax
       sete      bl
       movzx     ebx,bl
M01_L09:
       movzx     eax,bl
       add       rsp,20
       pop       rbx
       ret
; Total bytes of code 358
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.OrdinalLongStrings()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+10]
       xor       esi,esi
       mov       edi,[rbx+8]
       test      edi,edi
       jle       short M00_L01
M00_L00:
       mov       rcx,[rbx+rsi*8+10]
       mov       edx,[rcx+8]
       add       rcx,0C
       mov       r8,2518550ACE4
       mov       r9d,7
       call      qword ptr [7FFB0B525920]; System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       test      eax,eax
       jge       short M00_L02
       inc       esi
       cmp       edi,esi
       jg        short M00_L00
M00_L01:
       mov       eax,0FFFFFFFF
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       eax,esi
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 87
```
```assembly
; System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,78
       vmovaps   [rsp+60],xmm6
       vmovaps   [rsp+50],xmm7
       vmovaps   [rsp+40],xmm8
       vmovaps   [rsp+30],xmm9
       mov       rbx,rcx
       mov       rdi,r8
       mov       r8d,edx
       mov       esi,r9d
       test      esi,esi
       je        near ptr M01_L05
       lea       ebp,[rsi-1]
       test      ebp,ebp
       je        near ptr M01_L06
       xor       r14d,r14d
       movzx     r15d,word ptr [rdi]
       sub       r8d,ebp
       mov       r13d,r8d
       cmp       r13d,8
       jl        near ptr M01_L08
       lea       ecx,[r13-10]
       test      ecx,ecx
       jl        near ptr M01_L18
       movsxd    r12,ebp
       movzx     ecx,word ptr [rdi+r12*2]
M01_L00:
       cmp       ecx,r15d
       je        near ptr M01_L12
M01_L01:
       vmovd     xmm6,r15d
       vpbroadcastw ymm6,xmm6
       vmovd     xmm7,ecx
       vpbroadcastw ymm7,xmm7
       mov       r13d,r13d
       lea       rbp,[r13-10]
M01_L02:
       vpcmpeqw  ymm0,ymm6,[rbx+r14*2]
       lea       rcx,[r14+r12]
       vpcmpeqw  ymm1,ymm7,[rbx+rcx*2]
       vpand     ymm0,ymm1,ymm0
       vptest    ymm0,ymm0
       jne       near ptr M01_L13
M01_L03:
       add       r14,10
       cmp       r14,r13
       je        short M01_L04
       cmp       r14,rbp
       jle       short M01_L02
       mov       r14,rbp
       jmp       short M01_L02
M01_L04:
       mov       eax,0FFFFFFFF
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L05:
       xor       eax,eax
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L06:
       movsx     rdx,word ptr [rdi]
       movzx     ecx,dx
       dec       ecx
       cmp       ecx,0FE
       jae       short M01_L07
       mov       rcx,rbx
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       jmp       qword ptr [7FFB0B217738]; System.PackedSpanHelpers.IndexOf[[System.SpanHelpers+DontNegate`1[[System.Int16, System.Private.CoreLib]], System.Private.CoreLib],[System.PackedSpanHelpers+NopTransform, System.Private.CoreLib]](Int16 ByRef, Int16, Int32)
M01_L07:
       mov       rcx,rbx
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       jmp       qword ptr [7FFB0B2F4AB0]; System.SpanHelpers.NonPackedIndexOfValueType[[System.Int16, System.Private.CoreLib],[System.SpanHelpers+DontNegate`1[[System.Int16, System.Private.CoreLib]], System.Private.CoreLib]](Int16 ByRef, Int16, Int32)
M01_L08:
       add       rdi,2
       test      r13d,r13d
       jle       near ptr M01_L04
M01_L09:
       lea       rcx,[rbx+r14*2]
       movsx     rdx,r15w
       mov       r8d,r13d
       call      qword ptr [7FFB0B2F4AB0]; System.SpanHelpers.NonPackedIndexOfValueType[[System.Int16, System.Private.CoreLib],[System.SpanHelpers+DontNegate`1[[System.Int16, System.Private.CoreLib]], System.Private.CoreLib]](Int16 ByRef, Int16, Int32)
       test      eax,eax
       jl        near ptr M01_L04
       sub       r13d,eax
       mov       ecx,eax
       add       r14,rcx
       test      r13d,r13d
       jle       near ptr M01_L04
       lea       rcx,[rbx+r14*2+2]
       mov       r8d,ebp
       add       r8,r8
       mov       rdx,rdi
       call      qword ptr [7FFB0B07FB70]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       jne       short M01_L10
       dec       r13d
       inc       r14
       test      r13d,r13d
       jg        short M01_L09
       jmp       near ptr M01_L04
M01_L10:
       mov       eax,r14d
       jmp       near ptr M01_L28
M01_L11:
       dec       r12
       movzx     ecx,word ptr [rdi+r12*2]
       jmp       near ptr M01_L00
M01_L12:
       cmp       r12,1
       jg        short M01_L11
       jmp       near ptr M01_L01
M01_L13:
       vpmovmskb r15d,ymm0
       xor       ecx,ecx
       tzcnt     ecx,r15d
       shr       ecx,1
       mov       eax,ecx
       cmp       esi,2
       je        short M01_L17
M01_L14:
       mov       [rsp+28],rax
       lea       rcx,[r14+rax]
       lea       rcx,[rbx+rcx*2]
       mov       r8d,esi
       add       r8,r8
       mov       rdx,rdi
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFB0B07FB70]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
       mov       rax,[rsp+28]
       je        short M01_L16
       jmp       short M01_L17
M01_L15:
       xor       ecx,ecx
       tzcnt     ecx,r15d
       shr       ecx,1
       mov       eax,ecx
       jmp       short M01_L14
M01_L16:
       blsr      ecx,r15d
       blsr      r15d,ecx
       jne       short M01_L15
       jmp       near ptr M01_L03
M01_L17:
       add       eax,r14d
       jmp       near ptr M01_L28
M01_L18:
       movsxd    r12,ebp
       movzx     ecx,word ptr [rdi+r12*2]
       mov       rbp,r12
       jmp       short M01_L20
M01_L19:
       dec       rbp
       movzx     ecx,word ptr [rdi+rbp*2]
M01_L20:
       cmp       ecx,r15d
       jne       short M01_L21
       cmp       rbp,1
       jg        short M01_L19
M01_L21:
       vmovd     xmm6,r15d
       vpbroadcastw xmm6,xmm6
       vmovd     xmm7,ecx
       vpbroadcastw xmm7,xmm7
       mov       r13d,r13d
       lea       r15,[r13-8]
M01_L22:
       vpcmpeqw  xmm0,xmm6,[rbx+r14*2]
       lea       rcx,[r14+rbp]
       vpcmpeqw  xmm1,xmm7,[rbx+rcx*2]
       vpand     xmm0,xmm1,xmm0
       vptest    xmm0,xmm0
       jne       short M01_L24
       jmp       short M01_L26
M01_L23:
       cmp       r14,r15
       jle       short M01_L22
       mov       r14,r15
       jmp       short M01_L22
M01_L24:
       vpmovmskb r12d,xmm0
M01_L25:
       xor       ecx,ecx
       tzcnt     ecx,r12d
       shr       ecx,1
       mov       eax,ecx
       mov       [rsp+20],rax
       cmp       esi,2
       je        short M01_L27
       lea       rcx,[r14+rax]
       lea       rcx,[rbx+rcx*2]
       mov       r8d,esi
       add       r8,r8
       mov       rdx,rdi
       call      qword ptr [7FFB0B07FB70]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       mov       rax,[rsp+20]
       jne       short M01_L27
       blsr      ecx,r12d
       blsr      r12d,ecx
       jne       short M01_L25
M01_L26:
       add       r14,8
       cmp       r14,r13
       je        near ptr M01_L04
       jmp       short M01_L23
M01_L27:
       add       eax,r14d
M01_L28:
       vzeroupper
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 888
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.OrdinalIgnoreCaseLongStrings()
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,0A8
       vmovaps   [rsp+90],xmm6
       vmovaps   [rsp+80],xmm7
       vmovaps   [rsp+70],xmm8
       vmovaps   [rsp+60],xmm9
       vmovaps   [rsp+50],xmm10
       vmovaps   [rsp+40],xmm11
       mov       rbx,[rcx+10]
       vbroadcastss ymm6,dword ptr [7FFB0B12BDE0]
       xor       esi,esi
       cmp       [rbx+8],esi
       jg        near ptr M00_L05
M00_L00:
       mov       eax,0FFFFFFFF
       vzeroupper
       vmovaps   xmm6,[rsp+90]
       vmovaps   xmm7,[rsp+80]
       vmovaps   xmm8,[rsp+70]
       vmovaps   xmm9,[rsp+60]
       vmovaps   xmm10,[rsp+50]
       vmovaps   xmm11,[rsp+40]
       add       rsp,0A8
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M00_L01:
       vpmovmskb eax,ymm0
M00_L02:
       mov       [rsp+2C],eax
       xor       ecx,ecx
       tzcnt     ecx,eax
       shr       ecx,1
       mov       r10d,ecx
       mov       [rsp+20],r10
       lea       rcx,[r15+r10]
       lea       rcx,[rdi+rcx*2]
       mov       rdx,r14
       mov       r8d,7
       vextractf128 xmm9,ymm6,1
       vextractf128 xmm10,ymm7,1
       vextractf128 xmm11,ymm8,1
       call      qword ptr [7FFB0B535A10]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm9,1
       vinsertf128 ymm7,ymm7,xmm10,1
       vinsertf128 ymm8,ymm8,xmm11,1
       je        near ptr M00_L14
       mov       ebp,r15d
       add       ebp,[rsp+20]
M00_L03:
       test      ebp,ebp
       jge       near ptr M00_L22
M00_L04:
       inc       esi
       cmp       [rbx+8],esi
       jle       near ptr M00_L00
M00_L05:
       mov       rdi,[rbx+rsi*8+10]
       mov       ebp,[rdi+8]
       add       rdi,0C
       mov       r14,25A6C6EACE4
       cmp       ebp,7
       jl        short M00_L04
       add       ebp,0FFFFFFFA
       xor       r15d,r15d
       cmp       ebp,8
       jl        short M00_L10
       mov       eax,65
       mov       r13d,6
M00_L06:
       cmp       eax,66
       je        near ptr M00_L13
M00_L07:
       lea       ecx,[rbp-10]
       test      ecx,ecx
       jl        near ptr M00_L15
       vbroadcastss ymm7,dword ptr [7FFB0B12BDE4]
       vmovd     xmm8,eax
       vpbroadcastw ymm8,xmm8
       movsxd    r12,ebp
       lea       rbp,[r12-10]
M00_L08:
       vpor      ymm0,ymm6,[rdi+r15*2]
       vpcmpeqw  ymm0,ymm0,ymm7
       lea       rcx,[r15+r13]
       vpor      ymm1,ymm6,[rdi+rcx*2]
       vpcmpeqw  ymm1,ymm1,ymm8
       vpand     ymm0,ymm1,ymm0
       vptest    ymm0,ymm0
       jne       near ptr M00_L01
M00_L09:
       add       r15,10
       cmp       r15,r12
       je        near ptr M00_L04
       cmp       r15,rbp
       jle       short M00_L08
       mov       r15,rbp
       jmp       short M00_L08
M00_L10:
       lea       rcx,[rdi+r15*2]
       mov       edx,66
       mov       r8d,ebp
       vextractf128 xmm9,ymm6,1
       call      qword ptr [7FFB0B537F18]
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm9,1
       jl        near ptr M00_L04
       sub       ebp,eax
       test      ebp,ebp
       jle       near ptr M00_L04
       mov       ecx,eax
       add       r15,rcx
       lea       rcx,[rdi+r15*2+2]
       lea       rdx,[r14+2]
       mov       r8d,6
       vextractf128 xmm9,ymm6,1
       call      qword ptr [7FFB0B535A10]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm9,1
       jne       short M00_L11
       dec       ebp
       inc       r15
       test      ebp,ebp
       jg        short M00_L10
       jmp       near ptr M00_L04
M00_L11:
       mov       ebp,r15d
       test      ebp,ebp
       jl        near ptr M00_L04
       jmp       near ptr M00_L22
M00_L12:
       movzx     ecx,word ptr [r14+r13*2-2]
       cmp       ecx,7F
       jg        near ptr M00_L07
       dec       r13
       or        ecx,20
       movzx     eax,cx
       jmp       near ptr M00_L06
M00_L13:
       cmp       r13,1
       jg        short M00_L12
       jmp       near ptr M00_L07
M00_L14:
       blsr      ecx,[rsp+2C]
       blsr      eax,ecx
       mov       ecx,eax
       test      ecx,ecx
       mov       eax,ecx
       jne       near ptr M00_L02
       jmp       near ptr M00_L09
M00_L15:
       vbroadcastss xmm7,dword ptr [7FFB0B12BDE4]
       vmovd     xmm8,eax
       vpbroadcastw xmm8,xmm8
       movsxd    r12,ebp
       lea       rbp,[r12-8]
M00_L16:
       vmovups   xmm0,[rdi+r15*2]
       vpor      xmm0,xmm0,[7FFB0B12BDF0]
       vpcmpeqw  xmm0,xmm0,xmm7
       lea       rcx,[r15+r13]
       vmovups   xmm1,[rdi+rcx*2]
       vpor      xmm1,xmm1,[7FFB0B12BDF0]
       vpcmpeqw  xmm1,xmm1,xmm8
       vpand     xmm0,xmm1,xmm0
       vptest    xmm0,xmm0
       jne       short M00_L18
       jmp       short M00_L20
M00_L17:
       cmp       r15,rbp
       jle       short M00_L16
       mov       r15,rbp
       jmp       short M00_L16
M00_L18:
       vpmovmskb eax,xmm0
M00_L19:
       mov       [rsp+3C],eax
       xor       ecx,ecx
       tzcnt     ecx,eax
       shr       ecx,1
       mov       r10d,ecx
       mov       [rsp+30],r10
       lea       rcx,[r15+r10]
       lea       rcx,[rdi+rcx*2]
       mov       rdx,r14
       mov       r8d,7
       vextractf128 xmm9,ymm6,1
       call      qword ptr [7FFB0B535A10]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm9,1
       jne       short M00_L21
       blsr      ecx,[rsp+3C]
       blsr      eax,ecx
       mov       ecx,eax
       test      ecx,ecx
       mov       eax,ecx
       jne       short M00_L19
M00_L20:
       add       r15,8
       cmp       r15,r12
       je        near ptr M00_L04
       jmp       short M00_L17
M00_L21:
       mov       ebp,r15d
       add       ebp,[rsp+30]
       jmp       near ptr M00_L03
M00_L22:
       mov       eax,esi
       vzeroupper
       vmovaps   xmm6,[rsp+90]
       vmovaps   xmm7,[rsp+80]
       vmovaps   xmm8,[rsp+70]
       vmovaps   xmm9,[rsp+60]
       vmovaps   xmm10,[rsp+50]
       vmovaps   xmm11,[rsp+40]
       add       rsp,0A8
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 884
```
```assembly
; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       push      rbx
       sub       rsp,20
       mov       r9d,r8d
       xor       r8d,r8d
       cmp       r9d,4
       jb        short M01_L01
M01_L00:
       mov       r10,[rcx+r8]
       mov       r11,[rdx+r8]
       mov       rax,r10
       or        rax,r11
       mov       rbx,rax
       shr       rbx,20
       or        ebx,eax
       test      ebx,0FF80FF80
       jne       near ptr M01_L07
       xor       r11,r10
       shl       r11,2
       mov       rax,5000500050005
       add       rax,r10
       mov       r10,0A000A000A000A0
       or        rax,r10
       mov       r10,1A001A001A001A
       add       rax,r10
       mov       r10,0FF7FFF7FFF7FFF7F
       or        rax,r10
       test      rax,r11
       jne       near ptr M01_L06
       add       r8,8
       add       r9d,0FFFFFFFC
       cmp       r9d,4
       jae       short M01_L00
M01_L01:
       cmp       r9d,2
       jb        short M01_L02
       mov       eax,[rcx+r8]
       mov       r10d,[rdx+r8]
       mov       r11d,eax
       or        r11d,r10d
       test      r11d,0FF80FF80
       jne       short M01_L05
       xor       r10d,eax
       shl       r10d,2
       add       eax,50005
       or        eax,0A000A0
       add       eax,1A001A
       or        eax,0FF7FFF7F
       test      eax,r10d
       jne       short M01_L06
       add       r8,4
       add       r9d,0FFFFFFFE
M01_L02:
       test      r9d,r9d
       je        short M01_L03
       movzx     eax,word ptr [rcx+r8]
       movzx     r10d,word ptr [rdx+r8]
       mov       r11d,eax
       or        r11d,r10d
       cmp       r11d,7F
       ja        short M01_L05
       cmp       eax,r10d
       jne       short M01_L04
M01_L03:
       mov       eax,1
       add       rsp,20
       pop       rbx
       ret
M01_L04:
       or        eax,20
       lea       ecx,[rax-61]
       cmp       ecx,19
       ja        short M01_L06
       or        r10d,20
       cmp       eax,r10d
       sete      bl
       movzx     ebx,bl
       jmp       short M01_L09
M01_L05:
       test      eax,0FF80FF80
       je        short M01_L06
       test      r10d,0FF80FF80
       jne       short M01_L08
M01_L06:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M01_L07:
       mov       rax,0FF80FF80FF80FF80
       test      rax,r10
       je        short M01_L06
       mov       rax,0FF80FF80FF80FF80
       test      rax,r11
       je        short M01_L06
M01_L08:
       add       rcx,r8
       add       r8,rdx
       mov       edx,r9d
       call      qword ptr [7FFB0B53C1C8]
       test      eax,eax
       sete      bl
       movzx     ebx,bl
M01_L09:
       movzx     eax,bl
       add       rsp,20
       pop       rbx
       ret
; Total bytes of code 358
```

