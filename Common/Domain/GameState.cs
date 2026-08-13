using System;

namespace CM.Core.Domain
{
    public readonly struct GameState : IEquatable<GameState>
    {
        public string Name { get; }

        public GameState(string name)
        {
            Name = name;
        }

        public bool Equals(GameState other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is GameState other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }

        public static bool operator ==(GameState a, GameState b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(GameState a, GameState b)
        {
            return !a.Equals(b);
        }
    }
}