using TicTacToe.Logic.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Logic.Services.AI
{
    class EasyBot : IArtificalIntelligence
    {
        private IAILogic _AILogic;
        public EasyBot(IAILogic aILogic)
        {
            _AILogic = aILogic;
        }

        public GridPos MakeMove(Board board)
        {
            return _AILogic.RandomMove(board);
        }
    }
}
