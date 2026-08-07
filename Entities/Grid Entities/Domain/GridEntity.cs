using System;

namespace CM.Core.Domain
{
    public class GridEntityState
    {
        public Int2 Position { get; set; }
        public Direction Direction { get; set; }
        public bool IsMoving { get; set; }
    }

    public class GridEntity : IGridEntity
    {
        public Int2 Position => _state.Position;
        public Direction Direction => _state.Direction;
        public bool IsMoving => _state.IsMoving;

        public event Action<Int2> PositionChanged;
        public event Action<Direction> DirectionChanged;
        public event Action<Int2> Teleported;
        public event Action<bool> MovementStateChanged;
        public event Action MovementFinished;
        public event Action<Int2> TileReached;

        private readonly GridEntityState _state;

        public GridEntity(GridEntityState state)
        {
            _state = state;
        }

        public void SetPosition(Int2 position)
        {
            if (_state.Position == position)
                return;

            _state.Position = position;

            PositionChanged?.Invoke(position);
        }

        public void SetDirection(Direction direction)
        {
            if (_state.Direction == direction)
                return;

            _state.Direction = direction;

            DirectionChanged?.Invoke(direction);
        }

        public void SetMoving(bool moving)
        {
            if (_state.IsMoving == moving)
                return;

            _state.IsMoving = moving;

            MovementStateChanged?.Invoke(moving);
        }

        public void Teleport(Int2 position)
        {
            _state.Position = position;

            Teleported?.Invoke(position);
        }

        public void NotifyTileReached()
        {
            TileReached?.Invoke(Position);
        }

        public void NotifyMovementFinished()
        {
            MovementFinished?.Invoke();
        }
    }
}