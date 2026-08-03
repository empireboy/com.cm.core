using System;

namespace CM.Core.Domain
{
    public static class DirectionExtension
    {
        public static Direction ToDirection(this Int2 direction)
        {
            if (direction == new Int2(-1, 0))
                return Direction.Left;

            if (direction == new Int2(1, 0))
                return Direction.Right;

            if (direction == new Int2(0, 1))
                return Direction.Up;

            if (direction == new Int2(0, -1))
                return Direction.Down;

            throw new ArgumentException($"Invalid direction: {direction.x}, {direction.y}");
        }

        public static Int2 ToInt2(this Direction direction)
        {
            return direction switch
            {
                Direction.Left => new Int2(-1, 0),
                Direction.Right => new Int2(1, 0),
                Direction.Up => new Int2(0, 1),
                Direction.Down => new Int2(0, -1),
                _ => throw new ArgumentException($"Invalid direction: {direction}"),
            };
        }
    }
}
