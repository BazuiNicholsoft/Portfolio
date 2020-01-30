using System.Collections.Generic;
using TicTacToe.Models;
using TicTacToe.Logic.Interfaces;

namespace TicTacToe.Logic.Services
{
    public class Setup : ISetup
    {
        public Board SetupBoard(int size = Constants.DefaultSize)
        {
            return new Board(size);
        }

        public List<Player> SetupPlayers(bool playerOneIsAI, bool playerTwoIsAI)
        {
            List<Player> players = new List<Player>
            {
                new Player(Constants.PlayerChar1, true, playerOneIsAI),
                new Player(Constants.PlayerChar2, false, playerTwoIsAI)
            };
            return players;
        }
    }
}
