namespace CM.Core.Domain
{
    public interface IGridTrigger
    {
        void Execute(IGridEntity entity);
    }
}