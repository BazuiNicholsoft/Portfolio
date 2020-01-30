using System;
using System.Collections.Generic;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Logic.Services.AI
{
    public class HardBot : IArtificalIntelligence
    {
        private readonly ICheckPlay _checkPlay;

        public HardBot(ICheckPlay checkPlay)
        {
            _checkPlay = checkPlay;
        }

        public GridPos MakeMove(Board board)
        {
            GridPos[] available = _checkPlay.GetAvailable(board);

            for(int i = 0; i < available.Length; i++)
            {

            }
        }
    }
}
