using CM.Core.Domain;
using System;

namespace CM.Core.Application
{
    public class GridEntityFacade
    {
        public Int2 Position => _entity.Position;
        public Direction Direction => _entity.Direction;
        public bool IsMoving => _entity.IsMoving;

        public event Action<Int2> PositionChanged
        {
            add => _entity.PositionChanged += value;
            remove => _entity.PositionChanged -= value;
        }

        public event Action<Direction> DirectionChanged
        {
            add => _entity.DirectionChanged += value;
            remove => _entity.DirectionChanged -= value;
        }

        public event Action<Int2> Teleported
        {
            add => _entity.Teleported += value;
            remove => _entity.Teleported -= value;
        }

        public event Action<bool> MovementStateChanged
        {
            add => _entity.MovementStateChanged += value;
            remove => _entity.MovementStateChanged -= value;
        }

        public event Action MovementFinished
        {
            add => _entity.MovementFinished += value;
            remove => _entity.MovementFinished -= value;
        }

        public event Action<Int2> TileReached
        {
            add => _entity.TileReached += value;
            remove => _entity.TileReached -= value;
        }

        private readonly IGridEntity _entity;
        private readonly GridMovementUseCase _gridMovementUseCase;
        private readonly GridTeleportUseCase _gridTeleportUseCase;

        public GridEntityFacade(IGridEntity entity, GridMovementUseCase gridMovementUseCase, GridTeleportUseCase gridTeleportUseCase)
        {
            _entity = entity;
            _gridMovementUseCase = gridMovementUseCase;
            _gridTeleportUseCase = gridTeleportUseCase;
        }

        public bool TryMove(Direction direction) => _gridMovementUseCase.TryMove(direction);
        public bool TryTeleport(Int2 position) => _gridTeleportUseCase.TryTeleport(position);
        public bool TryTeleport(Int2 position, Direction direction) => _gridTeleportUseCase.TryTeleport(position, direction);
        public void SetMoving(bool moving) => _entity.SetMoving(moving);
        public void Teleport(Int2 position) => _entity.Teleport(position);
        public void NotifyTileReached() => _entity.NotifyTileReached();
        public void NotifyMovementFinished() => _entity.NotifyMovementFinished();
    }
}