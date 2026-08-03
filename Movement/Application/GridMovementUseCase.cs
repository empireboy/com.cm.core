using CM.Core.Domain;

namespace CM.Core.Application
{
    public class GridMovementUseCase
    {
        private readonly Grid _grid;
        private readonly IGridEntity _entity;

        public GridMovementUseCase(Grid grid, IGridEntity entity)
        {
            _grid = grid;
            _entity = entity;
        }

        public bool TryMove(Direction direction)
        {
            _entity.SetDirection(direction);

            Int2 targetPosition = _entity.Position + direction.ToInt2();

            if (!_grid.InRange(targetPosition))
                return false;

            GridCell targetCell = _grid.GetCell(targetPosition);

            if (targetCell.IsBlocked || targetCell.IsOccupied)
                return false;

            _grid.Vacate(_entity.Position);
            _grid.TryOccupy(_entity, targetPosition);

            _entity.SetMoving(true);
            _entity.SetPosition(targetPosition);

            return true;
        }
    }

    public class GridTeleportUseCase
    {
        private readonly Grid _grid;
        private readonly IGridEntity _entity;

        public GridTeleportUseCase(Grid grid, IGridEntity entity)
        {
            _grid = grid;
            _entity = entity;
        }

        public bool TryTeleport(Int2 position)
        {
            if (!_grid.InRange(position))
                return false;

            GridCell targetCell = _grid.GetCell(position);

            if (targetCell.IsBlocked || targetCell.IsOccupied)
                return false;

            _grid.Vacate(_entity.Position);
            _grid.TryOccupy(_entity, position);

            _entity.SetPosition(position);

            return true;
        }

        public bool TryTeleport(Int2 position, Direction direction)
        {
            if (TryTeleport(position))
            {
                _entity.SetDirection(direction) ;
                return true;
            }

            return false;
        }
    }
}