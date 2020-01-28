using TicTacToe.Models;

namespace TicTacToe.Logic.Interfaces
{
    public interface ICheckPlay
    {
        public bool CheckWin(Board grid, char player, GridPos lastPlay);
        public bool CheckAvailable(Board grid, GridPos pos);
        public GridPos[] GetAvailable(Board grid);
    }
}
