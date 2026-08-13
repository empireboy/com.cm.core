using CM.Core.Domain;
using System;

namespace CM.Core.Application
{
    public class GameStateManager
    {
        public GameState Current { get; private set; }

        public event Action<GameState> StateChanged;

        public GameStateManager(GameState currentGameState)
        {
            ChangeState(currentGameState);
        }
        
        public void ChangeState(GameState newState)
        {
            Current = newState;

            StateChanged?.Invoke(newState);
        }
    }
}