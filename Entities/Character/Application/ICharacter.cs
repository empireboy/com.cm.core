namespace CM.Core.Application
{
    public interface ICharacter
    {
        void Jump();
        void SetMovementInput(IMovementInput movementInput);
    }
}