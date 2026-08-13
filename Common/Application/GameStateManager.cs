using CM.Core.Domain;

namespace CM.Core.Application
{
    public class GameStateManager
    {
        public GameState Current { get; private set; }

        public GameStateManager(GameState currentGameState)
        {
            ChangeState(currentGameState);
        }
        
        public void ChangeState(GameState newState)
        {
            Current = newState;
        }
    }
}