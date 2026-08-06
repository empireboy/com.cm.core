using System;

namespace CM.Core.Domain
{
    public interface IGridEntity
    {
        Int2 Position { get; }
        Direction Direction { get; }
        bool IsMoving { get; }

        event Action<Int2> PositionChanged;
        event Action<Direction> DirectionChanged;
        event Action<bool> MovementStateChanged;
        event Action MovementFinished;
        event Action<Int2> TileReached;

        void SetPosition(Int2 position);
        void SetDirection(Direction direction);
        void SetMoving(bool isMoving);
        void FinishMovement();
    }
}