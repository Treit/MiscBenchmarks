namespace Test;
public struct Xorshift(uint seed)
{
    public uint Next()
    {
        uint state = seed;
        state ^= state << 13;
        state ^= state >> 17;
        state ^= state << 5;
        seed = state;
        return state;
    }

    public uint NextUInt32()
    {
        return Next() % 10;
    }

    public int NextInt32()
    {
        return (int)Next() % 10;
    }
}
