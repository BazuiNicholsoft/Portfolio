using System.Collections.Generic;
using TicTacToe.Models;

namespace TicTacToe.Logic.Interfaces
{
    public interface ISetup
    {
        public Board SetupBoard(int size = Constants.DefaultSize);
        public List<Player> SetupPlayers(bool playerOneIsAI, bool playerTwoIsAI);
    }
}
