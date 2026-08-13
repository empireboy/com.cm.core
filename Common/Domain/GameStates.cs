namespace CM.Core.Domain
{
    public static class GameStates
    {
        public static readonly GameState Gameplay = new("Gameplay");
        public static readonly GameState Dialogue = new("Dialogue");
    }
}