using CM.Core.Domain;
using System;

namespace CM.Core.Application
{
    public class GridEntityFacade
    {
        public Int2 Position => Entity.Position;
        public Direction Direction => Entity.Direction;

        public event Action<Int2> PositionChanged
        {
            add => Entity.PositionChanged += value;
            remove => Entity.PositionChanged -= value;
        }

        public event Action<Direction> DirectionChanged
        {
            add => Entity.DirectionChanged += value;
            remove => Entity.DirectionChanged -= value;
        }

        protected IGridEntity Entity { get; }

        public GridEntityFacade(IGridEntity entity)
        {
            Entity = entity;
        }
    }
}