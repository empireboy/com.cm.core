using CM.Core.Domain;

namespace CM.Core.Application
{
    public class GridActorTeleportTrigger : GridEntity, IGridTrigger
    {
        private readonly Int2 _destination;
        private readonly Direction _destinationDirection;

        private readonly GridTeleportUseCase _gridTeleportUseCase;

        public GridActorTeleportTrigger(GridEntityState state, Int2 destination, Direction destinationDirection, GridTeleportUseCase gridTeleportUseCase) : base(state)
        {
            _destination = destination;
            _destinationDirection = destinationDirection;
            _gridTeleportUseCase = gridTeleportUseCase;
        }

        public void Execute(Grid grid, IGridEntity entity)
        {
            if (entity is not IGridActor)
                return;

            Direction finalDestinationDirection = _destinationDirection;

            if (finalDestinationDirection == Direction.None)
                finalDestinationDirection = entity.Direction;

            _gridTeleportUseCase.TryTeleport(grid, (IGridActor)entity, _destination, finalDestinationDirection);
        }
    }
}