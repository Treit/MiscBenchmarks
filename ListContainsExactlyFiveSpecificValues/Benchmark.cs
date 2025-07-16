namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SuperLinq;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100_000)]
    public int Count { get; set; }

    private List<int> _values;
    private HashSet<int> _set;
    private BitmaskSet<byte> _bitmaskSet;

    private Random _random;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _values = [1, 2, 3, 4, 5];
        _set = new HashSet<int>(_values);
        _random = new Random(Count);
        _bitmaskSet = [1, 2, 3, 4, 5];
    }

    [IterationSetup]
    public void IterationSetup()
    {
        Shuffle();
    }

    [Benchmark]
    public bool ListIsExactlyFiveValuesHashSet()
    {
        if (_set.Count != 5)
        {
            return false;
        }

        return _set.Contains(1) && _set.Contains(2) && _set.Contains(3) && _set.Contains(4) && _set.Contains(5);
    }

    [Benchmark]
    public bool ListIsExactlyFiveValuesSetEquals()
    {
        return _set.SetEquals([1, 2, 3, 4, 5]);
    }

    [Benchmark]
    public bool ListIsExactlyFiveValuesBitmaskSetSetEquals()
    {
        return _bitmaskSet.SetEquals([1, 2, 3, 4, 5]);
    }

    [Benchmark]
    public bool ListIsExactlyFiveValuesBitmaskSetContains()
    {
        if (_bitmaskSet.Count != 5)
        {
            return false;
        }

        return _bitmaskSet.Contains(1) && _bitmaskSet.Contains(2) && _bitmaskSet.Contains(3) && _bitmaskSet.Contains(4) && _bitmaskSet.Contains(5);
    }

    [Benchmark]
    public bool ListIsExactlyFiveValuesSuperLinqCollectionEqual()
    {
        return _values.CollectionEqual([1, 2, 3, 4, 5]);
    }

    [Benchmark(Baseline = true)]
    public bool ListIsExactlyFiveValuesPatternMatchingLulz()
    {
        return _values is [1, 2, 3, 4, 5] or
                    [2, 1, 3, 4, 5] or
                    [3, 1, 2, 4, 5] or
                    [1, 3, 2, 4, 5] or
                    [2, 3, 1, 4, 5] or
                    [3, 2, 1, 4, 5] or
                    [3, 2, 4, 1, 5] or
                    [2, 3, 4, 1, 5] or
                    [4, 3, 2, 1, 5] or
                    [3, 4, 2, 1, 5] or
                    [2, 4, 3, 1, 5] or
                    [4, 2, 3, 1, 5] or
                    [4, 1, 3, 2, 5] or
                    [1, 4, 3, 2, 5] or
                    [3, 4, 1, 2, 5] or
                    [4, 3, 1, 2, 5] or
                    [1, 3, 4, 2, 5] or
                    [3, 1, 4, 2, 5] or
                    [2, 1, 4, 3, 5] or
                    [1, 2, 4, 3, 5] or
                    [4, 2, 1, 3, 5] or
                    [2, 4, 1, 3, 5] or
                    [1, 4, 2, 3, 5] or
                    [4, 1, 2, 3, 5] or
                    [5, 1, 2, 3, 4] or
                    [1, 5, 2, 3, 4] or
                    [2, 5, 1, 3, 4] or
                    [5, 2, 1, 3, 4] or
                    [1, 2, 5, 3, 4] or
                    [2, 1, 5, 3, 4] or
                    [2, 1, 3, 5, 4] or
                    [1, 2, 3, 5, 4] or
                    [3, 2, 1, 5, 4] or
                    [2, 3, 1, 5, 4] or
                    [1, 3, 2, 5, 4] or
                    [3, 1, 2, 5, 4] or
                    [3, 5, 2, 1, 4] or
                    [5, 3, 2, 1, 4] or
                    [2, 3, 5, 1, 4] or
                    [3, 2, 5, 1, 4] or
                    [5, 2, 3, 1, 4] or
                    [2, 5, 3, 1, 4] or
                    [1, 5, 3, 2, 4] or
                    [5, 1, 3, 2, 4] or
                    [3, 1, 5, 2, 4] or
                    [1, 3, 5, 2, 4] or
                    [5, 3, 1, 2, 4] or
                    [3, 5, 1, 2, 4] or
                    [4, 5, 1, 2, 3] or
                    [5, 4, 1, 2, 3] or
                    [1, 4, 5, 2, 3] or
                    [4, 1, 5, 2, 3] or
                    [5, 1, 4, 2, 3] or
                    [1, 5, 4, 2, 3] or
                    [1, 5, 2, 4, 3] or
                    [5, 1, 2, 4, 3] or
                    [2, 1, 5, 4, 3] or
                    [1, 2, 5, 4, 3] or
                    [5, 2, 1, 4, 3] or
                    [2, 5, 1, 4, 3] or
                    [2, 4, 1, 5, 3] or
                    [4, 2, 1, 5, 3] or
                    [1, 2, 4, 5, 3] or
                    [2, 1, 4, 5, 3] or
                    [4, 1, 2, 5, 3] or
                    [1, 4, 2, 5, 3] or
                    [5, 4, 2, 1, 3] or
                    [4, 5, 2, 1, 3] or
                    [2, 5, 4, 1, 3] or
                    [5, 2, 4, 1, 3] or
                    [4, 2, 5, 1, 3] or
                    [2, 4, 5, 1, 3] or
                    [3, 4, 5, 1, 2] or
                    [4, 3, 5, 1, 2] or
                    [5, 3, 4, 1, 2] or
                    [3, 5, 4, 1, 2] or
                    [4, 5, 3, 1, 2] or
                    [5, 4, 3, 1, 2] or
                    [5, 4, 1, 3, 2] or
                    [4, 5, 1, 3, 2] or
                    [1, 5, 4, 3, 2] or
                    [5, 1, 4, 3, 2] or
                    [4, 1, 5, 3, 2] or
                    [1, 4, 5, 3, 2] or
                    [1, 3, 5, 4, 2] or
                    [3, 1, 5, 4, 2] or
                    [5, 1, 3, 4, 2] or
                    [1, 5, 3, 4, 2] or
                    [3, 5, 1, 4, 2] or
                    [5, 3, 1, 4, 2] or
                    [4, 3, 1, 5, 2] or
                    [3, 4, 1, 5, 2] or
                    [1, 4, 3, 5, 2] or
                    [4, 1, 3, 5, 2] or
                    [3, 1, 4, 5, 2] or
                    [1, 3, 4, 5, 2] or
                    [2, 3, 4, 5, 1] or
                    [3, 2, 4, 5, 1] or
                    [4, 2, 3, 5, 1] or
                    [2, 4, 3, 5, 1] or
                    [3, 4, 2, 5, 1] or
                    [4, 3, 2, 5, 1] or
                    [4, 3, 5, 2, 1] or
                    [3, 4, 5, 2, 1] or
                    [5, 4, 3, 2, 1] or
                    [4, 5, 3, 2, 1] or
                    [3, 5, 4, 2, 1] or
                    [5, 3, 4, 2, 1] or
                    [5, 2, 4, 3, 1] or
                    [2, 5, 4, 3, 1] or
                    [4, 5, 2, 3, 1] or
                    [5, 4, 2, 3, 1] or
                    [2, 4, 5, 3, 1] or
                    [4, 2, 5, 3, 1] or
                    [3, 2, 5, 4, 1] or
                    [2, 3, 5, 4, 1] or
                    [5, 3, 2, 4, 1] or
                    [3, 5, 2, 4, 1] or
                    [2, 5, 3, 4, 1] or
                    [5, 2, 3, 4, 1];

    }

    private int Shuffle()
    {
        for (int i = _values.Count - 1; i > 0; --i)
        {
            int n = _random.Next(0, i + 1);
            Swap(i, n);
        }

        void Swap(int x, int y)
        {
            int tmp = _values[x];
            _values[x] = _values[y];
            _values[y] = tmp;
        }

        return _values[0];
    }
}

