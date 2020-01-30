using System;
using System.Collections.Generic;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Logic.Services.AI
{
    public class AILogic: IAILogic
    {
        private ICheckPlay _checkPlay;
        private Random random;

        public AILogic(ICheckPlay checkPlay)
        {
            _checkPlay = checkPlay;
            random = new Random();
        }

        public GridPos BlockingMove(Board board)
        {
            throw new NotImplementedException();
        }

        public GridPos CenterMove(Board board)
        {
            throw new NotImplementedException();
        }

        public GridPos CornerMove(Board board)
        {
            throw new NotImplementedException();
        }

        public GridPos RandomMove(Board board)
        {
            GridPos[] available = _checkPlay.GetAvailable(board);
            int choice = random.Next(0, available.Length - 1);
            return available[choice];
        }

        public GridPos WinningMove(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
