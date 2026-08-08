using System;

namespace CM.Core.Domain
{
    public interface IGridEntityBACKUP
    {
        Int2 Position { get; }
        Direction Direction { get; }
        bool IsMoving { get; }

        event Action<Int2> PositionChanged;
        event Action<Direction> DirectionChanged;
        event Action<Int2> Teleported;
        event Action<bool> MovementStateChanged;
        event Action MovementFinished;
        event Action<Int2> TileReached;

        void SetPosition(Int2 position);
        void SetDirection(Direction direction);
        void SetMoving(bool isMoving);
        void Teleport(Int2 position);
        void NotifyTileReached();
        void NotifyMovementFinished();
    }

    public interface IGridEntity
    {
        Int2 Position { get; }
        Direction Direction { get; }

        event Action<Int2> PositionChanged;
        event Action<Direction> DirectionChanged;

        void SetPosition(Int2 position);
        void SetDirection(Direction direction);
    }

    public interface IGridActor : IGridEntity
    {
        bool IsMoving { get; }

        event Action<Int2> Teleported;
        event Action<bool> MovementStateChanged;
        event Action MovementFinished;
        event Action<Int2> TileReached;

        void Teleport(Int2 position);
        void SetMoving(bool isMoving);
        void NotifyTileReached();
        void NotifyMovementFinished();
    }
}