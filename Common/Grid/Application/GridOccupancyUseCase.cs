using CM.Core.Domain;

namespace CM.Core.Application
{
    public class GridOccupancyUseCase
    {
        public bool TryOccupy(Grid grid, IGridEntity entity, Int2 position)
        {
            if (!grid.InRange(position))
                return false;

            GridCell cell = grid.GetCell(position);

            if (cell.IsBlocked || cell.IsOccupied)
                return false;

            grid.Vacate(entity.Position);
            cell.SetOccupant(entity);

            return true;
        }
    }
}
