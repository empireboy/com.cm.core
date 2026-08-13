using CM.Core.Domain;
using System;

namespace CM.Core.Application
{
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

        private readonly GameStateManager _gameStateManager;
        private readonly Grid _grid;
        private readonly GridMovementUseCase _gridMovementUseCase;
        private readonly GridTeleportUseCase _gridTeleportUseCase;
        private readonly GridInteractionUseCase _gridInteractionUseCase;

        public GridActorFacade(
            IGridActor entity,
            GameStateManager gameStateManager,
            Grid grid,
            GridMovementUseCase gridMovementUseCase,
            GridTeleportUseCase gridTeleportUseCase,
            GridInteractionUseCase gridInteractionUseCase
        ) : base(entity)
        {
            _grid = grid;
            _gridMovementUseCase = gridMovementUseCase;
            _gridTeleportUseCase = gridTeleportUseCase;
            _gridInteractionUseCase = gridInteractionUseCase;
        }

        public bool TryMove(Direction direction) => _gridMovementUseCase.TryMove(_grid, ActorEntity, direction);
        public bool TryTeleport(Int2 position) => _gridTeleportUseCase.TryTeleport(_grid, ActorEntity, position);
        public bool TryTeleport(Int2 position, Direction direction) => _gridTeleportUseCase.TryTeleport(_grid, ActorEntity, position, direction);
        public bool TryInteract() => _gridInteractionUseCase.TryInteract(_grid, ActorEntity, _gameStateManager);
        public void SetMoving(bool moving) => ActorEntity.SetMoving(moving);
        public void Teleport(Int2 position) => ActorEntity.Teleport(position);
        public void NotifyTileReached() => ActorEntity.NotifyTileReached();
        public void NotifyMovementFinished() => ActorEntity.NotifyMovementFinished();
    }
}
