namespace TicTacToe.Models
{
    public class Player
    {
        public char Side { get; }
        public bool IsFirstPlayer { get; private set; }
        public bool IsAI { get; private set; }

        public Player(char piece, bool first, bool isAI)
        {
            Side = piece;
            IsFirstPlayer = first;
            IsAI = isAI;
        }

        public void ChangeFirstPlayer()
        {
            IsFirstPlayer = !IsFirstPlayer;
        }

        public override bool Equals(object obj)
        {
            return (obj is Player) && ((Player)obj).Side == Side && ((Player)obj).IsFirstPlayer == IsFirstPlayer && ((Player)obj).IsAI == IsAI;
        }

        public override int GetHashCode()
        {
            return Side;
        }

    }
}
