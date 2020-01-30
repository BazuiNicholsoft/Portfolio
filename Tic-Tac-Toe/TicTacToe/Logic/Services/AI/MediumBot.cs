using System;
using System.Collections.Generic;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Logic.Services.AI
{
    public class MediumBot : IArtificalIntelligence
    {
        private ICheckPlay _checkPlay;
        private readonly Random random;
        private readonly Player bot;
        public MediumBot(ICheckPlay checkPlay, Player botPlayer)
        {
            _checkPlay = checkPlay;
            random = new Random();
            bot = botPlayer;
        }

        public GridPos MakeMove(Board board)
        {
            GridPos[] available = _checkPlay.GetAvailable(board);

            for(int i = 0; i < available.Length; i++)
            {
                if(_checkPlay.CheckWin(board, bot.Side, available[i]))
                {
                    return available[i];
                }
            }

            return available[random.Next(0, available.Length - 1)];           

        }
    }
}
