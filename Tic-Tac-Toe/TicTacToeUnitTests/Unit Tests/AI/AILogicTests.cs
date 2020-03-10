using NUnit.Framework;
using TicTacToe.Models;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Logic.Services;
using TicTacToe.Logic;
using TicTacToe.Logic.Services.AI;
using System;

namespace TicTacToeUnitTests.Unit_Tests.AI
{
    [TestFixture]
    public class AILogicTests
    {
        IAILogic _aiLogic;
        ICheckPlay _checkPlay;

        [SetUp]
        public void init()
        {
            _checkPlay = new CheckPlay();
            _aiLogic = new AILogic(_checkPlay);
        }


    }
}
