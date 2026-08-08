using System;

namespace CM.Core.Domain
{
    public class GridActor : GridEntity, IGridActor
    {
        public bool IsMoving => ActorState.IsMoving;

        public event Action<Int2> Teleported;
        public event Action<bool> MovementStateChanged;
        public event Action MovementFinished;
        public event Action<Int2> TileReached;

        private GridActorState ActorState => (GridActorState)State;

        public GridActor(GridActorState state) : base(state)
        {

        }

        public void SetMoving(bool moving)
        {
            if (ActorState.IsMoving == moving)
                return;

            ActorState.IsMoving = moving;

            MovementStateChanged?.Invoke(moving);
        }

        public void Teleport(Int2 position)
        {
            ActorState.Position = position;

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
