using System;
namespace Test
{
    public struct Xorshift
    {
        private uint _state;

        public Xorshift(uint seed)
        {
            _state = seed;
        }

        public uint Next()
        {
            uint state = _state;
            state ^= state << 13;
            state ^= state >> 17;
            state ^= state << 5;
            _state = state;
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
}