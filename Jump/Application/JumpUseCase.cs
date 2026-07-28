using CM.Core.Domain;
using CM.Core.Interfaces;

namespace CM.Core.Application
{
    public class JumpUseCase
    {
        private readonly JumpState _state;
        private readonly JumpSettings _settings;
        private readonly IJumpPhysics _physics;

        public JumpUseCase(JumpState state, JumpSettings settings, IJumpPhysics physics)
        {
            _state = state;
            _settings = settings;
            _physics = physics;
        }

        public void Jump()
        {
            if (!_state.IsGrounded)
                return;

            _physics.Jump(_settings.force);
        }
    }
}