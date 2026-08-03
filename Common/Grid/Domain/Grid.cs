using System;

namespace CM.Core.Domain
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private readonly GridCell[,] _cells;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new GridCell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _cells[x, y] = new GridCell(new Int2(x, y));
                }
            }
        }

        public bool InRange(Int2 position)
        {
            return position.x >= 0 &&
                position.x < _width &&
                position.y >= 0 &&
                position.y < _height;
        }

        public GridCell GetCell(Int2 position)
        {
            if (!InRange(position))
                throw new ArgumentOutOfRangeException(nameof(position));

            return _cells[position.x, position.y];
        }

        public bool TryOccupy(IGridEntity entity, Int2 position)
        {
            if (!InRange(position))
                return false;

            GridCell cell = GetCell(position);

            if (cell.IsOccupied || cell.IsBlocked)
                return false;

            cell.SetOccupant(entity);

            return true;
        }

        public void Vacate(Int2 position)
        {
            if (!InRange(position))
                throw new ArgumentOutOfRangeException(nameof(position));

            GridCell cell = GetCell(position);

            cell.ClearOccupant();
        }
    }
}