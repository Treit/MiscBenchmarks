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
       mov       r9,2C4364A9FC8
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
       lea       rdx,[7FFB5D71BB28]
       mov       edx,[rdx+rax*4]
       lea       rcx,[7FFB5D72B8E9]
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
       call      qword ptr [7FFB5D725C90]
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
       mov       rcx,7FFB5D4C4928
       mov       edx,227
       call      CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE
       mov       rcx,2C4364A1520
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
       mov       rcx,2C4364A9588
       mov       rcx,[rcx]
       call      System.SR.GetResourceString(System.String)
       mov       rdx,rax
       mov       r8,2C4364A9580
       mov       r8,[r8]
       mov       rcx,rsi
       call      System.ArgumentException..ctor(System.String, System.String)
       jmp       short M01_L16
M01_L15:
       mov       rcx,offset MT_System.ArgumentNullException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rdx,2C4364A3270
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
       mov       r9,2A6E0489FC8
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
       lea       rdx,[7FFB5D74BB28]
       mov       edx,[rdx+rax*4]
       lea       rcx,[7FFB5D75B8E9]
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
       call      qword ptr [7FFB5D755C90]
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
       mov       rcx,7FFB5D4F4928
       mov       edx,227
       call      CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE
       mov       rcx,2A6E0481520
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
       mov       rcx,2A6E0489588
       mov       rcx,[rcx]
       call      System.SR.GetResourceString(System.String)
       mov       rdx,rax
       mov       r8,2A6E0489580
       mov       r8,[r8]
       mov       rcx,rsi
       call      System.ArgumentException..ctor(System.String, System.String)
       jmp       short M01_L16
M01_L15:
       mov       rcx,offset MT_System.ArgumentNullException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rdx,2A6E0483270
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
; Test.Benchmark.OrdinalLongStrings()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rsi,[rcx+10]
       xor       edi,edi
       mov       ebx,[rsi+8]
       test      ebx,ebx
       jle       short M00_L01
       mov       r9,23F18009FC8
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
       lea       rdx,[7FFB5D74BA08]
       mov       edx,[rdx+rax*4]
       lea       rcx,[7FFB5D75B7C9]
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
       call      qword ptr [7FFB5D755C90]
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
       mov       rcx,7FFB5D4F4928
       mov       edx,227
       call      CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE
       mov       rcx,23F18001520
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
       mov       rcx,23F18009588
       mov       rcx,[rcx]
       call      System.SR.GetResourceString(System.String)
       mov       rdx,rax
       mov       r8,23F18009580
       mov       r8,[r8]
       mov       rcx,rsi
       call      System.ArgumentException..ctor(System.String, System.String)
       jmp       short M01_L16
M01_L15:
       mov       rcx,offset MT_System.ArgumentNullException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rdx,23F18003270
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
; Test.Benchmark.OrdinalIgnoreCaseLongStrings()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rsi,[rcx+10]
       xor       edi,edi
       mov       ebx,[rsi+8]
       test      ebx,ebx
       jle       short M00_L01
       mov       r9,291C72E9FC8
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
       lea       rdx,[7FFB5D72BA08]
       mov       edx,[rdx+rax*4]
       lea       rcx,[7FFB5D73B7C9]
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
       call      qword ptr [7FFB5D735C90]
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
       mov       rcx,7FFB5D4D4928
       mov       edx,227
       call      CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE
       mov       rcx,291C72E1520
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
       mov       rcx,291C72E9588
       mov       rcx,[rcx]
       call      System.SR.GetResourceString(System.String)
       mov       rdx,rax
       mov       r8,291C72E9580
       mov       r8,[r8]
       mov       rcx,rsi
       call      System.ArgumentException..ctor(System.String, System.String)
       jmp       short M01_L16
M01_L15:
       mov       rcx,offset MT_System.ArgumentNullException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rdx,291C72E3270
       mov       rdx,[rdx]
       mov       rcx,rsi
       call      System.ArgumentNullException..ctor(System.String)
M01_L16:
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 629
```

