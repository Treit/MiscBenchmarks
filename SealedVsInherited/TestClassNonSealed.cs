using System;
using System.Runtime.CompilerServices;

namespace Test;
internal class TestClassNonSealed
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public long DoWork(int seed)
    {
        long result = 0;
        var r = new Random(seed);

        for (int i = 0; i < seed; i++)
        {
            result += r.Next(100_000);
        }

        return result;
    }
}
