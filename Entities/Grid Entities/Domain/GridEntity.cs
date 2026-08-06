using System;

namespace CM.Core.Domain
{
    public class GridEntity : IGridEntity
    {
        public Int2 Position { get; private set; }
        public Direction Direction { get; private set; }
        public bool IsMoving { get; private set; }

        public event Action<Int2> PositionChanged;
        public event Action<Direction> DirectionChanged;
        public event Action<Int2> Teleported;
        public event Action<bool> MovementStateChanged;
        public event Action MovementFinished;
        public event Action<Int2> TileReached;

        public GridEntity(Int2 position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        public void SetPosition(Int2 position)
        {
            if (Position == position)
                return;

            Position = position;

            PositionChanged?.Invoke(position);
        }

        public void SetDirection(Direction direction)
        {
            if (Direction == direction)
                return;

            Direction = direction;

            DirectionChanged?.Invoke(direction);
        }

        public void SetMoving(bool moving)
        {
            if (IsMoving == moving)
                return;

            IsMoving = moving;

            MovementStateChanged?.Invoke(moving);
        }

        public void FinishMovement()
        {
            TileReached?.Invoke(Position);
            MovementFinished?.Invoke();
        }

        public void Teleport(Int2 position)
        {
            Position = position;

            Teleported?.Invoke(position);
        }
    }
}