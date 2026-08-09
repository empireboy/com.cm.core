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
            _actor.TileReached += OnTileReached;
        }

        public void Dispose()
        {
            _actor.TileReached -= OnTileReached;
        }

        private void OnTileReached(Int2 position)
        {
            GridCell cell = _grid.GetCell(position);

            cell.Trigger?.Execute(_grid, _actor);
        }
    }
}
