using System;

namespace CM.Core.Domain
{
    public interface IGridEntity
    {
        Int2 Position { get; }
        Direction Direction { get; }

        event Action<Int2> PositionChanged;
        event Action<Direction> DirectionChanged;

        void SetPosition(Int2 position);
        void SetDirection(Direction direction);
    }
}