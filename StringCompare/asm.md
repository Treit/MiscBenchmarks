## .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
```assembly
; Test.Benchmark.Ordinal()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rsi,[rcx+8]
       xor       edi,edi
       mov       ebx,[rsi+8]
       test      ebx,ebx
       jle       short M00_L01
       mov       r9,267DA819FC0
       mov       rbp,[r9]
M00_L00:
       movsxd    r9,edi
       mov       rcx,[rsi+r9*8+10]
       mov       dword ptr [rsp+20],4
       mov       r9d,[rcx+8]
       mov       rdx,rbp
       xor       r8d,r8d
       call      System.String.IndexOf(System.String, Int32, Int32, System.StringComparison)
       test      eax,eax
       jge       short M00_L02
       inc       edi
       cmp       ebx,edi
       jg        short M00_L00
M00_L01:
       mov       eax,0FFFFFFFF
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       eax,edi
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 100
```
```assembly
; System.String.IndexOf(System.String, Int32, Int32, System.StringComparison)
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
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rbp+0FFA0],xmm4
       vmovdqa   xmmword ptr [rbp+0FFB0],xmm4
       mov       rsi,rcx
       mov       rdi,rdx
       mov       ebx,r8d
       mov       r14d,r9d
       mov       r15d,[rbp+30]
       lea       rcx,[rbp+0FF60]
       mov       rdx,r10
       call      CORINFO_HELP_INIT_PINVOKE_FRAME
       mov       rax,rsp
       mov       [rbp+0FF80],rax
       mov       rax,rbp
       mov       [rbp+0FF90],rax
       cmp       r15d,5
       ja        near ptr M01_L14
       mov       eax,r15d
       lea       rdx,[7FFB6828BA88]
       mov       edx,[rdx+rax*4]
       lea       rcx,[7FFB6829B849]
       add       rdx,rcx
       jmp       rdx
M01_L00:
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
       cmp       r15d,5
       sete      r12b
       movzx     r12d,r12b
       test      rsi,rsi
       je        short M01_L01
       test      rdi,rdi
       je        near ptr M01_L10
       mov       eax,ebx
       mov       edx,r14d
       add       rax,rdx
       mov       edx,[rsi+8]
       cmp       rax,rdx
       ja        near ptr M01_L11
       add       rsi,0C
       mov       eax,ebx
       lea       rax,[rsi+rax*2]
       jmp       short M01_L03
M01_L01:
       mov       ecx,27
       call      System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument)
       int       3
       call      System.Globalization.CultureInfo.get_CurrentCulture()
       mov       r13,[rax]
       mov       rcx,offset MT_System.Globalization.CultureInfo
       cmp       r13,rcx
       jne       near ptr M01_L09
       mov       rcx,rax
       call      qword ptr [7FFB68295C90]
M01_L02:
       mov       [rsp+20],r14d
       and       r15d,1
       mov       [rsp+28],r15d
       mov       rcx,rax
       mov       rdx,rsi
       mov       r8,rdi
       mov       r9d,ebx
       cmp       [rcx],ecx
       call      System.Globalization.CompareInfo.IndexOf(System.String, System.String, Int32, Int32, System.Globalization.CompareOptions)
       jmp       near ptr M01_L00
M01_L03:
       test      r12d,r12d
       je        short M01_L06
       lea       rcx,[rdi+0C]
       mov       edx,[rdi+8]
       test      edx,edx
       je        near ptr M01_L13
       cmp       edx,r14d
       jg        short M01_L08
       mov       [rbp+0FFB0],rax
       mov       [rbp+0FFB8],r14d
       mov       [rbp+0FFA0],rcx
       mov       [rbp+0FFA8],edx
       lea       rcx,[rbp+0FFB0]
       lea       rdx,[rbp+0FFA0]
       call      System.Globalization.OrdinalCasing.IndexOf(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>)
M01_L04:
       test      eax,eax
       jge       short M01_L07
M01_L05:
       jmp       near ptr M01_L00
M01_L06:
       mov       rcx,rax
       mov       edx,r14d
       lea       r8,[rdi+0C]
       mov       r9d,[rdi+8]
       call      System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       jmp       short M01_L04
M01_L07:
       add       eax,ebx
       jmp       short M01_L05
M01_L08:
       mov       eax,0FFFFFFFF
       jmp       short M01_L04
M01_L09:
       mov       rcx,rax
       mov       rax,[r13+48]
       call      qword ptr [rax+30]
       jmp       near ptr M01_L02
       mov       rcx,7FFB68034928
       mov       edx,227
       call      CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE
       mov       rcx,267DA811520
       mov       rcx,[rcx]
       mov       [rsp+20],r14d
       mov       edx,r15d
       and       edx,1
       mov       [rsp+28],edx
       mov       rdx,rsi
       mov       r8,rdi
       mov       r9d,ebx
       cmp       [rcx],ecx
       call      System.Globalization.CompareInfo.IndexOf(System.String, System.String, Int32, Int32, System.Globalization.CompareOptions)
       jmp       near ptr M01_L00
M01_L10:
       mov       ecx,7
       call      System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument)
       int       3
M01_L11:
       cmp       [rsi+8],ebx
       jae       short M01_L12
       mov       ecx,8
       xor       edx,edx
       call      System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument, System.ExceptionResource)
       int       3
M01_L12:
       mov       ecx,1B
       mov       edx,3
       call      System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument, System.ExceptionResource)
       int       3
M01_L13:
       xor       eax,eax
       jmp       near ptr M01_L04
M01_L14:
       test      rdi,rdi
       je        short M01_L15
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rcx,267DA819588
       mov       rcx,[rcx]
       call      System.SR.GetResourceString(System.String)
       mov       rdx,rax
       mov       r8,267DA819580
       mov       r8,[r8]
       mov       rcx,rsi
       call      System.ArgumentException..ctor(System.String, System.String)
       jmp       short M01_L16
M01_L15:
       mov       rcx,offset MT_System.ArgumentNullException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rdx,267DA813270
       mov       rdx,[rdx]
       mov       rcx,rsi
       call      System.ArgumentNullException..ctor(System.String)
M01_L16:
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 629
```

