using TicTacToe.Models;

namespace TicTacToe.Logic.Interfaces
{
    public interface IAILogic
    {
        public GridPos WinningMove(Board board);
        public GridPos RandomMove(Board board);
        public GridPos CenterMove(Board board);
        public GridPos CornerMove(Board board);
        public GridPos BlockingMove(Board board);


    }
}
