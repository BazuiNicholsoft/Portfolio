using System.Collections.Generic;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Models;
using System;

namespace TicTacToe.Logic.Services.AI
{
    class EasyBot : IArtificalIntelligence
    {
        private ICheckPlay _checkPlay;
        private Random _random;
        public EasyBot(ICheckPlay checkPlay)
        {
            _checkPlay = checkPlay;
            _random = new Random();
        }

        public GridPos MakeMove(Board board)
        {
            GridPos[] available = _checkPlay.GetAvailable(board);
            int choice = _random.Next(0, available.Length - 1);
            return available[choice];
        }
    }
}
