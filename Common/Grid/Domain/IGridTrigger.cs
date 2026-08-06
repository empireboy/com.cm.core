namespace CM.Core.Domain
{
    public interface IGridTrigger : IGridEntity
    {
        void Execute(IGridEntity entity);
    }
}