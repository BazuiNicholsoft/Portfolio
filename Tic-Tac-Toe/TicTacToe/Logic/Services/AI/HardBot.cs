using System;
using System.Collections.Generic;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Logic.Services.AI
{
    public class HardBot : IArtificalIntelligence
    {
        private readonly Player bot;
        private readonly IAILogic _aILogic;
        public HardBot(IAILogic aILogic, Player player)
        {
            _aILogic = aILogic;
            bot = player;
        }

        public GridPos MakeMove(Board board)
        {
            GridPos move = _aILogic.WinningMove(board, bot);
            if (move.x != -1)
                return move;

            move = _aILogic.CenterMove(board);
            if (move.x != -1)
                return move;

            move = _aILogic.CornerMove(board);
            if (move.x != -1)
                return move;

            return _aILogic.RandomMove(board);

        }
    }
}
