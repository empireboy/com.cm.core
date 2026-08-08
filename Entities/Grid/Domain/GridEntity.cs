using System;

namespace CM.Core.Domain
{
    public class GridEntity : IGridEntity
    {
        public Int2 Position => State.Position;
        public Direction Direction => State.Direction;

        public event Action<Int2> PositionChanged;
        public event Action<Direction> DirectionChanged;

        protected GridEntityState State { get; }

        public GridEntity(GridEntityState state)
        {
            State = state;
        }

        public void SetPosition(Int2 position)
        {
            if (State.Position == position)
                return;

            State.Position = position;

            PositionChanged?.Invoke(position);
        }

        public void SetDirection(Direction direction)
        {
            if (State.Direction == direction)
                return;

            State.Direction = direction;

            DirectionChanged?.Invoke(direction);
        }
    }
}