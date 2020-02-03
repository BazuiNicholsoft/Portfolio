using System;
using System.Collections.Generic;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Logic.Services.AI
{
    public class MediumBot : IArtificalIntelligence
    {
        private readonly Player bot;
        private readonly IAILogic _aIlogic;
        public MediumBot(IAILogic aILogic, Player botPlayer)
        {
            _aIlogic = aILogic;
            bot = botPlayer;
        }

        public GridPos MakeMove(Board board)
        {
            GridPos possibleWinMove = _aIlogic.WinningMove(board, bot);
            if(possibleWinMove.x != -1)
            {
                return possibleWinMove;
            }

            return _aIlogic.RandomMove(board);

        }
    }
}