// From maxmahem on the C# Community Discord
public class BitmaskSet<TNum> : IEnumerable<TNum>
    where TNum : struct, IBinaryInteger<TNum>, IMinMaxValue<TNum>, IUnsignedNumber<TNum>
{
    private static readonly int ByteSize = TNum.AllBitsSet.GetByteCount() * 8;
    private static readonly TNum TypedSize = TNum.CreateChecked(ByteSize);
    private static readonly int ElementCount = (int)(ulong.CreateChecked(1L << ByteSize) / (ulong)ByteSize);

    private readonly TNum[] bitmask = new TNum[ElementCount];

    public int Count { get; private set; } = 0;

    public bool IsReadOnly => false;

    private readonly record struct BitmaskOffset(int ByteIndex, int BitOffset);

    private static BitmaskOffset GetOffsets(TNum item)
    {
        int byteIndex = int.CreateChecked(item / TypedSize);
        int bitOffset = int.CreateChecked(item % TypedSize);
        return new(byteIndex, bitOffset);
    }

    public bool Contains(TNum item)
    {
        var offsets = BitmaskSet<TNum>.GetOffsets(item);
        return (this.bitmask[offsets.ByteIndex] & (TNum.One << offsets.BitOffset)) != TNum.Zero;
    }

    public bool Add(TNum item)
    {
        var offsets = BitmaskSet<TNum>.GetOffsets(item);
        if (this.bitmask[offsets.ByteIndex] == TNum.One << offsets.BitOffset) return false;

        bitmask[offsets.ByteIndex] |= TNum.One << offsets.BitOffset;
        Count++;
        return true;
    }

    public bool SetEquals(IEnumerable<TNum> other)
    {
        if (other is BitmaskSet<TNum> otherBitset)
        {
            for (int index = 0; index < Vector<TNum>.Count; index += Vector<TNum>.Count)
            {
                var thisVector = new Vector<TNum>(this.bitmask, index);
                var otherVector = new Vector<TNum>(otherBitset.bitmask, index);

                if (thisVector != otherVector) return false;
            }
            return true;
        }
        return other.All(Contains) && other.Count() == Count;
    }

    public IEnumerator<TNum> GetEnumerator()
    {
        for (TNum value = TNum.MinValue; value < TNum.MaxValue; value++)
            if (Contains(value))
                yield return value;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
