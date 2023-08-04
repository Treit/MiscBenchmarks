// this is just the jank invoker generator i had laying around, i wouldnt use this in your own projects
// - Windows10CE (Aaron)

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Benchmark;

ref struct TypedReference2_2
{
    private TypedReference2 _1;
    private TypedReference2 _2;

    public TypedReference2_2(TypedReference2 first, TypedReference2 second)
    {
        _1 = first;
        _2 = second;
    }

    [UnscopedRef]
    public unsafe TypedReference2Span AsSpan(int length = 2)
    {
        if (length is < 0 or > 2) ThrowOutOfRange();
        fixed (TypedReference2_2* @this = &this)
        {
            return new((TypedReference2*)@this, length);
        }
    }

    [DoesNotReturn]
    private static void ThrowOutOfRange() => throw new ArgumentOutOfRangeException();
}

public readonly ref struct TypedReference2
{
    private readonly Type _type;
    private readonly ref byte _ref;

    private TypedReference2(Type t, ref byte @ref)
    {
        _type = t;
        _ref = ref @ref;
    }

    public static TypedReference2 Create<T>(ref T source)
    {
        return new TypedReference2(typeof(T), ref Unsafe.As<T, byte>(ref source));
    }

    public ref T GetValueRef<T>()
    {
        [StackTraceHidden]
        void SlowPath(Type type)
        {
            if (type is { IsValueType: false, IsPointer: false } && typeof(T).IsAssignableTo(type))
            {
                return;
            }
            throw new InvalidCastException();
        }

        if (typeof(T) != _type)
        {
            SlowPath(_type);
        }
        return ref Unsafe.As<byte, T>(ref _ref);
    }

    public ref T GetValueRefUnsafe<T>()
    {
        return ref Unsafe.As<byte, T>(ref _ref);
    }
}

public unsafe readonly ref struct TypedReference2Span
{
    private readonly TypedReference2* _start;
    private readonly int _length;

    public TypedReference2Span(TypedReference2* start, int length)
    {
        _start = start;
        _length = length;
    }

    public int Length => _length;

    public ref TypedReference2 this[int index]
    {
        get
        {
            if (index < 0 || index >= _length)
            {
                ThrowIndexOutOfRange();
            }
            return ref _start[index];
        }
    }

    [DoesNotReturn]
    private static void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
}

public static class MethodInfoInvokerExtensions
{
    public delegate void InvokerDelegate(TypedReference2 ret, TypedReference2 self, TypedReference2Span parameters);

    private static readonly MethodInfo _getValueRefT = typeof(TypedReference2).GetMethod("GetValueRef")!;
    private static readonly MethodInfo _getValueRefUnsafeT = typeof(TypedReference2).GetMethod("GetValueRefUnsafe")!;
    private static readonly MethodInfo _getItem = typeof(TypedReference2Span).GetProperty("Item")!.GetMethod!;

    public static InvokerDelegate GetInvoker(this MethodInfo method, bool noTypeChecks = false)
    {
        if (method.IsGenericMethodDefinition)
        {
            throw new NotSupportedException();
        }

        var refGetter = noTypeChecks ? _getValueRefUnsafeT : _getValueRefT;

        DynamicMethod dm = new("lollmao", MethodAttributes.Static | MethodAttributes.Public, CallingConventions.Standard, typeof(void),
            new[] { typeof(TypedReference2), typeof(TypedReference2), typeof(TypedReference2Span) }, typeof(MethodInfoExtensions), true);

        var paramTypes = method.GetParameters();

        var il = dm.GetILGenerator();

        bool emitReturn = method.ReturnType != typeof(void);
        
        if (emitReturn)
        {
            il.Emit(OpCodes.Ldarga, 0);
            il.Emit(OpCodes.Call, refGetter.MakeGenericMethod(method.ReturnType));
        }
        
        if (!method.IsStatic)
        {
            il.Emit(OpCodes.Ldarga, 1);
            il.Emit(OpCodes.Call, refGetter.MakeGenericMethod(method.DeclaringType!));
            if (!method.DeclaringType!.IsValueType)
            {
                il.Emit(OpCodes.Ldind_Ref);
            }
        }

        for (int i = 0; i < paramTypes.Length; i++)
        {
            var p = paramTypes[i];
            il.Emit(OpCodes.Ldarga, 2);
            il.Emit(OpCodes.Ldc_I4, i);
            il.Emit(OpCodes.Call, _getItem);
            if (p.ParameterType.IsByRef)
            {
                il.Emit(OpCodes.Call, refGetter.MakeGenericMethod(p.ParameterType.GetElementType()!));
            }
            else
            {
                il.Emit(OpCodes.Call, refGetter.MakeGenericMethod(p.ParameterType));
                if (p.ParameterType is { IsValueType: true } or { IsPointer: true })
                {
                    il.Emit(OpCodes.Ldobj, p.ParameterType);
                }
                else
                {
                    il.Emit(OpCodes.Ldind_Ref);
                }
            }
        }

        il.Emit(OpCodes.Call, method);

        if (emitReturn)
        {
            if (method.ReturnType is { IsValueType: true } or { IsPointer: true })
            {
                il.Emit(OpCodes.Stobj, method.ReturnType);
            }
            else
            {
                il.Emit(OpCodes.Stind_Ref);
            }
        }
        
        il.Emit(OpCodes.Ret);

        return dm.CreateDelegate<InvokerDelegate>();
    }
}
