using CM.Core.Domain;

namespace CM.Core.Application
{
    public class GridMovementUseCase
    {
        private readonly GridOccupancyUseCase _gridOccupancyUseCase;

        public GridMovementUseCase(GridOccupancyUseCase gridOccupancyUseCase)
        {
            _gridOccupancyUseCase = gridOccupancyUseCase;
        }

        public bool TryMove(Grid grid, IGridActor entity, Direction direction)
        {
            entity.SetDirection(direction);

            Int2 targetPosition = entity.Position + direction.ToInt2();

            if (!_gridOccupancyUseCase.TryOccupy(grid, entity, targetPosition))
                return false;

            entity.SetMoving(true);
            entity.SetPosition(targetPosition);

            return true;
        }
    }
}