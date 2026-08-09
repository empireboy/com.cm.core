using CM.Core.Domain;

namespace CM.Core.Application
{
    public class GridTeleportUseCase
    {
        private readonly GridOccupancyUseCase _gridOccupancyUseCase;

        public GridTeleportUseCase(GridOccupancyUseCase gridOccupancyUseCase)
        {
            _gridOccupancyUseCase = gridOccupancyUseCase;
        }

        public bool TryTeleport(Grid grid, IGridActor entity, Int2 position)
        {
            if (!_gridOccupancyUseCase.TryOccupy(grid, entity, position))
                return false;

            entity.Teleport(position);
            entity.NotifyTileReached();

            return true;
        }

        public bool TryTeleport(Grid grid, IGridActor entity, Int2 position, Direction direction)
        {
            if (TryTeleport(grid, entity, position))
            {
                entity.SetDirection(direction);

                return true;
            }

            return false;
        }
    }
}