using CM.Core.Domain;
using System;

namespace CM.Core.Application
{
    public class GridEntityFacade
    {
        public Int2 Position => Entity.Position;
        public Direction Direction => Entity.Direction;

        public event Action<Int2> PositionChanged
        {
            add => Entity.PositionChanged += value;
            remove => Entity.PositionChanged -= value;
        }

        public event Action<Direction> DirectionChanged
        {
            add => Entity.DirectionChanged += value;
            remove => Entity.DirectionChanged -= value;
        }

        protected IGridEntity Entity { get; }

        public GridEntityFacade(IGridEntity entity)
        {
            Entity = entity;
        }
    }

    public class GridActorFacade : GridEntityFacade
    {
        public bool IsMoving => ActorEntity.IsMoving;

        public event Action<Int2> Teleported
        {
            add => ActorEntity.Teleported += value;
            remove => ActorEntity.Teleported -= value;
        }

        public event Action<bool> MovementStateChanged
        {
            add => ActorEntity.MovementStateChanged += value;
            remove => ActorEntity.MovementStateChanged -= value;
        }

        public event Action MovementFinished
        {
            add => ActorEntity.MovementFinished += value;
            remove => ActorEntity.MovementFinished -= value;
        }

        public event Action<Int2> TileReached
        {
            add => ActorEntity.TileReached += value;
            remove => ActorEntity.TileReached -= value;
        }

        private IGridActor ActorEntity => (IGridActor)Entity;

        private readonly Grid _grid;
        private readonly GridMovementUseCase _gridMovementUseCase;
        private readonly GridTeleportUseCase _gridTeleportUseCase;

        public GridActorFacade(IGridActor entity, Grid grid, GridMovementUseCase gridMovementUseCase, GridTeleportUseCase gridTeleportUseCase) : base(entity)
        {
            _grid = grid;
            _gridMovementUseCase = gridMovementUseCase;
            _gridTeleportUseCase = gridTeleportUseCase;
        }

        public bool TryMove(Direction direction) => _gridMovementUseCase.TryMove(_grid, ActorEntity, direction);
        public bool TryTeleport(Int2 position) => _gridTeleportUseCase.TryTeleport(_grid, ActorEntity, position);
        public bool TryTeleport(Int2 position, Direction direction) => _gridTeleportUseCase.TryTeleport(_grid, ActorEntity, position, direction);
        public void SetMoving(bool moving) => ActorEntity.SetMoving(moving);
        public void Teleport(Int2 position) => ActorEntity.Teleport(position);
        public void NotifyTileReached() => ActorEntity.NotifyTileReached();
        public void NotifyMovementFinished() => ActorEntity.NotifyMovementFinished();
    }
}