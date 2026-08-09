using System;
using Zenject;

namespace CM.Core.Domain
{
    public class GridActorTriggerController : IInitializable, IDisposable
    {
        private readonly Grid _grid;
        private readonly IGridActor _actor;

        public GridActorTriggerController(Grid grid, IGridActor actor)
        {
            _grid = grid;
            _actor = actor;
        }

        public void Initialize()
        {
            _actor.MovementFinished += OnMovementFinished;
        }

        public void Dispose()
        {
            _actor.MovementFinished -= OnMovementFinished;
        }

        private void OnMovementFinished()
        {
            GridCell cell = _grid.GetCell(_actor.Position);

            cell.Trigger?.Execute(_grid, _actor);
        }
    }
}
