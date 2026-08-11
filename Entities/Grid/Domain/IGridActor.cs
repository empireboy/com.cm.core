using System;

namespace CM.Core.Domain
{
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