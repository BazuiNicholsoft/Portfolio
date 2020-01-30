using TicTacToe.Models;

namespace TicTacToe.Logic.Interfaces
{
    public interface IArtificalIntelligence
    {
        public GridPos MakeMove(Board board);
    }
}
