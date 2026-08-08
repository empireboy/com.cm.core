using CM.Core.Domain;

namespace CM.Core.Application
{
    public class MoveUseCase
    {
        private readonly MoveState _state;
        private readonly MovementSettings _settings;
        private readonly IMovePhysics _physics;

        public MoveUseCase(MoveState state, MovementSettings settings, IMovePhysics physics)
        {
            _state = state;
            _settings = settings;
            _physics = physics;
        }

        public void Move(Float2 direction)
        {
            Float2 finalDirection = new(
                direction.x * _settings.speed,
                direction.y * _settings.speed
            );

            _state.Direction = finalDirection;

            _physics.Move(finalDirection);
        }
    }
}