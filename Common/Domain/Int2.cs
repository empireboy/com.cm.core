using System;

namespace CM.Core.Domain
{
    public readonly struct Int2
    {
        public readonly int x;
        public readonly int y;

        public Int2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Int2 @int &&
                   x == @int.x &&
                   y == @int.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static Int2 operator +(Int2 a, Int2 b)
        {
            return new Int2(a.x + b.x, a.y + b.y);
        }

        public static Int2 operator -(Int2 a, Int2 b)
        {
            return new Int2(a.x - b.x, a.y - b.y);
        }

        public static bool operator ==(Int2 a, Int2 b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Int2 a, Int2 b)
        {
            return !(a == b);
        }
    }
}