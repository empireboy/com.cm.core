namespace CM.Core.Interfaces
{
    public interface ICharacter
    {
        void Jump();
        void SetMovementInput(IMovementInput movementInput);
    }
}