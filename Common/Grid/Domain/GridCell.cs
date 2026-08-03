namespace CM.Core.Domain
{
    public class GridCell
    {
        public Int2 Position { get; }
        public bool IsBlocked { get; set; }
        public IGridEntity Occupant { get; private set; }

        public bool IsOccupied => Occupant != null;

        public GridCell(Int2 position)
        {
            Position = position;
        }

        public void SetOccupant(IGridEntity entity)
        {
            Occupant = entity;
        }
        
        public void ClearOccupant()
        {
            Occupant = null;
        }
    }
}