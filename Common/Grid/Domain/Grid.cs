using System;

namespace CM.Core.Domain
{
    public class Grid
    {
        public int Width { get; }
        public int Height { get; }
        public Int2 Origin { get; }

        private readonly GridCell[,] _cells;

        public Grid(int width, int height, Int2 origin)
        {
            Width = width;
            Height = height;
            Origin = origin;

            _cells = new GridCell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Int2 gridPosition = new(origin.x + x, origin.y + y);

                    _cells[x, y] = new GridCell(gridPosition);
                }
            }
        }

        public bool InRange(Int2 position)
        {
            Int2 index = ToIndex(position);

            return index.x >= 0 &&
                index.x < Width &&
                index.y >= 0 &&
                index.y < Height;
        }

        public GridCell GetCell(Int2 position)
        {
            if (!InRange(position))
                throw new ArgumentOutOfRangeException(nameof(position));

            Int2 index = ToIndex(position);

            return _cells[index.x, index.y];
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

        private Int2 ToIndex(Int2 position)
        {
            return new Int2(position.x - Origin.x, position.y - Origin.y);
        }
    }
}