namespace CM.Core.Domain
{
    public interface IGridTrigger : IGridEntity
    {
        void Execute(Grid grid, IGridEntity entity);
    }
}