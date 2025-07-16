namespace Test;
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

[MemoryDiagnoser]
public class Benchmark
{
    private char[] _array;

    [Params(1, 4, 16, 24)]
    public int Amount { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _array = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    }

    [Benchmark]
    public char[] RotateLeftWithReverse()
    {
        // This algorithm is from Programming Pearls.
        int i = Amount;
        int n = _array.Length;

        Reverse(_array, 0, i - 1);
        Reverse(_array, i, n - 1);
        Reverse(_array, 0, n - 1);
        return _array;

        static void Reverse<T>(T[] array, int start, int end)
        {
            while (start < end)
            {
                Swap(array, start++, end--);
            }

            static void Swap(T[] array, int a, int b)
            {
                T tmp = array[a];
                array[a] = array[b];
                array[b] = tmp;
            }
        }
    }

    [Benchmark]
    public char[] RotateLeftWithCopy()
    {
        char[] copy = new char[_array.Length];
        int n = Amount;
        int len = _array.Length;

        for (int i = 0; i < _array.Length; i++)
        {
            // Compute the new index for each element using wrapping.
            var newidx = ((i - n % len) + len) % len;
            copy[newidx] = _array[i];
        }

        return copy;
    }

    [Benchmark]
    public char[] RotateLeftWithJuggling()
    {
        char temp;
        var len = _array.Length;
        var n = Amount;
        n %= len;

        int gcd = Gcd(n, len);

        for (int i = 0; i < gcd; i++)
        {
            temp = _array[i];
            int j = i;

            while (true)
            {
                int k = j + n;

                if (k >= len)
                {
                    k -= len;
                }

                if (k == i)
                {
                    break;
                }

                _array[j] = _array[k];
                j = k;
            }

            _array[j] = temp;
        }

        return _array;

        static int Gcd(int x, int y)
        {
            while (y != 0)
            {
                int tmp = x % y;
                x = y;
                y = tmp;
            }

            return x;
        }
    }

    [Benchmark]
    public char[] RotateLeftArrayCopyAaron()
    {
        var array = _array;

        var final = new char[array.Length];

        int offset = Amount % array.Length;

        Array.Copy(array, offset, final, 0, array.Length - offset);
        Array.Copy(array, 0, final, array.Length - offset, offset);

        return final;
    }
}
