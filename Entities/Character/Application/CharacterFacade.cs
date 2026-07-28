using CM.Core.Domain;
using CM.Core.Interfaces;

namespace CM.Core.Application
{
    public class CharacterFacade : ICharacter, ITickable
    {
        private readonly JumpUseCase _jumpUseCase;
        private readonly MoveUseCase _moveUseCase;
        private IMovementInput _movementInput;

        public CharacterFacade(JumpUseCase jumpUseCase, MoveUseCase moveUseCase, IMovementInput movementInput)
        {
            _jumpUseCase = jumpUseCase;
            _moveUseCase = moveUseCase;
            _movementInput = movementInput;
        }

        public void Jump() => _jumpUseCase.Jump();
        public void SetMovementInput(IMovementInput movementInput) => _movementInput = movementInput;

        public void Tick()
        {
            _moveUseCase.Move(_movementInput.Direction);
        }
    }
}