## .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
```assembly
; Test.Benchmark.OrdinalIgnoreCase()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rsi,[rcx+8]
       xor       edi,edi
       mov       ebx,[rsi+8]
       test      ebx,ebx
       jle       short M00_L01
       mov       r9,22C42829FC0
       mov       rbp,[r9]
M00_L00:
       movsxd    r9,edi
       mov       rcx,[rsi+r9*8+10]
       mov       dword ptr [rsp+20],5
       mov       r9d,[rcx+8]
       mov       rdx,rbp
       xor       r8d,r8d
       call      System.String.IndexOf(System.String, Int32, Int32, System.StringComparison)
       test      eax,eax
       jge       short M00_L02
       inc       edi
       cmp       ebx,edi
       jg        short M00_L00
M00_L01:
       mov       eax,0FFFFFFFF
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       eax,edi
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 100
```
```assembly
; System.String.IndexOf(System.String, Int32, Int32, System.StringComparison)
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
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rbp+0FFA0],xmm4
       vmovdqa   xmmword ptr [rbp+0FFB0],xmm4
       mov       rsi,rcx
       mov       rdi,rdx
       mov       ebx,r8d
       mov       r14d,r9d
       mov       r15d,[rbp+30]
       lea       rcx,[rbp+0FF60]
       mov       rdx,r10
       call      CORINFO_HELP_INIT_PINVOKE_FRAME
       mov       rax,rsp
       mov       [rbp+0FF80],rax
       mov       rax,rbp
       mov       [rbp+0FF90],rax
       cmp       r15d,5
       ja        near ptr M01_L14
       mov       eax,r15d
       lea       rdx,[7FFB6829B968]
       mov       edx,[rdx+rax*4]
       lea       rcx,[7FFB682AB729]
       add       rdx,rcx
       jmp       rdx
M01_L00:
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
       cmp       r15d,5
       sete      r12b
       movzx     r12d,r12b
       test      rsi,rsi
       je        short M01_L01
       test      rdi,rdi
       je        near ptr M01_L10
       mov       eax,ebx
       mov       edx,r14d
       add       rax,rdx
       mov       edx,[rsi+8]
       cmp       rax,rdx
       ja        near ptr M01_L11
       add       rsi,0C
       mov       eax,ebx
       lea       rax,[rsi+rax*2]
       jmp       short M01_L03
M01_L01:
       mov       ecx,27
       call      System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument)
       int       3
       call      System.Globalization.CultureInfo.get_CurrentCulture()
       mov       r13,[rax]
       mov       rcx,offset MT_System.Globalization.CultureInfo
       cmp       r13,rcx
       jne       near ptr M01_L09
       mov       rcx,rax
       call      qword ptr [7FFB682A5C90]
M01_L02:
       mov       [rsp+20],r14d
       and       r15d,1
       mov       [rsp+28],r15d
       mov       rcx,rax
       mov       rdx,rsi
       mov       r8,rdi
       mov       r9d,ebx
       cmp       [rcx],ecx
       call      System.Globalization.CompareInfo.IndexOf(System.String, System.String, Int32, Int32, System.Globalization.CompareOptions)
       jmp       near ptr M01_L00
M01_L03:
       test      r12d,r12d
       je        short M01_L06
       lea       rcx,[rdi+0C]
       mov       edx,[rdi+8]
       test      edx,edx
       je        near ptr M01_L13
       cmp       edx,r14d
       jg        short M01_L08
       mov       [rbp+0FFB0],rax
       mov       [rbp+0FFB8],r14d
       mov       [rbp+0FFA0],rcx
       mov       [rbp+0FFA8],edx
       lea       rcx,[rbp+0FFB0]
       lea       rdx,[rbp+0FFA0]
       call      System.Globalization.OrdinalCasing.IndexOf(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>)
M01_L04:
       test      eax,eax
       jge       short M01_L07
M01_L05:
       jmp       near ptr M01_L00
M01_L06:
       mov       rcx,rax
       mov       edx,r14d
       lea       r8,[rdi+0C]
       mov       r9d,[rdi+8]
       call      System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       jmp       short M01_L04
M01_L07:
       add       eax,ebx
       jmp       short M01_L05
M01_L08:
       mov       eax,0FFFFFFFF
       jmp       short M01_L04
M01_L09:
       mov       rcx,rax
       mov       rax,[r13+48]
       call      qword ptr [rax+30]
       jmp       near ptr M01_L02
       mov       rcx,7FFB68044928
       mov       edx,227
       call      CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE
       mov       rcx,22C42821520
       mov       rcx,[rcx]
       mov       [rsp+20],r14d
       mov       edx,r15d
       and       edx,1
       mov       [rsp+28],edx
       mov       rdx,rsi
       mov       r8,rdi
       mov       r9d,ebx
       cmp       [rcx],ecx
       call      System.Globalization.CompareInfo.IndexOf(System.String, System.String, Int32, Int32, System.Globalization.CompareOptions)
       jmp       near ptr M01_L00
M01_L10:
       mov       ecx,7
       call      System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument)
       int       3
M01_L11:
       cmp       [rsi+8],ebx
       jae       short M01_L12
       mov       ecx,8
       xor       edx,edx
       call      System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument, System.ExceptionResource)
       int       3
M01_L12:
       mov       ecx,1B
       mov       edx,3
       call      System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument, System.ExceptionResource)
       int       3
M01_L13:
       xor       eax,eax
       jmp       near ptr M01_L04
M01_L14:
       test      rdi,rdi
       je        short M01_L15
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rcx,22C42829588
       mov       rcx,[rcx]
       call      System.SR.GetResourceString(System.String)
       mov       rdx,rax
       mov       r8,22C42829580
       mov       r8,[r8]
       mov       rcx,rsi
       call      System.ArgumentException..ctor(System.String, System.String)
       jmp       short M01_L16
M01_L15:
       mov       rcx,offset MT_System.ArgumentNullException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rdx,22C42823270
       mov       rdx,[rdx]
       mov       rcx,rsi
       call      System.ArgumentNullException..ctor(System.String)
M01_L16:
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 629
```

